using InMemoryKeyValueStore.Entities.Interfaces;
using InMemoryKeyValueStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using static InMemoryKeyValueStore.Entities.MemoryKeyValueStore.ValueStore;

namespace InMemoryKeyValueStore.Entities
{
    //!To make the class thread safe , one approach is to wrap
    //! PUT and delete methods with lock
    public class MemoryKeyValueStore : IKeyValueStore
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
            Dictionary<string, Value> attritbuteNameValue = Transform(listOfAttributePairs);
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
        private  Dictionary<string, Value> Transform(List<AttributePair> pairs)
        {
            Dictionary<string, Value> attributeNamesValues = new Dictionary<string, Value>();

            AttributeTypes attributeType = AttributeTypes.None;
            foreach (AttributePair pair in pairs)
            {
                //! incase same attribute name provided multiple times, we will just refer the first attributes
                if (attributeNamesValues.ContainsKey(pair.Name))
                {
                    continue;
                }

                //! what  will be the sequence in which we need to apply parsing ?
                //attribute values could be string, integer, double or boolean.
                if (int.TryParse(pair.Value, out int intResult))
                {
                    attributeType = AttributeTypes.IntegerType;
                }
                else if (double.TryParse(pair.Value, out double doubleResult))
                {
                    attributeType = AttributeTypes.DoubleType;
                }
                else if (bool.TryParse(pair.Value, out bool boolResult))
                {
                    attributeType = AttributeTypes.BooleanType;
                }
                else
                {
                    attributeType = AttributeTypes.stringType;
                }

                attributeNamesValues.Add(pair.Name, new Value(pair.Value, attributeType));
            }
            return attributeNamesValues;
        }

        private class ValueStore
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
        }
        private class Value
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
