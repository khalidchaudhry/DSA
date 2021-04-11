using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1162
    {
        public int MaxDistance(int[][] grid)
        {
            int rows = grid.Length;
            int columns = rows;

            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            HashSet<(int r, int c)> visited = new HashSet<(int r, int c)>();

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    if (grid[i][j] == 1)
                    {
                        queue.Enqueue((i, j));
                        visited.Add((i, j));
                    }
                }
            }
            //! when all the cells are zero or 1 then we cant have distance at all.
            if (queue.Count == 0 || queue.Count == rows * columns)
                return -1;

            int level = 0;
            while (queue.Count != 0)
            {
                int count = queue.Count;
                while (count != 0)
                {
                    (int r, int c) = queue.Dequeue();
                    foreach ((int nr, int nc) in GetNeighbors(r, c))
                    {
                        if (IsOutOfBound(grid, nr, nc) || visited.Contains((nr, nc)))
                            continue;

                        queue.Enqueue((nr, nc));
                        visited.Add((nr, nc));
                    }
                    --count;
                }
                //!As Manhattan distance is defined, we can get the distance of two node 0 and node 1 if we do BFS from
                //!node 1 and count level number as we go to node 0.Manhattan distance is nothing but the level
                //!count of BFS from one node to another node considering only up, left, top, down neighbours.
                ++level;
            }

            return level - 1;
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

        private bool IsOutOfBound(int[][] grid, int r, int c)
        {
            return r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length;
        }
    }
}
