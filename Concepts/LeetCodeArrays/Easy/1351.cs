using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    public class _1351
    {

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



    }
}
