using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Entities;
using TicTacToe.Services.Interfaces;

namespace TicTacToe.Services
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

        public void InitBoard(List<PlayerInfo> playersInfo)
        {
            _board.Initialize(playersInfo);
        }

        public bool MovePlayer(PlayerInfo playerInfo, int row,int col)
        {
          
            if (row >= _board.Size || col >= _board.Size || _board.GetGirdCellValue(row, col) != '-')
            {
                _print.Print("Invalid Move");
                return false;
            }
            _board.SetGirdCellValue(playerInfo, row, col);
            _print.Print(_board.GetGridData());

            return true;
        }
        public bool IsGameOver(string playerName, int r, int c)
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
