using LeetCodeDynamicProgramming.Easy;
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

            //_139 WordBreak = new _139();
            //List<string> wordDict = new List<string>()
            //{
            //   "leet", "code"
            //};
            //var answer=WordBreak.WordBreak0("leetcode", wordDict);           

            //_256 MinCost = new _256();

            //int[][] cost = new int[][] { new int[] { 7, 6, 2 } };
            //int minCost=MinCost.MinCost(cost);

            // _322 CoinChange = new _322();
            //var result=CoinChange.CoinChange2(new int[] { 1,2,5 }, 11);

            _64 MinPathSum = new _64();
            int[][] grid = new int[2][]
           {
               new int[]{1,2,5},
               new int[]{3,2,1}
           };
            var ans=MinPathSum.MinPathSum(grid);

            Console.ReadLine();
        }
    }
}
