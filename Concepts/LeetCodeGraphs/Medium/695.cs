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
            int maxArea = 0;

            for (int i = 0; i < grid.Length; ++i)
            {
                for (int j = 0; j < grid[0].Length; ++j)
                {
                    if (grid[i][j] == 1)
                    {
                        int area = DFS(grid, i, j);
                        maxArea = Math.Max(area, maxArea);
                    }
                }
            }

            return maxArea;
        }

        private int DFS(int[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] != 1)
            {
                return 0;
            }

            grid[i][j] = 0;

            return 1 +
                   DFS(grid, i - 1, j) +
                   DFS(grid, i + 1, j) +
                   DFS(grid, i, j - 1) +
                   DFS(grid, i, j + 1);
        }
    }
}
