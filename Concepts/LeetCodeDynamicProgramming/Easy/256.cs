using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Easy
{
    public class _256
    {
        public int MinCost(int[][] costs)
        {
            if (costs.Length == 0)
                return 0;
            // ! how to create 2 dimensional array if input is jagged array. Pay attention to constant 3
            int[,] dp = new int[costs.GetLength(0) + 1, 3];
            int r = dp.GetLength(0);

            for (int i = 1; i < r; i++)
            {
                //! each color gets the cost by adding the current cost of itself with minimum cost of other 2 colors from previous row
                dp[i, 0] = costs[i - 1][0] + Math.Min(dp[i - 1, 1], dp[i - 1, 2]);
                dp[i, 1] = costs[i - 1][1] + Math.Min(dp[i - 1, 0], dp[i - 1, 2]);
                dp[i, 2] = costs[i - 1][2] + Math.Min(dp[i - 1, 0], dp[i - 1, 1]);
            }

            //! final row contains the minimum cost for every house ending in that color.
            return Math.Min(Math.Min(dp[r - 1, 0], dp[r - 1, 1]), dp[r - 1, 2]);
        }

        public int MinCost1(int[][] costs)
        {
            if (costs.Length == 0)
                return 0;
            int r = costs.GetLength(0);


            for (int i = 1; i < r; i++)
            {
                costs[i][0] += Math.Min(costs[i - 1][1], costs[i - 1][2]);
                costs[i][1] += Math.Min(costs[i - 1][0], costs[i - 1][2]);
                costs[i][2] += Math.Min(costs[i - 1][0], costs[i - 1][1]);
            }

            return Math.Min(Math.Min(costs[r - 1][0], costs[r - 1][1]), costs[r - 1][2]);
        }

    }
}
