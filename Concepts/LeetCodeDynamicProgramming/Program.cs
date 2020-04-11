using LeetCodeDynamicProgramming.Medium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            //// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            //Console.WriteLine("Hello World!");
            //Console.ReadKey();

            //// Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
            ///

            _139 WordBreak = new _139();
            List<string> wordDict = new List<string>()
            {
               "leet", "code"
            };
            var answer=WordBreak.WordBreak0("leetcode", wordDict);
            Console.ReadLine();
        }
    }
}
