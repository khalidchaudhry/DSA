using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRecursion.Medium
{
    public class _1091
    {

        public static void _1091Main()
        {
            int[][] grid = new int[][]
            {
                new int[]{0,0,0 },
                new int[]{1,1,0 },
                new int[]{1,1,0 }
            };

            var test = new _1091();
            var result = test.ShortestPathBinaryMatrix(grid);
            Console.ReadLine();

        }
        /// <summary>
        //! Using BFS level order traversal  
        /// </summary>
        public int ShortestPathBinaryMatrix0(int[][] grid)
        {

            if (grid[0][0] == 1)
                return -1;


            int rows = grid.Length;
            int cols = grid[0].Length;
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            grid[0][0] = 1;
            queue.Enqueue((0, 0));

            int level = 0;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                while (count > 0)
                {
                    (int cr, int cc) = queue.Dequeue();
                    if (cr == rows - 1 && cc == cols - 1)
                    {
                        return level + 1;
                    }

                    foreach ((int nr, int nc) in GetNeighbors(cr, cc))
                    {
                        if (IsOutOfBound(grid, nr, nc) || grid[nr][nc] == 1)
                        {
                            continue;
                        }
                        grid[nr][nc] = 1;
                        queue.Enqueue((nr, nc));
                    }
                    --count;
                }
                ++level;
            }
            return -1;
        }
        /// <summary>
        //! gives TLE in leetcode  
        //! Memo will not work because it one neighbor may result in path which is not shortest
        /// </summary>
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            /*
                Shortest clear path in the matrix
                starts from (0,0) (n-1,n-1)        
            */
            int shortest = Solve(grid, 0, 0);
            return shortest == int.MaxValue ? -1 : shortest;
        }
        private int Solve(int[][] grid, int r, int c)
        {
            if (IsOutOfBound(grid, r, c) || grid[r][c] == 1)
            {
                return int.MaxValue;
            }

            if (r == grid.Length - 1 && c == grid[0].Length - 1)
            {
                return 1;
            }

            grid[r][c] = 1;
            int minNeighborValue = int.MaxValue;
            foreach ((int nr, int nc) in GetNeighbors(r, c))
            {
                minNeighborValue = Math.Min(minNeighborValue, Solve(grid, nr, nc));
            }
            grid[r][c] = 0;
            return minNeighborValue != int.MaxValue ? 1 + minNeighborValue : minNeighborValue;
        }
        private bool IsOutOfBound(int[][] grid, int r, int c)
        {
            return r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length;
        }

        private List<(int nr, int nc)> GetNeighbors(int r, int c)
        {
            List<(int nr, int nc)> neighbors = new List<(int nr, int nc)>();
            foreach ((int nr, int nc) in new List<(int nr, int nc)>() { (r - 1, c), (r + 1, c), (r, c - 1), (r, c + 1),
                                                                        (r - 1, c+1), (r+1, c-1), (r-1, c-1), (r+1, c+1) })
            {
                neighbors.Add((nr, nc));
            }
            return neighbors;
        }


    }
}
