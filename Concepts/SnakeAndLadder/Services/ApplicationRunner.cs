using System;
using System.Collections.Generic;

namespace SnakeAndLadder.Services
{
    public class ApplicationRunner
    {

        private GameRunner _gameRunner;
        public ApplicationRunner(GameRunner gameRunner)
        {
            _gameRunner = gameRunner;
        }
        public void Run()
        {

            string snakes = Console.ReadLine();
            int snakesCount = Convert.ToInt32(snakes);
            List<(int h, int t)> snakesPos = new List<(int h, int t)>();
            Populate(snakesPos,snakesCount);
            
            string ladders = Console.ReadLine();
            int laddersCount = Convert.ToInt32(ladders);
            List<(int s, int e)> laddersPos = new List<(int s, int e)>();
            Populate(laddersPos, laddersCount);

            string players = Console.ReadLine();
            int playersCount = Convert.ToInt32(players);
            List<string> playersName = new List<string>();
            for (int i = 0; i < playersCount; ++i)
            {
                string playerName = Console.ReadLine();
                playersName.Add(playerName);    
            }

            _gameRunner.InitBoard(snakesPos,laddersPos,playersName);
            _gameRunner.Run();

        }

        private void Populate(List<(int h, int t)> positions,int count)
        {
            for (int i = 0; i < count; ++i)
            {
                string position = Console.ReadLine();
                string[] firstSecond = position.Split(' ');
                int first = Convert.ToInt32(firstSecond[0]);
                int second = Convert.ToInt32(firstSecond[1]);
                positions.Add((first, second));
            }
        }
    }
}
