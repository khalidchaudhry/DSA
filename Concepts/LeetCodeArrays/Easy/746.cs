using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _746
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            if (cost.Length == 0)
                return 0;

            if (cost.Length == 1)
            {
                return cost[0];
            }           

            int[] dp = new int[cost.Length];
                        
            dp[0] = cost[0];

            dp[1] = cost[1];

            for (int i = 2; i < cost.Length; i++)
            {
                dp[i] = Math.Min(dp[i-2],dp[i-1])+cost[i];
            }

            return Math.Min(dp[cost.Length-1],dp[cost.Length-2]);

        }

    }
}
