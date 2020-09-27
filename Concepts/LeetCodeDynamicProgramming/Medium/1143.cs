using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _1143
    {


        public static void _1143Main()
        {
            _1143 lcs = new _1143();
            string text1 = "abc";
            string text2 = "abc";

            var ans = lcs.LongestCommonSubsequence2(text1, text2);

            Console.WriteLine();

        }



        /// <summary>
        // !DP Tabulation approach
        // # <image url="https://miro.medium.com/max/875/1*FmOSwMIF5a4Y7abnOye9TA.png" scale="0.4" />

        // # <image url="https://image1.slideserve.com/2983281/example19-l.jpg" scale="0.4" />

        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <returns></returns>
        public int LongestCommonSubsequence0(string text1, string text2)
        {
            int rowLength = text1.Length;
            int columnLength = text2.Length;
            int[,] dp = new int[rowLength + 1, columnLength + 1];

            for (int row = 0; row < rowLength; row++)
                for (int column = 0; column < columnLength; column++)
                {
                    if (text1[row].Equals(text2[column]))
                    {
                        dp[row + 1, column + 1] = dp[row, column] + 1;
                    }
                    else
                    {
                        dp[row + 1, column + 1] = Math.Max(dp[row + 1, column], dp[row, column + 1]);
                    }
                }
            return dp[rowLength, columnLength];
        }


        /// <summary>
        //! DP with memoization 
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <returns></returns>
        public int LongestCommonSubsequence2(string text1, string text2)
        {
            Dictionary<string, int> cache = new Dictionary<string, int>();
            return LongestCommonSubsequence2(text1, 0, text2, 0, cache);

        }

        private int LongestCommonSubsequence2(string text1, int p1, string text2, int p2, Dictionary<string, int> cache)
        {
            if (p1 == text1.Length || p2 == text2.Length)
            {
                return 0;
            }

            string key = $"{p1}{p2}";

            if (cache.ContainsKey(key))
                return cache[key];

            int value = 0;

            if (text1[p1].Equals(text2[p2]))

            {
                value = 1 + LongestCommonSubsequence2(text1, p1 + 1, text2, p2 + 1, cache);
            }

            else
            {
                value = Math.Max(LongestCommonSubsequence2(text1, p1 + 1, text2, p2, cache),
                                 LongestCommonSubsequence2(text1, p1, text2, p2 + 1, cache));
            }

            cache[key] = value;

            return cache[key];
        }




        /// <summary>
        //! Brute force  
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <returns></returns>
        public int LongestCommonSubsequence3(string text1, string text2)
        {

            return LongestCommonSubsequence3(text1, 0, text2, 0);

        }

        private int LongestCommonSubsequence3(string text1, int p1, string text2, int p2)
        {
            if (p1 == text1.Length || p2 == text2.Length)
            {
                return 0;
            }

            if (text1[p1].Equals(text2[p2]))
            {
                return 1 + LongestCommonSubsequence3(text1, p1 + 1, text2, p2 + 1);
            }
            else
            {
                return Math.Max(LongestCommonSubsequence3(text1, p1 + 1, text2, p2),
                                LongestCommonSubsequence3(text1, p1, text2, p2 + 1));
            }
        }
    }
}
