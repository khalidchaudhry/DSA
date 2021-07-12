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

        public Consumer(string name)
        {
            Name = name;
        }
    }
}
