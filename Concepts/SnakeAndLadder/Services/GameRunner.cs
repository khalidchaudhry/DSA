using SnakeAndLadder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder.Services
{

    public class GameRunner
    {
        private Board _board;
        private Dice _dice;
        public GameRunner(Board board, Dice dice)
        {
            _board = board;
            _dice = dice;
        }
        public void InitBoard(List<(int h, int t)> snakesPos, List<(int h, int t)> laddersPos, List<string> playersName)
        {
            _board.InitBoard(snakesPos, laddersPos, playersName);
        }

        public void Run()
        {            
            Dictionary<string, int> playerPosition = _board.PlayerNamePosition;          
            int totalPlayers = _board.PlayerNamePosition.Count;
            List<string> players = playerPosition.Keys.ToList();
            int playerNo = 0;
            while (true)
            {
                int pos = _dice.Roll();
                int currPlayerIdx = playerNo % totalPlayers;
                string currPlayerName = players[currPlayerIdx];
                int currPlayerPos = _board.PlayerNamePosition[currPlayerName];

                _board.Move(currPlayerName, pos);

                Console.WriteLine($"{currPlayerName} rolled a {pos} and moved from {currPlayerPos} " +
                    $"to {_board.PlayerNamePosition[currPlayerName]}");

                if (_board.PlayerNamePosition[currPlayerName] == _board.Size)
                {
                    Console.WriteLine($"{currPlayerName} wins the game");
                    break;
                }
                ++playerNo;
            }
        }
    }
}
