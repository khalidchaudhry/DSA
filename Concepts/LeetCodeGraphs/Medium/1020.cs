using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1020
    {
        /// <summary>
        //! Question is very similar to 200 and 1254
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int NumEnclaves(int[][] A)
        {
            int rows = A.Length;
            int columns = A[0].Length;
            int numEnclaves = 0;

            for (int i = 0; i < rows; ++i)
            {
                DFS(A, i, 0);//first Column
                DFS(A, i, columns - 1);//last  Column
            }
            for (int j = 0; j < columns; ++j)
            {
                DFS(A, 0, j);//first row
                DFS(A, rows - 1, j);//last  row
            }
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    if (A[i][j] == 1)
                    {
                        numEnclaves += DFS(A, i, j);
                    }
                }
            }

            return numEnclaves;
        }

        private int DFS(int[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length ||
                j < 0 || j >= grid[0].Length ||
                grid[i][j] != 1)
            {
                return 0;
            }

            grid[i][j] = 0;

            int toReturn = 1 + DFS(grid, i - 1, j) +
                             DFS(grid, i + 1, j) +
                             DFS(grid, i, j - 1) +
                             DFS(grid, i, j + 1);

            return toReturn;
        }
    }
}
