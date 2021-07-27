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

        public void MovePlayer(PlayerInfo playerInfo, int row, int col)
        {
            _board.SetGirdCellValue(playerInfo, row, col);
            _print.Print(_board.GetGridData());           
        }
        public bool IsGameOver(PlayerInfo playerInfo, int r, int c)
        {
            if (_board.IsWinner(playerInfo.PlayerId, r, c))
            {
                _print.Print($"{playerInfo.PlayerName} won the game");
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
