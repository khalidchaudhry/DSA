using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _200
    {
        /// <summary>
        //! Time complexity=O(m*n) where m are number of rows and c are number of columns
        //! Space=O(1)
        /// </summary>
        public int NumIslands(char[][] grid)
        {
            int r = grid.Length;
            int c = grid[0].Length;

            int islandsCount = 0;
            for (int i = 0; i < r; ++i)
            {
                for (int j = 0; j < c; ++j)
                {
                    if (grid[i][j] == '1')
                    {
                        ++islandsCount;
                        DFS(i, j, grid);
                    }
                }
            }
            return islandsCount;
        }

        private void DFS(int i, int j, char[][] grid)
        {
            if (IsOutOfBound(i, j, grid) || grid[i][j] == '0')
                return;

            grid[i][j] = '0';

            foreach ((int nr, int nc) in GetNeighbors(i, j))
            {
                DFS(nr, nc, grid);
            }
        }
        private bool IsOutOfBound(int i, int j, char[][] grid)
        {
            return i >= grid.Length || i < 0 || j >= grid[0].Length || j < 0;
        }

        private List<(int nr, int nc)> GetNeighbors(int r, int c)
        {
            List<(int nr, int nc)> neighbors = new List<(int nr, int nc)>();
            foreach ((int nr, int nc) in new List<(int nr, int nc)>() { (r + 1, c), (r - 1, c), (r, c + 1), (r, c - 1) })
            {
                neighbors.Add((nr, nc));
            }

            return neighbors;
        }
    }
}
