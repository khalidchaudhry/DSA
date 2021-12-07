using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _542
    {

        /// <summary>
        ///  // # <image url="$(SolutionDir)\Images\542.png"  scale="0.5"/>
        /// https://www.youtube.com/watch?v=UWykmfK7ta4
        //! Same pattern in question 286
        //! Time=O(r*c)
        //! Space=O(r*c)
        /// </summary>        
        public int[][] UpdateMatrix(int[][] matrix)
        {
            int rows = matrix.Length;
            int columns = matrix[0].Length;
            HashSet<(int r, int c)> visited = new HashSet<(int r, int c)>();
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    if (matrix[i][j] == 0)
                    {
                        queue.Enqueue((i, j));
                        visited.Add((i, j));
                    }
                }
            }


            while (queue.Count != 0)
            {
                (int r, int c) = queue.Dequeue();

                foreach ((int nr, int nc) in GetNeighbors(r, c))
                {
                    if (IsOutOfBound(matrix, nr, nc) || visited.Contains((nr, nc)))
                    {
                        continue;
                    }
                    matrix[nr][nc] = matrix[r][c] + 1;
                    visited.Add((nr, nc));
                    queue.Enqueue((nr, nc));
                }
            }

            return matrix;

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
        private bool IsOutOfBound(int[][] matrix, int r, int c)
        {
            return r < 0 || r >= matrix.Length || c < 0 || c >= matrix[0].Length;
        }


    }
}
