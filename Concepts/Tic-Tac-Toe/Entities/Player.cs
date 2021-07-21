using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Entities
{
    public class Player
    {
        public int PlayerId { get; private set; }
        public string PlayerName { get; private set; }
        public char PlayerSymbol { get; private set; }
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
        public int DiagonalCount { get; set; }
        public int AntiDiagonalCount { get; set; }

        public Player(int playerNumber,string playerName,char playerSymbol)
        {
            PlayerId = playerNumber;
            PlayerName = playerName;
            PlayerSymbol = playerSymbol;
        }
    }
}
