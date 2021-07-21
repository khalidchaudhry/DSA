using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Services.Interfaces;

namespace TicTacToe.Services
{
    public class ConsolePrint : IPrint
    {

        public void Print(string str)
        {
            Console.WriteLine(str);
        }

        public void Print<T>(T[,] grid)
        {
            int n = grid.GetLength(0);
            for (int r = 0; r < n; ++r)
            {
                for (int c = 0; c < n; ++c)
                {
                    Console.Write($"{grid[r,c]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
