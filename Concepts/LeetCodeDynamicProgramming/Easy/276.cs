using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Easy
{
    class _276
    {
        public int NumWays(int n, int k)
        {

            if (n == 0)
                return 0;

            int[] dp = new int[n + 1];

            dp[0] = 0;
            dp[1] = k;
            int same = 0;
            int different = k;

            for (int i = 2; i <= n; i++)
            {
                same = different;
                different = dp[i - 1] * (k - 1);
                dp[i] = same + different;
            }
            return dp[n];

        }


    }
}
