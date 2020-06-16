using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _91
    {
        /// <summary>
        //https://leetcode.com/problems/decode-ways/discuss/30358/Java-clean-DP-solution-with-explanation
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            //dp[i]: represents possible decode ways to the ith char(include i), whose index in string is i - 1
            int[] dp = new int[s.Length + 1];
            //!dp[0] means an empty string will have one way to decode
            dp[0] = 1;
            //!dp[1] means the way to decode a string of size 1.
            dp[1] = char.GetNumericValue(s[0]) == 0 ? 0 : 1;

            for (int i = 2; i < dp.Length; i++)
            {
                //one digit
                int first = Convert.ToInt32(s.Substring(i - 1, 1));
                //two digit
                int second = Convert.ToInt32(s.Substring(i - 2, 2));

                if (first >= 1 && first <= 9)
                {
                    dp[i] += dp[i - 1];
                }

                if (second >= 10 && second <= 26)
                {
                    dp[i] += dp[i - 2];

                }
            }

            return dp[s.Length];

        }


    }
}
