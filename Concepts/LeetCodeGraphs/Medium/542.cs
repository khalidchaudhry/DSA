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
        /// https://www.youtube.com/watch?v=UWykmfK7ta4
        /// </summary>        
        public int[][] UpdateMatrix(int[][] matrix)
        {

            Queue<(int, int)> queue = new Queue<(int, int)>();

            bool[][] visited = new bool[matrix.Length][];            
            for (int i = 0; i < visited.Length; ++i)
            {
                visited[i] = new bool[matrix[0].Length];
            }

            //!Push all matrix cell with zero value to the queue
            for (int i = 0; i < matrix.Length; ++i)
            {
                for (int j = 0; j < matrix[0].Length; ++j)
                {
                    if (matrix[i][j] == 0)
                    {
                        visited[i][j] = true;
                        queue.Enqueue((i, j));
                    }
                }
            }
            //! Queue not visisted neighbours and assign them new value by incrementing 1 to existing cell value. 
            while (queue.Count != 0)
            {
                (int x, int y) = queue.Dequeue();

                int rowAbove = x - 1;
                int rowBelow = x + 1;
                int columnRight = y + 1;
                int columnLeft = y - 1;
                
                //!Push top neighbour 
                if (
                    rowAbove >= 0 &&                    
                    !visited[rowAbove][y]
                    )
                {
                    visited[rowAbove][y] = true;
                    matrix[rowAbove][y] = matrix[x][y] + 1;
                    queue.Enqueue((rowAbove, y));
                }

                //!Push below neighbour 
                if (                    
                    rowBelow < matrix.Length &&
                    !visited[rowBelow][y]
                    )
                {
                    visited[rowBelow][y] = true;
                    matrix[rowBelow][y] = matrix[x][y] + 1;
                    queue.Enqueue((rowBelow, y));
                }

                //!Push left neighbour 
                if (
                    columnLeft >= 0 &&
                    !visited[x][columnLeft]
                    )
                {
                    visited[x][columnLeft] = true;
                    matrix[x][columnLeft] = matrix[x][y] + 1;
                    queue.Enqueue((x, columnLeft));
                }

                //!Push right neihgbour 
                if (
                    columnRight < matrix[0].Length &&
                    !visited[x][columnRight]
                    )
                {
                    visited[x][columnRight] = true;
                    matrix[x][columnRight] = matrix[x][y] + 1;
                    queue.Enqueue((x, columnRight));
                }

            }

            return matrix;
        }
    }
}
