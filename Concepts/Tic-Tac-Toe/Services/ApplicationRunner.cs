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
            List<string[]> playersTokens = new List<string[]>();
            for (int i = 1; i <= 2; ++i)
            {
                string inputForplayer = Console.ReadLine();

                string[] playerTokens = _inputProcessor.Process(inputForplayer);
                playersTokens.Add(playerTokens);
            }
            _manager.InitBoard(playersTokens);

            int totalPlayers = playersTokens.Count;
            int playerNo = 0;

            while (true)
            {
                string positions = Console.ReadLine();
                string[] positionTokens = _inputProcessor.Process(positions);
                int[] pos = _inputProcessor.Transform(positionTokens);

                int currPlayerNo = playerNo % totalPlayers;
                bool isMoveSuccessful = _manager.MovePlayer(playersTokens[currPlayerNo][0], pos);
                bool isGameOver = _manager.IsGameOver();
                if (isMoveSuccessful)
                {
                    ++playerNo;
                }
            }

        }
    }
}
