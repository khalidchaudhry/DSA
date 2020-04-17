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
                dp[i] = Math.Min(dp[i - 2], dp[i - 1]) + cost[i];
            }

            return Math.Min(dp[cost.Length - 1], dp[cost.Length - 2]);

        }
        // https://leetcode.com/problems/min-cost-climbing-stairs/discuss/578069/Javascript-DP-Solution
        public int MinCostClimbingStairs2(int[] cost)
        {
            if (cost.Length == 0)
                return 0;

            if (cost.Length == 1)
            {
                return cost[0];
            }

            int[] dp = new int[cost.Length + 1];

            dp[0] = 0;
            // cost of taking step 1
            dp[1] = cost[0];
            // cost of taking step 2
            dp[2] = cost[1];

            for (int i = 3; i <= cost.Length; i++)
            {
                // minumum cost of going to step i is sum of current step cost + minumum of previous two step costs 
                dp[i] = Math.Min(dp[i - 2], dp[i - 1]) + cost[i];
            }
            // Both of the Last two steps will take us to the top of floor so will pick the one having minimum cost
            return Math.Min(dp[cost.Length - 1], dp[cost.Length]);

        }

    }
}
