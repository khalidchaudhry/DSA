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
            return ComputeMinimumFlips(A);
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
                        return; //! return it not break
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

        private int ComputeMinimumFlips(int[][] A)
        {
            Queue<(int x, int y)> queue = new Queue<(int x, int y)>();

            bool[][] visited = new bool[A.Length][];
            InitializeVisited(visited, A[0].Length);

            InitilaizeQueue(queue, A, visited);
            //! Level order traversal
            int level = 0;
            while (queue.Count != 0)
            {
                int count = queue.Count;
                while (count != 0)
                {
                    (int x, int y) = queue.Dequeue();

                    if (A[x][y] == 1)
                    {
                        // smallest flips will not include the level we start from
                        return level - 1;
                    }
                    foreach ((int dx, int dy) in GetDirections())
                    {
                        int nx = x + dx;
                        int ny = y + dy;

                        if (nx < 0 && nx >= A.Length && ny < 0 && ny >= A[0].Length && visited[nx][ny])
                        {
                            continue;
                        }
                        visited[nx][ny] = true;
                        queue.Enqueue((nx, ny));

                    }
                    --count;
                }

                ++level;
            }

            return level;
        }

        private void InitilaizeQueue(Queue<(int, int)> queue, int[][] A, bool[][] visited)
        {
            for (int i = 0; i < A.Length; ++i)
            {
                for (int j = 0; j < A[0].Length; ++j)
                {
                    //! we are queueing cells with value=2
                    if (A[i][j] == 2)
                    {
                        queue.Enqueue((i, j));
                        visited[i][j] = true;
                    }
                }
            }
        }

        private void InitializeVisited(bool[][] visited, int columns)
        {
            for (int i = 0; i < visited.Length; ++i)
            {
                visited[i] = new bool[columns];
            }
        }

        private List<(int x, int y)> GetDirections()
        {
            List<(int x, int y)> directions = new List<(int x, int y)>();
            directions.Add((-1, 0));
            directions.Add((1, 0));
            directions.Add((0, 1));
            directions.Add((0, -1));

            return directions;

        }
    }
}
