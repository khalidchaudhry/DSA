using InMemoryKeyValueStore.Services;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace InMemoryKeyValueStore.Entities
{
    public class KeyValueStore
    {

        private Dictionary<string, ValueStore> _keyValue;

        public KeyValueStore()
        {
            _keyValue = new Dictionary<string, ValueStore>();
        }

        public string Get(string key)
        {
            if (!_keyValue.ContainsKey(key))
            {
                throw new Exception($"No entry found for {key}");
            }

            return _keyValue[key].ToString();
        }
        public List<string> Search(string attributeKey, string attributeValue)
        {
            List<string> result = new List<string>();
            foreach (var keyValue in _keyValue)
            {
                if (keyValue.Value.IsExist(attributeKey, attributeValue))
                {
                    result.Add(keyValue.Key);
                }
            }
            return result;
        }

        public void Put(string key, List<(string attributeName, string attributeValue)> listOfAttributePairs)
        {
            Dictionary<string, Value> attritbuteNameValue = Transformer.Transform(listOfAttributePairs);
            //! is it good practice to create an object of another class inside the class?
            ValueStore valueStore = new ValueStore(attritbuteNameValue);

            if (!_keyValue.ContainsKey(key))
            {
                _keyValue.Add(key, valueStore);
                return;
            }
            //! Immutable dictionary looks ugly . Is there a better way ?
            ImmutableDictionary<string, Value> currAttritbuteNameValue = _keyValue[key].GetAttributeNameValue();

            //Create intersection of two dictionaries 
            Dictionary<string, Value> intersectAttributeName = attritbuteNameValue.Keys.Intersect(currAttritbuteNameValue.Keys).ToDictionary(t => t, t => attritbuteNameValue[t]);
            foreach (var keyValue in attritbuteNameValue)
            {
                string name = keyValue.Key;
                Value value = keyValue.Value;

                if (intersectAttributeName.ContainsKey(name) &&
                    intersectAttributeName[name].GetAttributeType() != value.GetAttributeType())
                {
                    throw new Exception("Data Type Error");
                }
            }
            _keyValue[key] = valueStore;
        }
        public void Delete(string key)
        {
            if (!_keyValue.ContainsKey(key))
            {
                throw new Exception($"{key} does not exist");
            }
            _keyValue.Remove(key);
        }
        public string Keys()
        {
            return string.Join(",",_keyValue.Keys.OrderBy(x=>x));
        }
    }
}
