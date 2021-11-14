using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _695
    {
        public int MaxAreaOfIsland(int[][] grid)
        {

            int r = grid.Length;
            int c = grid[0].Length;
            int maxArea = 0;
            for (int i = 0; i < r; ++i)
            {
                for (int j = 0; j < c; ++j)
                {
                    int area = DFS(grid, i, j);
                    maxArea = Math.Max(area, maxArea);

                }
            }
            return maxArea;
        }

        private int DFS(int[][] grid, int r, int c)
        {
            if (IsOutOfBound(grid, r, c) || grid[r][c] == 0)
                return 0;

            grid[r][c] = 0;
            //!Adding DFS result to area will give us the max area we can get
            int area = 1;
            foreach ((int nr, int nc) in GetNeighbors(r, c))
            {
                area += DFS(grid, nr, nc);
            }
            return area;
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
