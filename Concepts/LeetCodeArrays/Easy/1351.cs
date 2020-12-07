using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    public class _1351
    {
        /// <summary>
        //! Time Complexity= O(m+n) 
        /// </summary>
       public int CountNegatives(int[][] grid)
        {
            int rows = grid.Length;
            int columns = grid[0].Length;
            int negativesCount = 0;
            for (int row = 0; row < rows; ++row)
            {
                for (int column = columns - 1; column >= 0; --column)
                {
                    if (grid[row][column] >= 0)
                        break;
                    ++negativesCount;
                }
            }

            return negativesCount;
        }

        /// <summary>
        //! using binary Search
        //! Time complexity=O(mlogn) where m number of rows and and n are number of columns 
        /// </summary>
       
        public int CountNegatives2(int[][] grid)
        {

            int rows = grid.Length;
            int result = 0;
            for (int i = 0; i < rows; ++i)
            {
                int lo = -1;
                int hi = grid[i].Length - 1;

                while (lo + 1 < hi)
                {
                    int mid = lo + (hi - lo) / 2;

                    if (OK(grid, i, mid))
                    {
                        hi = mid;
                    }
                    else
                    {
                        lo = mid;
                    }
                }

                if (grid[i][hi] < 0)
                {
                    result += grid[i].Length - hi;
                }
            }

            return result;
        }
        private bool OK(int[][] grid, int row, int mid)
        {
            return grid[row][mid] < 0 ? true : false;
        }




    }
}
