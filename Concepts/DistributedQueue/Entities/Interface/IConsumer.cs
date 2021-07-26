using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedQueue.Entities.Interface
{
    public interface IConsumer
    {
        void Consume(string msg);
    }
}
