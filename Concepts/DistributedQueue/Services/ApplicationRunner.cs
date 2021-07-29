
using DistributedQueue.Entities;
using System;

namespace DistributedQueue.Services
{
    public class ApplicationRunner
    {
        public void Run()
        {
            Queue queue = new Queue("MyQueue");
            Topic topic1 = new Topic("topic1");
            Topic topic2 = new Topic("topic2");
            queue.AddTopic(topic1);
            queue.AddTopic(topic2);


            Message msg1 = new Message("Message 1");
            Message msg2 = new Message("Message 2");
            Message msg3 = new Message("Message 3");
            Message msg4 = new Message("Message 4");
            Message msg5 = new Message("Message 5");

            Producer producer1 = new Producer("producer 1", queue);
            Producer producer2 = new Producer("producer 2", queue);

            producer1.PublishMessage("topic1", msg1);
            producer1.PublishMessage("topic1", msg2);
            producer2.PublishMessage("topic1", msg3);
            producer1.PublishMessage("topic2", msg4);
            producer2.PublishMessage("topic1", msg5);

            ConsolePrint print = new ConsolePrint();

            ConsoleConsumer consumer1 = new ConsoleConsumer("consumer1", print);
            ConsoleConsumer consumer2 = new ConsoleConsumer("consumer2", print);
            ConsoleConsumer consumer3 = new ConsoleConsumer("consumer3", print);
            ConsoleConsumer consumer4 = new ConsoleConsumer("consumer4", print);
            ConsoleConsumer consumer5 = new ConsoleConsumer("consumer5", print);

            //Subscribing all consumers to topic 1
            //Make consumers 1, 3, and 4 subscribe to topic2
            //Make consumers 1, 3, and 4 subscribe to topic2

            ConsumerWorker cosumer1Topic1Worker = new ConsumerWorker(consumer1, topic1);
            ConsumerWorker cosumer2Topic1Worker = new ConsumerWorker(consumer2, topic1);
            ConsumerWorker cosumer3Topic1Worker = new ConsumerWorker(consumer3, topic1);
            ConsumerWorker cosumer4Topic1Worker = new ConsumerWorker(consumer4, topic1);
            ConsumerWorker cosumer5Topic1Worker = new ConsumerWorker(consumer5, topic1);

            ConsumerWorker cosumer1Topic2Worker = new ConsumerWorker(consumer1, topic2);
            ConsumerWorker cosumer3Topic2Worker = new ConsumerWorker(consumer3, topic2);
            ConsumerWorker cosumer4Topic2Worker = new ConsumerWorker(consumer4, topic2);


        }




    }
}
