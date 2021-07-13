using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace InMemoryKeyValueStore.Entities
{
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
            sb.Length=sb.Length-2;
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
        public ImmutableDictionary<string, Value> GetAttributeNameValue()
        {
            return _attributeNameValue.ToImmutableDictionary();
        }

    }
}
