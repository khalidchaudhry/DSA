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

        private string _producerName;

        public Producer(string name, Queue queue)
        {
            _producerName = name;
            _queue = queue;
        }

        public void PublishMessage(string topicName, Message msg)
        {
            _queue.QueueMessage(topicName, msg);
        }

    }
}
