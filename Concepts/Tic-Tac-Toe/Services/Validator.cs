using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Entities;

namespace TicTacToe.Services
{
    public static class Validator
    {

        public static bool IsInValidMove(int row, int col, Board board)
        {
            return (row >= board.Size || col >= board.Size || board.GetGirdCellValue(row, col) != '-');
        }
    }
}
