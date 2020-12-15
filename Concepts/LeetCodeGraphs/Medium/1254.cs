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
            SetBoundries(grid);
            int closedIslands = 0;
            for (int i = 0; i < grid.Length; ++i)
            {
                for (int j = 0; j < grid[0].Length; ++j)
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
        private void SetBoundries(int[][] grid)
        {
            int rows = grid.Length;
            int columns = grid[0].Length;
            //! Setting boundries column in grid equal to 1
            for (int i = 0; i < rows; ++i)
            {
                if (grid[i][0] == 0)
                    DFS(grid, i, 0);

                if (grid[i][columns - 1] == 0)
                    DFS(grid, i, columns - 1);
            }
            //! Setting boundries rows in grid equal to 1
            for (int i = 0; i < columns; ++i)
            {
                if (grid[0][i] == 0)
                    DFS(grid, 0, i);

                if (grid[rows - 1][i] == 0)
                    DFS(grid, rows - 1, i);
            }
        }
        private void DFS(int[][] grid, int row, int column)
        {
            if (grid[row][column] != 0)
                return;

            grid[row][column] = 1;
            foreach ((int nr, int nc) in GetNeighbors(grid, row, column))
            {
                DFS(grid, nr, nc);
            }
        }
        private IEnumerable<(int, int)> GetNeighbors(int[][] grid, int row, int column)
        {
            foreach ((int nr, int nc) in new List<(int, int)>{(row+1,column),(row-1,column),
                                                      (row,column+1),(row,column-1)})
            {
                if (nr >= 0 && nr < grid.Length && nc >= 0 && nc < grid[0].Length)
                {
                    yield return (nr, nc);
                }
            }
        }


    }
}
