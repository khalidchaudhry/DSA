using DistributedQueue.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            //Git test

            ApplicationRunner runner = new ApplicationRunner();
            runner.Run();

            Console.ReadKey();
        }
    }
}
