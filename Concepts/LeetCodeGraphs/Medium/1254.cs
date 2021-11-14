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
        //! out of bound cells are surronded by land(0) and not water 
        //https://leetcode.com/problems/number-of-closed-islands/discuss/479506/Java-Super-Straightforward-DFS-Solution-with-explanation-with-Two-Pass.-Beat-100
        /// </summary>      
        public int ClosedIsland(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            //For first row and last row
            for (int c = 0; c < cols; ++c)
            {
                DFS(grid, 0, c);
                DFS(grid, rows - 1, c);
            }

            //For first col and last column
            for (int r = 0; r < rows; ++r)
            {
                DFS(grid, r, 0);
                DFS(grid, r, cols - 1);
            }

            int closedIslandCount = 0;
            for (int r = 0; r < rows; ++r)
            {
                for (int c = 0; c < cols; ++c)
                {
                    if (grid[r][c] == 0)
                    {
                        ++closedIslandCount;
                        DFS(grid, r, c);
                    }
                }
            }
            return closedIslandCount;
        }
        private void DFS(int[][] grid, int r, int c)
        {
            if (IsOutOfBound(grid, r, c) || grid[r][c] != 0)
            {
                return;
            }
            grid[r][c] = 2; //!marked with some value so that we don't process them 
            foreach ((int nr, int nc) in GetNeighbors(r, c))
            {
                DFS(grid, nr, nc);
            }
        }
        private bool IsOutOfBound(int[][] grid, int r, int c)
        {
            return r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length;
        }

        private List<(int nr, int nc)> GetNeighbors(int r, int c)
        {
            List<(int nr, int nc)> neighbors = new List<(int nr, int nc)>();

            foreach ((int nr, int nc) in new List<(int nr, int nc)> { (r + 1, c), (r - 1, c), (r, c + 1), (r, c - 1) })
            {
                neighbors.Add((nr, nc));
            }
            return neighbors;
        }
    }
}
