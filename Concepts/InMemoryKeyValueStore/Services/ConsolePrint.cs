using InMemoryKeyValueStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryKeyValueStore.Services
{
    public class ConsolePrint:IPrint
    {
        public void Print(string str)
        {
            Console.WriteLine(str);
        }
        public void Print(List<string> lst)
        {
            Console.WriteLine(string.Join(",",lst));
        }
    }
}
