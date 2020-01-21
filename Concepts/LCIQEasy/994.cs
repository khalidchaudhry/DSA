using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCIQEasy
{
    class _994
    {
        public int OrangesRotting(int[][] grid)
        {
            for (int row = 0; row < grid.Length; row++)
            {
                Console.WriteLine($"Row number:{row}");
                for (int col = 0;col < grid[row].Length; col++)
                {
                    Console.Write($"{grid[row][col]} ");
                    
                }
                Console.WriteLine();
            }
            return 0;
        }

       
    }
}
