using System;
using System.Collections.Generic;
using TicTacToe.Entities;


namespace TicTacToe.Services
{
    public class ApplicationRunner
    {
        private IInputProcessor<string> _inputProcessor;
        private GameManager _manager;
        private Board _board;
        public ApplicationRunner(IInputProcessor<string> inputProcessor, Board board, GameManager manager)
        {
            _inputProcessor = inputProcessor;
            _manager = manager;
            _board = board;
        }

        public void Run()
        {          
            
            Console.WriteLine("Enter piece symbol and player name");
            List<Player> players = new List<Player>();
            for (int i = 0; i <= 1; ++i)
            {
                string inputForplayer = Console.ReadLine();

                string[] playerTokens = _inputProcessor.TransformToArray(inputForplayer);
                char playerSymbol = _inputProcessor.TransformToChar(playerTokens[0]);
                string playerName = playerTokens[1];

                players.Add(new Player(i, playerName, playerSymbol));
            }

            _manager.InitBoard(players);

            int totalPlayers = players.Count;
            int playerId = 0;
            string currPlayerName = players[playerId].PlayerName;
            int row = 0;
            int col = 0;

            while (!_manager.IsGameOver(currPlayerName, row, col))
            {
                string positions = Console.ReadLine();
                string[] positionTokens = _inputProcessor.TransformToArray(positions);

                row = _inputProcessor.TransformToInt(positionTokens[0]);
                col = _inputProcessor.TransformToInt(positionTokens[1]);

                int currPlayerId = playerId % totalPlayers;
                currPlayerName = players[currPlayerId].PlayerName;
                

                bool isMoveSuccessful = _manager.MovePlayer(currPlayerId, row,col);

                if (isMoveSuccessful)
                {
                    ++playerId;
                }
            }
            Console.ReadLine();

        }
    }
}
