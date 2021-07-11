using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe.Entities;

namespace Tic_Tac_Toe.Services
{
    public class ApplicationRunner
    {
        private IInputProcessor<string> _inputProcessor;
        private GameManager _manager;
        public ApplicationRunner(IInputProcessor<string> inputProcessor, GameManager manager)
        {
            _inputProcessor = inputProcessor;
            _manager = manager;
        }

        public void Run()
        {
            Console.WriteLine("Enter piece symbol and player name");
            List<Player> players = new List<Player>();
            for (int i = 1; i <= 2; ++i)
            {
                string inputForplayer = Console.ReadLine();

                string[] playerTokens = _inputProcessor.TransformToArray(inputForplayer);
                char playerSymbol = _inputProcessor.TransformToChar(playerTokens[0]);
                string playerName = playerTokens[1];
                
                players.Add(new Player(playerName, playerSymbol));
            }

            _manager.InitBoard();

            int totalPlayers = players.Count;
            int playerNo = 0;
            string currPlayerName = players[playerNo].PlayerName;
            int[] pos = new int[] { 0, 0 };

            while (!_manager.IsGameOver(currPlayerName,pos[0],pos[1]))
            {
                string positions = Console.ReadLine();
                string[] positionTokens = _inputProcessor.TransformToArray(positions);
                pos = _inputProcessor.TransformToArray(positionTokens);

                int currPlayerNo = playerNo % totalPlayers;
                currPlayerName = players[currPlayerNo].PlayerName;

                char currPlayerSymbol = players[currPlayerNo].PlayerSymbol;

                bool isMoveSuccessful = _manager.MovePlayer(currPlayerSymbol, pos);

                if (isMoveSuccessful)
                {
                    ++playerNo;
                }
            }
            Console.ReadLine();

        }
    }
}
