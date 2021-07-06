using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder.Entities
{
    public class Board
    {
        int[,] _board;
        public Board(int r,int c)
        {
            _board = new int[r, c];
        }
    }
}
