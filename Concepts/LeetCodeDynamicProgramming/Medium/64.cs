using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _64
    {


        /// <summary>
        //! Top down with memoization  
        /// </summary>
        public int MinPathSum(int[][] grid)
        {
            Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
            return MinPathSum(grid, 0, 0, memo);
        }

        private int MinPathSum(int[][] grid, int r, int c, Dictionary<(int, int), int> memo)
        {
            if (r >= grid.Length || c >= grid[0].Length)
            {
                return int.MaxValue;
            }

            if (r == grid.Length - 1 && c == grid[0].Length - 1)
            {
                return grid[r][c];
            }

            if (memo.ContainsKey((r, c)))
            {
                return memo[(r, c)];

            }

            //! right and down will never be out of bound at same time . One will be inbound atleast
            int right = MinPathSum(grid, r, c + 1, memo);
            int down = MinPathSum(grid, r + 1, c, memo);

            return memo[(r, c)] = grid[r][c] + Math.Min(down, right);
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

