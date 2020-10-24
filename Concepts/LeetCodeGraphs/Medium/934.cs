using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _934
    {
        /// <summary>
        //! This problem is very similar to leetcode problem 994 and little bit similar with 542
        /// </summary>
        public int ShortestBridge(int[][] A)
        {
            //!Painting one of the island to 2 
            Paint(A);
            int rows = A.Length;
            int columns = A[0].Length;

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
                    //! we are queueing cells with value=2
                    if (A[i][j] == 2)
                    {
                        queue.Enqueue((i, j));
                        visited[i][j] = true;
                    }
                }
            }
            List<(int x, int y)> directions = new List<(int x, int y)>
                                              {
                                                (-1,0),//up
                                                (1,0),//down
                                                (0,-1),//left
                                                (0,1)//right
                                              };

            int level = 0;
            while (queue.Count != 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; ++i)
                {
                    (int x, int y) = queue.Dequeue();

                    if (A[x][y] == 1)
                    {
                        // smallest flips will not include the level we start from
                        return level - 1;
                                              
                    }

                    foreach ((int dx, int dy) in directions)
                    {
                        int nx = x + dx;
                        int ny = y + dy;

                        if (nx >= 0 && nx < rows && ny >= 0 && ny < columns && !visited[nx][ny])
                        {
                            visited[nx][ny] = true;
                            queue.Enqueue((nx, ny));
                        }
                    }
                }

                ++level;
            }

            return level;
        }


        private void Paint(int[][] A)
        {
            int rows = A.Length;
            int columns = A[0].Length;
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    //! turning the first island to 2 to distinguish it from other island(1)
                    if (A[i][j] == 1)
                    {
                        DFS(A, i, j);
                        return;
                    }
                }
            }
        }

        private void DFS(int[][] A, int i, int j)
        {
            if (i < 0 || i >= A.Length || j < 0 || j >= A[0].Length)
            {
                return;
            }
            A[i][j] = 2;

            DFS(A, i - 1, j);
            DFS(A, i + 1, j);
            DFS(A, i, j - 1);
            DFS(A, i, j + 1);
        }
    }
}
