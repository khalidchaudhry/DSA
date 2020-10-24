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
            int columns = grid[0].Length;
            bool[][] visited = new bool[rows][];
            for (int i = 0; i < rows; ++i)
            {
                visited[i] = new bool[columns];
            }

            Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    if (grid[i][j] == 1)
                    {
                        queue.Enqueue((i, j));
                        visited[i][j] = true;
                    }
                }
            }

            //! when all the cells are zero or 1 then we cant have distance at all.
            if (queue.Count() == 0 || queue.Count == rows * columns) return -1;

            List<(int x, int y)> directions = new List<(int x, int y)>()
            {
                (-1,0),
                (1,0),
                (0,-1),
                (0,1)
            };
            int level = 0;
            while (queue.Count != 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; ++i)
                {
                    (int x, int y) = queue.Dequeue();

                    foreach ((int dx, int dy) in directions)
                    {
                        int nx = x + dx;
                        int ny = y + dy;
                        if (nx >= 0 && nx < rows && ny >= 0 && ny < columns && grid[nx][ny] == 0 && !visited[nx][ny])
                        {
                            visited[nx][ny] = true;
                            queue.Enqueue((nx, ny));
                        }
                    }
                }
                //!As Manhattan distance is defined, we can get the distance of two node 0 and node 1 if we do BFS from
                //!node 1 and count level number as we go to node 0.Manhattan distance is nothing but the level
                //!count of BFS from one node to another node considering only up, left, top, down neighbours.
                ++level;
            }

            return level - 1;
        }
    }
}
