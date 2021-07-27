using System;
using System.Collections.Generic;
using TicTacToe.Entities;
using TicTacToe.Services.Interfaces;

namespace TicTacToe.Services
{
    public class ApplicationRunner
    {
        private IInputProcessor<string> _inputProcessor;
        private GameManager _manager;
        private Board _board;
        private IPrint _print;
        public ApplicationRunner(IInputProcessor<string> inputProcessor, Board board, GameManager manager, IPrint print)
        {
            _inputProcessor = inputProcessor;
            _manager = manager;
            _board = board;
            _print = print;
        }

        public void Run()
        {

            _print.Print("Enter piece symbol and player name");
            List<PlayerInfo> playersInfo = new List<PlayerInfo>();
            for (int i = 0; i <= 1; ++i)
            {
                string inputForplayer = Console.ReadLine();

                string[] playerTokens = _inputProcessor.TransformToArray(inputForplayer);
                char playerSymbol = _inputProcessor.TransformToChar(playerTokens[0]);
                string playerName = playerTokens[1];

                playersInfo.Add(new PlayerInfo(i, playerName, playerSymbol));
            }

            _manager.InitBoard(playersInfo);

            int totalPlayers = playersInfo.Count;
            int playerId = 0;
            PlayerInfo currPlayerInfo = playersInfo[playerId];
            int row = 0;
            int col = 0;

            do
            {
                string positions = Console.ReadLine();
                string[] positionTokens = _inputProcessor.TransformToArray(positions);

                row = _inputProcessor.TransformToInt(positionTokens[0]);
                col = _inputProcessor.TransformToInt(positionTokens[1]);

                if (Validator.IsInValidMove(row, col, _board))
                {
                    _print.Print("Invalid Move");
                    continue;
                }

                int currPlayerId = playerId % totalPlayers;
                currPlayerInfo = playersInfo[currPlayerId];

                _manager.MovePlayer(playersInfo[currPlayerId], row, col);
                ++playerId;

            } while (!_manager.IsGameOver(currPlayerInfo, row, col));

            Console.ReadLine();

        }
    }
}
