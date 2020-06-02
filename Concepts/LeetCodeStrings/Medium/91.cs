using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _91
    {
        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int[] dp = new int[s.Length + 1];

            dp[0] = 1;
            dp[1] = Char.GetNumericValue(s[0]) == 0 ? 0 : 1;

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
