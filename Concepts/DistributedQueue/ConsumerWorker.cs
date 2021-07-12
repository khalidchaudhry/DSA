using DistributedQueue.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DistributedQueue
{
    public class ConsumerWorker
    {
        private Consumer _consumer;
        private Topic _topic;
        private int _offSet;

        public ConsumerWorker(Consumer consumer, Topic topic)
        {
            _consumer = consumer;
            _topic = topic;
            _offSet = 0;

            var thread = new Thread(new ThreadStart(OnStart));
            thread.IsBackground = true;
            thread.Start();

        }
        private void OnStart()
        {

            if (_offSet == _topic.GetMessagesCount())
            {
                return;
            }
            Console.WriteLine($"{_consumer.Name} received {_topic.GetMessage(_offSet)} ");
            ++_offSet;            
        }

    }
}
