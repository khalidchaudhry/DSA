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

        public void InitBoard(List<string[]> playerTokens)
        {
            List<Player> players = new List<Player>();
            foreach (string[] playerToken in playerTokens)
            {
                players.Add(new Player(playerToken[0], Convert.ToChar(playerToken[1])));
            }
            _board.Initialize(_board.Size, players);
        }

        public bool MovePlayer(string playerName,int[] tokens)
        {
            Position newPosition = new Position(tokens[0], tokens[1]);

            foreach (var playerNamePosition in _board.PlayerNamePositions)
            {
                string currPlayerName = playerNamePosition.Key;
                HashSet<Position> currPlayerPos = playerNamePosition.Value;

                if (currPlayerPos.Contains(newPosition))
                {
                    _print.Print("Invalid Move");
                    return false;
                }
            }

            _board.PlayerNamePositions[playerName].Add(newPosition);
            _print.Print(_board.Grid);
            return true;

        }
        public bool IsGameOver()
        {
            int count = 0;
            foreach (var playerNamePosition  in _board.PlayerNamePositions)
            {

            }

            return true;
        }

       

    }
}
