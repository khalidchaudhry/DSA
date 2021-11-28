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
        //! Hash By Path Signature
        //!Time complexity=O(r*c) r =Number of rows c=NumberOf Columns??
        //! Space Complexity=O(r*c)
        ///  // # <image url="$(SolutionDir)\Images\694.png"  scale="0.4"/>
        /// </summary>     
        public int NumDistinctIslands(int[][] grid)
        {
            HashSet<string> paths = new HashSet<string>();

            for (int r = 0; r < grid.Length; ++r)
            {
                for (int c = 0; c < grid[0].Length; ++c)
                {
                    if (grid[r][c] == 1)
                    {
                        StringBuilder path = new StringBuilder();
                        DFS(grid, r, c, path);
                        paths.Add(path.ToString());
                    }
                }
            }

            return paths.Count;
        }

        private void DFS(int[][] grid, int r, int c, StringBuilder path)
        {
            if (IsOutOfBound(grid, r, c))
            {
                return;
            }
            //! Marking it as 0 equivalent to creating visited array
            grid[r][c] = 0;

            DFS(grid, r - 1, c, path.Append('U'));
            DFS(grid, r + 1, c, path.Append('D'));
            DFS(grid, r, c - 1, path.Append('L'));
            DFS(grid, r, c + 1, path.Append('R'));
        }
        private bool IsOutOfBound(int[][] grid, int r, int c)
        {
            return r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length;
        }
    }
}
