using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryKeyValueStore.Entities
{
    public class AttributePair
    {
        public string Name { get; private set; }
        public string Value { get; private set; }

        public AttributePair(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
