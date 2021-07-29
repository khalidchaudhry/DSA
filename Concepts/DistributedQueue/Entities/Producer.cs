using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedQueue.Entities
{


    public class Producer
    {
        private Queue _queue;

        public string Name { get; private set; }

        public Producer(string name, Queue queue)
        {
            Name = name;
            _queue = queue;
        }

        public void PublishMessage(string topicName, Message msg)
        {
            _queue.QueueMessage(topicName, msg);
        }

    }
}
