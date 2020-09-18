using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _64
    {



        public int MinPathSum0(int[][] grid)
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

            return dp[rows - 1][columns - 1];
        }


        /// <summary>
        //! DP solution build on the brute force solution idea
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinPathSum1(int[][] grid)
        {
            int rows = grid.Length;
            if (rows == 0)
                return 0;
            int columns = grid[0].Length;

            int[][] dp = new int[rows + 1][];

            for (int i = 0; i < dp.Length; ++i)
            {
                dp[i] = new int[columns + 1];
            }

            //!initializing first row with Int.MaxValue
            for (int i = 0; i <= columns; ++i)
            {
                dp[0][i] = int.MaxValue;
            }
            //!initializing first column with Int.MaxValue
            for (int i = 0; i <= rows; ++i)
            {
                dp[i][0] = int.MaxValue;
            }

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    //! without this condition we will have max from up and left for 0,0
                    if (i == 0 && j == 0)
                    {
                        dp[i + 1][j + 1] = grid[i][j];
                    }
                    else
                    {
                        dp[i + 1][j + 1] = grid[i][j] +
                                   Math.Min(dp[i][j + 1],  //!Up
                                              dp[i + 1][j]); //!left
                    }
                }
            }
            //! last column and last row will contain the minpath sum
            return dp[rows][columns];
        }

        /// <summary>
        //! Brute Force approach        
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinPathSum2(int[][] grid)
        {
            if (grid.Length == 0)
                return 0;
            return MinPathSum2(grid, 0, 0);
        }

        private int MinPathSum2(int[][] grid, int i, int j)
        {
            //! if out of bound, we are returning max as in main body we are using min
            if (i == grid.Length || j == grid[0].Length)
                return int.MaxValue;
            //! Reach to the bottom right cell and we will return that cell value
            if (i == grid.Length - 1 && j == grid[0].Length - 1)
                return grid[i][j];
            return grid[i][j] +
                   Math.Min(MinPathSum2(grid, i, j + 1), //!going right 
                            MinPathSum2(grid, i + 1, j));  //! going down
        }
    }
}

