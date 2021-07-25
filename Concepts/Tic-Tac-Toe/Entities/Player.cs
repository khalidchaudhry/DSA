using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe.Entities
{
    public class Player
    {
        public string PlayerName { get; }
        public char PlayerSymbol { get; }
        public HashSet<Position> PlayerPositions { get; }


        public Player(string playerName,char playerSymbol)
        {
            PlayerName = playerName;
            PlayerSymbol = playerSymbol;
            PlayerPositions = new HashSet<Position>();
        }
        public void AddPosition(int row, int col)
        {
            PlayerPositions.Add(new Position(row,col));
        }


    }
}
