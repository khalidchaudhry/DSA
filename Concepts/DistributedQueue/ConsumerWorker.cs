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
        private ConsoleConsumer _consumer;
        private Topic _topic;
        private int _offSet;

        public ConsumerWorker(ConsoleConsumer consumer, Topic topic)
        {
            _consumer = consumer;
            _topic = topic;
            _offSet = 0;

            var thread = new Thread(new ThreadStart(OnStart));            
            thread.Start();

        }
        private void OnStart()
        {
            while (true)
            {
                if (_offSet != _topic.GetMessagesCount())
                {                    
                    string msg=($"{_consumer.ConsumerName} received {_topic.GetMessage(_offSet)} ");
                    _consumer.Consume(msg);
                    ++_offSet;
                }
            }
        }
    }
}
