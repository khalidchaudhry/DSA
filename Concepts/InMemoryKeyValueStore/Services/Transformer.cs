using InMemoryKeyValueStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryKeyValueStore.Services
{
    public static class Transformer
    {
        public static Dictionary<string, Value> Transform(List<(string attributeName, string attributeValue)> pairs)
        {
            Dictionary<string, Value> attributeNamesValues = new Dictionary<string, Value>();

            AttributeTypes attributeType = AttributeTypes.None;
            foreach ((string name, string value) in pairs)
            {
                //! incase same attribute name provided multiple times, we will just refer the first attributes
                if (attributeNamesValues.ContainsKey(name))
                {
                    continue;
                }

                //! what  will be the sequence in which we need to apply parsing ?
                //attribute values could be string, integer, double or boolean.
                if (int.TryParse(value, out int intResult))
                {
                    attributeType = AttributeTypes.IntegerType;
                }
                else if (double.TryParse(value, out double doubleResult))
                {
                    attributeType = AttributeTypes.DoubleType;
                }
                else if (bool.TryParse(value, out bool boolResult))
                {
                    attributeType = AttributeTypes.BooleanType;
                }
                else
                {
                    attributeType = AttributeTypes.stringType;
                }

                attributeNamesValues.Add(name, new Value(value, attributeType));
            }
            return attributeNamesValues;
        }

    }
}
