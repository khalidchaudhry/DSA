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
            bool[][] visited = new bool[grid.Length][];
            for (int i = 0; i < visited.Length; ++i)
            {
                visited[i] = new bool[grid[0].Length];
            }
            Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
            //! Queue rotten oranges. Mark rotten and 0 as visited as visited and count freshOranges
            int freshOranges = SetUp(grid, visited, queue);

            if (freshOranges == 0) return 0;

            int time = 0;
            //! We are doing level order traversal because multiple oranges at different cell location can rotten their neighbour
            while (queue.Count != 0)
            {
                int count = queue.Count;
                bool rotten = false;
                while (count != 0)
                {
                    (int x, int y) = queue.Dequeue();

                    int rowAbove = x - 1;
                    int rowBelow = x + 1;
                    int columnRight = y + 1;
                    int columnLeft = y - 1;

                    if (rowAbove >= 0 && !visited[rowAbove][y])//!up 
                    {                        
                        visited[rowAbove][y] = true;
                        queue.Enqueue((rowAbove, y));
                        --freshOranges;
                        rotten = true;
                    }

                    if (rowBelow < grid.Length && !visited[rowBelow][y])//!down
                    {
                        visited[rowBelow][y] = true;
                        queue.Enqueue((rowBelow, y));
                        --freshOranges;
                        rotten = true;
                    }
                    if (columnRight < grid[0].Length && !visited[x][columnRight])//!right
                    {
                        visited[x][columnRight] = true;
                        queue.Enqueue((x, columnRight));
                        --freshOranges;
                        rotten = true;
                    }
                    if (columnLeft >= 0 && !visited[x][columnLeft])//!left
                    {                        
                        visited[x][columnLeft] = true;
                        queue.Enqueue((x, columnLeft));
                        --freshOranges;
                        rotten = true;
                    }

                    --count;
                }
                //! increment time if any orange rotten. 
                if (rotten)
                {
                    ++time;
                }
            }

            return freshOranges == 0 ? time : -1;
        }

        private int SetUp(int[][] grid, bool[][] visited, Queue<(int x, int y)> queue)
        {
            int freshOranges = 0;
            for (int i = 0; i < grid.Length; ++i)
            {
                for (int j = 0; j < grid[0].Length; ++j)
                {
                    //!Queue fresh oragnes as visited
                    if (grid[i][j] == 2)
                    {
                        visited[i][j] = true;
                        queue.Enqueue((i, j));
                    }
                    //!Mark walls as visited as we will never be able to reach to them
                    if (grid[i][j] == 0)
                    {
                        visited[i][j] = true;
                    }
                    //! counting freshing oranges as we need it later. 
                    if (grid[i][j] == 1)
                    {
                        ++freshOranges;
                    }
                }
            }
            return freshOranges;
        }
    }
}
