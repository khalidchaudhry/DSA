using InMemoryKeyValueStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InMemoryKeyValueStore.Entities.MemoryKeyValueStore.ValueStore;

namespace InMemoryKeyValueStore.Services
{
    public static class Transformer
    {
        public static Dictionary<string, Value> Transform(List<AttributePair> pairs)
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

                attributeNamesValues.Add(pair.Name, new MemoryKeyValueStore.ValueStore.Value(pair.Value, attributeType));
            }
            return attributeNamesValues;
        }

    }
}
