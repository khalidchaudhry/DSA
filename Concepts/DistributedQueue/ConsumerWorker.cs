using DistributedQueue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedQueue
{
    public class ConsumerWorker
    {
        private Topic _topic;
        private Consumer _consumer;

        public ConsumerWorker(Topic topic,Consumer consumer)
        {
            _topic = topic;
            _consumer = consumer;

        }

    }
}
