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
        /// https://medium.com/leetcode-patterns/leetcode-pattern-1-bfs-dfs-25-of-the-problems-part-1-519450a84353
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands(char[][] grid)
        {
            int result = 0;

            for (int x = 0; x < grid.Length; x++)
            {
                for (int y = 0; y < grid[x].Length; y++)
                {
                    if (grid[x][y] == '1')
                    {
                        ++result;
                        DFS(grid, x, y);
                    }
                }
            }

            return result;
        }

        private void DFS(char[][] grid, int x, int y)
        {
            //! out of bound and not visited check
            if (x < 0 || x >= grid.Length || y < 0 || y >= grid[x].Length || grid[x][y] != '1')
            {
                return;
            }

            grid[x][y] = '*';

            DFS(grid, x, y + 1);// right
            DFS(grid, x, y - 1);//left
            DFS(grid, x + 1, y);//up
            DFS(grid, x - 1, y);//down

        }
    }
}
