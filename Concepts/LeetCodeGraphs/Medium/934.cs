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
        //! Time Complexity: O(rc(r+c)) where r number of rows and c=number of columns
        //! Space Complexity=O(rc) 
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
        private int ComputeMinimumFlips(int[][] A)
        {
            int rows = A.Length;
            int columns = A[0].Length;

            HashSet<(int r, int c)> visited = new HashSet<(int r, int c)>();
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    if (A[i][j] == 2)
                    {
                        queue.Enqueue((i, j));
                        visited.Add((i, j));
                    }
                }
            }

            int level = 0;
            while (queue.Count != 0)
            {
                int count = queue.Count;
                while (count != 0)
                {
                    (int r, int c) = queue.Dequeue();
                    if (A[r][c] == 1)
                    {
                        //! smallest flips will not include the level we start from
                        return level - 1;
                    }
                    foreach ((int nr, int nc) in GetNeighbors(r, c))
                    {
                        if (IsOutOfBound(A, nr, nc) || visited.Contains((nr, nc)))
                            continue;

                        visited.Add((nr, nc));
                        queue.Enqueue((nr, nc));

                    }
                    --count;
                }
                ++level;
            }
            return level;
        }
        private void DFS(int[][] A, int r, int c)
        {
            if (IsOutOfBound(A, r, c) || A[r][c] != 1)
                return;

            A[r][c] = 2;
            foreach ((int nr, int nc) in GetNeighbors(r, c))
            {
                DFS(A, nr, nc);
            }
        }

        private bool IsOutOfBound(int[][] A, int r, int c)
        {
            return r < 0 || r >= A.Length || c < 0 || c >= A[0].Length;
        }

        private List<(int nr, int nc)> GetNeighbors(int r, int c)
        {
            List<(int nr, int nc)> neighbors = new List<(int nr, int nc)>();
            foreach ((int nr, int nc) in new List<(int nr, int nc)>() { (r + 1, c), (r - 1, c), (r, c + 1), (r, c - 1) })
            {
                neighbors.Add((nr, nc));
            }

            return neighbors;
        }
    }
}
