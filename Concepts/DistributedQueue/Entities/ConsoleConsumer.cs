using DistributedQueue.Entities.Interface;
using DistributedQueue.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedQueue.Entities
{

    public class ConsoleConsumer: IConsumer
    {
        private IPrint _print;
        public string Name{ get; private set; }

        public ConsoleConsumer(string name,IPrint print)
        {
            Name = name;
            _print = print;
        }

        public void Consume(string message)
        {
            _print.Print(message);

        }
    }
}
