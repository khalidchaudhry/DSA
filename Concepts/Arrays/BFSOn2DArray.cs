using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class BFSOn2DArray
    {

        public void BFS(int[,] matrix)
        {
            int length = matrix.GetLength(0);
            bool[,] visited = new bool[length, length];
            Queue<string> queue = new Queue<string>();

            queue.Enqueue($"{0},{0}");

            while (queue.Count != 0)
            {
                // First index row and second index column 
                string[] dequeue = queue.Dequeue().Split(',');
                int row = int.Parse(dequeue[0]);
                int column = int.Parse(dequeue[1]);

                if (
                    row < 0 ||
                    column < 0 ||
                    row >= length||
                    column >= length ||
                    visited[row, column]
                    )
                {
                    continue;
                }

                visited[row, column] = true;
                Console.Write($"{matrix[row,column]} ");
                queue.Enqueue($"{row},{column - 1}");// left side
                queue.Enqueue($"{row},{column + 1}");// right side
                queue.Enqueue($"{row-1},{column}");// up 
                queue.Enqueue($"{row+1},{column}");// down
            }


        }

    }
}
