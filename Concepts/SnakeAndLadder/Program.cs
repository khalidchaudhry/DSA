using SnakeAndLadder.Entities;
using SnakeAndLadder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(100);
            Dice dice = new Dice(6);
            GameRunner gameRunenr = new GameRunner(board, dice);
            ApplicationRunner runner = new ApplicationRunner(gameRunenr);
            runner.Run();

            Console.ReadKey();

        }
    }
}
