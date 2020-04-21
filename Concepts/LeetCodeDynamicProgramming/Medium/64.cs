using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _64
    {
        public int MinPathSum(int[][] grid)
        {
            if (grid.Length == 0)
                return 0;

            int rows = grid.Length;
            int columns = grid[0].Length;

            int[][] dp = new int[rows][];
            for (var i = 0; i < rows; i++)
            {
                dp[i] = new int[columns];
            }

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (r == 0 && c == 0)
                    {
                        dp[r][c] = grid[r][c];
                    }
                    else if (r == 0)
                        dp[r][c] = grid[r][c] + dp[r][c - 1];
                    else if (c == 0)
                        dp[r][c] = grid[r][c] + dp[r - 1][c];
                    else
                        dp[r][c] = grid[r][c] + Math.Min(dp[r - 1][c], dp[r][c - 1]);
                }
            }

            return dp[rows-1][columns-1];
        }


    }
}
