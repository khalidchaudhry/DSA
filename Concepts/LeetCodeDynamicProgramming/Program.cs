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

            // _64 MinPathSum = new _64();
            // int[][] grid = new int[2][]
            //{
            //    new int[]{1,2,5},
            //    new int[]{3,2,1}
            //};
            // var ans = MinPathSum.MinPathSum(grid);

            //_120 Triangle = new _120();
            //List<IList<int>> triangle = new List<IList<int>>()
            //{
            //    new List<int>{2},
            //    new List<int>{3,4 },
            //    new List<int>{6,5,7},
            //    new List<int>{4,1,8,3 }

            //};

            //var ans=Triangle.MinimumTotal2(triangle);
            //_221 MaximalSquare = new _221();
            //char[][] matrix = new char[][]
            //    {
            //        new char[]{ '1'}
            //        //new char[]{ '1', '0', '1', '0', '0' },
            //        //new char[]{ '1', '0', '1', '1', '1' },
            //        //new char[]{ '1', '1', '1', '1', '1' },
            //        //new char[]{ '1', '0', '0', '1', '0' }
            //    };



            //MaximalSquare.MaximalSquare(matrix);


            //_1143 longest = new _1143();
            //string s1 = "pmjghexybyrgzczy";
            //string s2 = "hafcdqbgncrcbihkd";
            //longest.LongestCommonSubsequence(s1, s2);
            //_647 Count = new _647();

            //var result=Count.CountSubstrings("aaa");

            //int[] prices = new int[] { 1,3,7,5,10,3 };
            //int fee = 3;
            //_714 MaxProfit = new _714();

            //var ans=MaxProfit.MaxProfit(prices,fee);

            //_309 ProfitWithCoolDown = new _309();
            //int[] prices = new int[] { 1, 2, 3, 0, 2 };

            //var ans=ProfitWithCoolDown.MaxProfit(prices);

            //_213 HouseRobber = new _213();

            //int[] nums = new int[4] {2,1,1,2 };

            //HouseRobber.Rob(nums);

            _338 CountBits = new _338();
            var ans = CountBits.CountBits0(5);

            Console.ReadLine();
        }
    }
}
