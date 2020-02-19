using System;

namespace Greedy
{
    class Program
    {
        static void Main(string[] args)
        {
            //_1221 BalancedString = new _1221();

            //Console.WriteLine(BalancedString.balancedStringSplit("RLRRRLLRLL"));

            //_392 IsSubsequence = new _392();
            //string s = "axc";
            //string t = "ahbgdc";

            //Console.WriteLine(IsSubsequence.IsSubsequence(s,t));

            _1029 TwoCityScheduling = new _1029();

            int[][] costs = new int[][]
                {
                    new int[]{10,20 },
                    new int[]{30,200 },
                    new int[]{400,50 },
                    new int[]{30,20 },
                };

            Console.WriteLine(TwoCityScheduling.TwoCitySchedCost3(costs));
            Console.ReadLine();
        }
    }
}
