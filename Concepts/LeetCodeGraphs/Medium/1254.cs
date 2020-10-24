using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1254
    {
        /// <summary>
        //! Exactly like 200. Only difference is handling of boundary  case
        //https://leetcode.com/problems/number-of-closed-islands/discuss/479506/Java-Super-Straightforward-DFS-Solution-with-explanation-with-Two-Pass.-Beat-100
        /// </summary>      
        public int ClosedIsland(int[][] grid)
        {
            int rows = grid.Length;
            int columns = grid[0].Length;
            //0 is land 
            // 1 is water. 
            // we need to find out number of lands 
            //! marking border land cells and their neighbours equal to zero 
            //! since values outside the grids are lands

            //! marking first and last column
            for (int i = 0; i < rows; ++i)
            {
                DFS(grid, i, 0); //first column
                DFS(grid, i, columns - 1); //Last column
            }
            //! marking first and last row 
            for (int j = 0; j < columns; ++j)
            {
                DFS(grid, 0, j); //first row
                DFS(grid, rows - 1, j); //Last row
            }

            int closedIslands = 0;
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    if (grid[i][j] == 0)
                    {
                        ++closedIslands;
                        DFS(grid, i, j);
                    }
                }
            }

            return closedIslands;
        }

        private void DFS(int[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length ||
                j < 0 || j >= grid[0].Length ||
                grid[i][j] != 0
                )
            {
                return;
            }

            grid[i][j] = 1;

            DFS(grid, i - 1, j);
            DFS(grid, i + 1, j);
            DFS(grid, i, j - 1);
            DFS(grid, i, j + 1);

        }
    }
}
