using DistributedQueue.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedQueue.Services
{
    public class ConsolePrint : IPrint
    {
        public void Print(string str)
        {
            Console.WriteLine(str);
        }
    }
}
