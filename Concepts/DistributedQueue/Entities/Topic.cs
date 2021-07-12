using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedQueue.Entities
{
    public class Topic
    {
        private List<Message> _messages;
        private List<Consumer> _consumers;
        public string TopicName { get; private set; }

        public Topic(string topicName)
        {
            TopicName = topicName;
            _consumers = new List<Consumer>();
            _messages = new List<Message>();
        }

        public void AddConsumer(Consumer consumer)
        {
            _consumers.Add(consumer);
        }

        public void RemoveConsumer(Consumer consumer)
        {
            _consumers.Remove(consumer);
        }

        public void AddMessage(Message message)
        {
            _messages.Add(message);
        }

        public int GetMessagesCount()
        {
            return _messages.Count;
        }
        public string GetMessage(int idx)
        {
            return _messages[idx].Text;
        }

    }
}
