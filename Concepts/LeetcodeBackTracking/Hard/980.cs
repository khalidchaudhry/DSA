using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Hard
{
    public class _980
    {
        public int UniquePathsIII(int[][] grid)
        {

            int r = grid.Length;
            int c = grid[0].Length;
            int pathLen = PathLength(grid);
            for (int i = 0; i < r; ++i)
            {
                for (int j = 0; j < c; ++j)
                {
                    if (grid[i][j] == 1)
                    {
                        return UniquePaths(grid, i, j, pathLen);
                    }
                }
            }

            return 0;
        }

        private int PathLength(int[][] grid)
        {
            int r = grid.Length;
            int c = grid[0].Length;

            int nodesCount = 0;
            for (int i = 0; i < r; ++i)
            {
                for (int j = 0; j < c; ++j)
                {
                    if (grid[i][j] != -1)
                    {
                        ++nodesCount;
                    }
                }
            }
            return nodesCount - 1;
        }

        private int UniquePaths(int[][] grid, int r, int c, int pathLen)
        {
            if (IsOutOfBound(grid, r, c) || grid[r][c] == -1)
            {
                return 0;
            }

            if (grid[r][c] == 2)
            {
                if (pathLen == 0)
                    return 1;
                else
                    return 0;
            }

            int prevValue = grid[r][c];
            grid[r][c] = -1;

            int count = 0;
            foreach ((int nr, int nc) in GetNeighbors(r, c))
            {
                count += UniquePaths(grid, nr, nc, pathLen - 1);
            }

            grid[r][c] = prevValue;

            return count;
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
