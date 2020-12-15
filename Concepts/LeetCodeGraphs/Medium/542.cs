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
        /// </summary>        
        public int[][] UpdateMatrix(int[][] matrix)
        {
            HashSet<(int x, int y)> visited = new HashSet<(int x, int y)>();
            Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
            InitializeQueue(matrix, queue, visited);
            while (queue.Count != 0)
            {
                (int row, int column) = queue.Dequeue();

                foreach ((int x, int y) in GetNeighbors(matrix, row, column))
                {
                    if (!visited.Contains((x, y)) && matrix[x][y] != 0)
                    {
                        visited.Add((x, y));
                        matrix[x][y] = matrix[row][column] + 1;
                        queue.Enqueue((x, y));
                    }
                }
            }
            return matrix;

        }
        private void InitializeQueue(int[][] matrix,
                                Queue<(int x, int y)> queue,
                                HashSet<(int x, int y)> visited)
        {
            for (int i = 0; i < matrix.Length; ++i)
            {
                for (int j = 0; j < matrix[0].Length; ++j)
                {
                    if (matrix[i][j] == 0)
                    {
                        queue.Enqueue((i, j));
                        visited.Add((i, j));
                    }
                }
            }
        }
        private IEnumerable<(int, int)> GetNeighbors(int[][] matrix, int row, int column)
        {
            foreach ((int x, int y) in new List<(int, int)>(){
                                                        (row-1,column),(row+1,column),
                                                        (row,column+1),(row,column-1)
                                                       }
                                                           )
            {
                if (x >= 0 && x < matrix.Length && y >= 0 && y < matrix[0].Length)
                    yield return (x, y);
            }
        }
    }
}
