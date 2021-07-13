using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryKeyValueStore.Entities
{
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
