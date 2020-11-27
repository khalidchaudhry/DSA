using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _694
    {
        public static void _694Main()
        {
            int[][] grid = new int[4][]
             {
                 new int[]{1,1,0,0,0},
                 new int[]{1,1,0,0,0},
                 new int[]{0,0,0,1,1},
                 new int[]{0,0,0,1,1 }
             };

            _694 Islands = new _694();
            Islands.NumDistinctIslands(grid);

        }
        /// <summary>
        //!Time complexity=O(r*c) r =Number of rows c=NumberOf Columns??
        //! Space Complexity=O(r*c)
        /// </summary>     
        public int NumDistinctIslands(int[][] grid)
        {
            HashSet<string> paths = new HashSet<string>();

            for (int i = 0; i < grid.Length; ++i)
            {
                for (int j = 0; j < grid[0].Length; ++j)
                {
                    if (grid[i][j] == 1)
                    {
                        StringBuilder path = new StringBuilder();
                        DFS(grid, i, j, path);
                        paths.Add(path.ToString());
                    }
                }
            }

            return paths.Count;
        }

        private void DFS(int[][] grid, int i, int j, StringBuilder path)
        {
            if (i < 0 || i >= grid.Length ||
                j < 0 || j >= grid[0].Length ||
                grid[i][j] != 1)
            {
                return;
            }
            //! Marking it as 0 equivalent to creating visited array
            grid[i][j] = 0;

            DFS(grid, i - 1, j, path.Append('U'));
            DFS(grid, i + 1, j, path.Append('D'));
            DFS(grid, i, j - 1, path.Append('L'));
            DFS(grid, i, j + 1, path.Append('R'));
        }       
    }
}
