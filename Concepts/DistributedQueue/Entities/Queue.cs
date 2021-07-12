using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DistributedQueue.Entities
{
    public class Queue
    {
        
        private Dictionary<string, Topic> _topicNameTopic;

        public string QueueName { get; private set; }

        public Queue(string queueName)
        {
            QueueName = queueName;
            _topicNameTopic = new Dictionary<string, Topic>();          
        }
        public void AddTopic(Topic topic)
        {
            if (_topicNameTopic.ContainsKey(topic.TopicName))
            {
                //Need to ask interviewer that either we can create topic or throw exception 
                throw new InvalidOperationException("Topic already exists");
            }
            else
            {
                _topicNameTopic.Add(topic.TopicName, topic);
            }
        }

        public void RemoveTopic(Topic topic)
        {
            if (!_topicNameTopic.ContainsKey(topic.TopicName))
            {
                //Need to ask interviewer that either we can create topic or throw exception 
                throw new InvalidOperationException("Topic does not exist");
            }
            else
            {
                _topicNameTopic.Remove(topic.TopicName);
            }
        }

        public void QueueMessage(string topicName, Message msg)
        {
            _topicNameTopic[topicName].AddMessage(msg);
        }
    }
}
