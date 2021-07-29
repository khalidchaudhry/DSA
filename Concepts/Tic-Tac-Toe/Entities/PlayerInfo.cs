using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Entities
{
    public class PlayerInfo
    {
        public int PlayerId { get;  set; }
        public string PlayerName { get; set; }
        public char PlayerSymbol { get; set; }

        public PlayerInfo(int playerId,string playerName,char playerSymbol)
        {
            PlayerId = playerId;
            PlayerName = playerName;
            PlayerSymbol = playerSymbol;
        }
    }
}
