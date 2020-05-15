using LeetCodeTwoPointers.Medium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTwoPointers
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            //Console.WriteLine("Hello World!");

            //_209 MinimumSize = new _209();
            //int[] nums = new int[] {10,5,13,4,8,4,5,11,14,9,16,10,20,8};

            //var ans=MinimumSize.MinSubArrayLen(80,nums);


            _904 Fruit = new _904();

            int[] tree = new int[] {1,2,1 };

            var ans=Fruit.TotalFruit(tree);

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
