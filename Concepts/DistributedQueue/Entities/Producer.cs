using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedQueue.Entities
{
    public class Producer
    {
        public string Name { get; private set; }

        public Producer(string name)
        {
            Name = name;
        }

    }
}
