using InMemoryKeyValueStore.Entities.Interfaces;
using InMemoryKeyValueStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static InMemoryKeyValueStore.Entities.MemoryKeyValueStore.ValueStore;

namespace InMemoryKeyValueStore.Entities
{
    public class MemoryKeyValueStore: IKeyValueStore
    {

        private Dictionary<string, ValueStore> _keyValue;

        public MemoryKeyValueStore()
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

        public void Put(string key, List<AttributePair> listOfAttributePairs)
        {
            Dictionary<string, Value> attritbuteNameValue = Transformer.Transform(listOfAttributePairs);
            //! is it good practice to create an object of another class inside the class?
            ValueStore valueStore = new ValueStore(attritbuteNameValue);

            if (!_keyValue.ContainsKey(key))
            {
                _keyValue.Add(key, valueStore);
                return;
            }

            Dictionary<string, Value> currAttritbuteNameValue = _keyValue[key].GetAttributeNameValue();

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
            return string.Join(",", _keyValue.Keys.OrderBy(x => x));
        }
        public class ValueStore
        {
            Dictionary<string, Value> _attributeNameValue;
            public ValueStore()
            {
                _attributeNameValue = new Dictionary<string, Value>();
            }
            public ValueStore(Dictionary<string, Value> attributeNameValue)
            {
                _attributeNameValue = attributeNameValue;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                foreach (var keyValue in _attributeNameValue)
                {
                    string attributeName = keyValue.Key;
                    string attributeValue = keyValue.Value.ToString();
                    sb.Append(attributeName);
                    sb.Append(":");
                    sb.Append(attributeValue);
                    sb.Append(",");
                    sb.Append(" ");
                }
                //Triming off last two character as they are extra 
                sb.Length = sb.Length - 2;
                return sb.ToString();
            }
            public bool IsExist(string attributeKey, string attributeValue)
            {
                if (!_attributeNameValue.ContainsKey(attributeKey))
                    return false;

                string value = _attributeNameValue[attributeKey].GetAttributeValue();
                if (value == attributeValue)
                {
                    return true;
                }
                return false;
            }
            public Dictionary<string, Value> GetAttributeNameValue()
            {
                return _attributeNameValue;
            }
            public class Value
            {
                private string _attributeValue;
                private AttributeTypes _attributeType;

                public Value(string attributeValue, AttributeTypes attributeType)
                {
                    _attributeValue = attributeValue;
                    _attributeType = attributeType;
                }

                public string GetAttributeValue()
                {
                    return _attributeValue;
                }

                public AttributeTypes GetAttributeType()
                {
                    return _attributeType;
                }

                public override string ToString()
                {
                    return _attributeValue;
                }

            }
        }
    }
}
