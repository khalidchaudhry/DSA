using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedQueue.Entities
{
    public class Consumer
    {
        public string Name { get; private set; }
        public int Offset { get; private set; }

        public Consumer(string name)
        {
            Name = name;
            Offset = 0;
        }
        public void IncrementOffset()
        {
            ++Offset;
        }
    }
}
