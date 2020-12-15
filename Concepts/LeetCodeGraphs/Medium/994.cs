using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    class _994
    {
        public static void _994Main()
        {

            _994 OrangeRotting = new _994();

            int[][] grid = new int[3][]
                {
                    new int[]{2,1,1},
                    new int[]{1,1,0 },
                    new int[]{0,1,1 }

                };

            var ans = OrangeRotting.OrangesRotting(grid);
            Console.ReadLine();

        }
        /// <summary>
        /// https://www.youtube.com/watch?v=CxrnOTUlNJE
        /// </summary>

        public int OrangesRotting(int[][] grid)
        {
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            Queue<(int, int)> queue = new Queue<(int, int)>();
            //! important to keep track of fresh oranges. 
            int freshOranges = SetUp(queue, visited, grid);
            //!If no fresh oranges then we can immediately return 0 as it will take 0 minutes to rotten all the oranges  
            if (freshOranges == 0) return 0;

            int minutes = 0;
            while (queue.Count != 0)
            {
                int count = queue.Count;
                bool isRotten = false;
                while (count != 0)
                {
                    (int row, int column) = queue.Dequeue();
                    foreach ((int x, int y) in GetNeighbors(grid, row, column))
                    {
                        if (!visited.Contains((x, y)))
                        {
                            //! rather than decremeting , we can also check later on by iterating 2d matrix again.
                            //! since we already have count of fresh oranges , ite good idea to keep track of it
                            --freshOranges;
                            isRotten = true;
                            grid[x][y] = 2;
                            visited.Add((x, y));
                            queue.Enqueue((x, y));
                        }
                    }
                    --count;
                }
                if (isRotten)
                    ++minutes;
            }
            return freshOranges == 0 ? minutes : -1;
        }
        private IEnumerable<(int, int)> GetNeighbors(int[][] grid, int row, int column)
        {
            foreach ((int i, int j) in new List<(int, int)>() { (row + 1, column), (row - 1, column), (row, column + 1), (row, column - 1) })
            {
                if (i >= 0 && i < grid.Length && j >= 0 && j < grid[0].Length)
                {
                    yield return (i, j);
                }
            }
        }

        private int SetUp(Queue<(int, int)> queue, HashSet<(int, int)> visited, int[][] grid)
        {
            int freshOranges = 0;
            for (int i = 0; i < grid.Length; ++i)
            {
                for (int j = 0; j < grid[0].Length; ++j)
                {
                    if (grid[i][j] == 0)
                    {
                        visited.Add((i, j));
                    }
                    if (grid[i][j] == 1)
                        ++freshOranges;

                    if (grid[i][j] == 2)
                    {
                        visited.Add((i, j));
                        queue.Enqueue((i, j));
                    }
                }
            }
            return freshOranges;
        }

    }
}
