using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe.Entities;
using Tic_Tac_Toe.Services.Interfaces;

namespace Tic_Tac_Toe.Services
{
    public class GameManager
    {
        private Board _board;
        private IPrint _print;
        public GameManager(Board board, IPrint print)
        {
            _print = print;
            _board = board;
        }

        public void InitBoard()
        {
            _board.Initialize(_board.Size);
        }

        public bool MovePlayer(char playerSymbol, int[] position)
        {
            int r = position[0];
            int c = position[1];
            
            if (r >= _board.Size || c >= _board.Size || _board.GetGirdCellValue(r, c) != '-')
            {
                _print.Print("Invalid Move");
                return false;
            }
            _board.SetGirdCellValue(r, c, playerSymbol);
            _print.Print(_board.GetGrid());

            return true;
        }
        public bool IsGameOver(string playerName,int r,int c)
        {
            if (r >= _board.Size || c >= _board.Size)
                return false;

            if (_board.IsWinner(r, c))
            {
                _print.Print($"{playerName} won the game");
                return true;
            }
            else if (!_board.IsCellLeft())
            {
                _print.Print("exit");
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
