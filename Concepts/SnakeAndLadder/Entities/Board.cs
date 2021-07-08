using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder.Entities
{
    public class Board
    {
        public int Size { get; }
        public Dictionary<int, Snake> HeadPosSnakes { get; }
        public Dictionary<int, Ladder> StartPosLadder { get; }
        public Dictionary<string, int> PlayerPosition { get; }

        public Board(int size)
        {
            Size = size;
            HeadPosSnakes = new Dictionary<int, Snake>();
            StartPosLadder = new Dictionary<int, Ladder>();
            PlayerPosition = new Dictionary<string, int>();
        }

        public void InitBoard(List<(int h, int t)> snakesPos, List<(int h, int t)> laddersPos, List<string> playersName)
        {
            foreach ((int h, int t) in snakesPos)
            {
                HeadPosSnakes.Add(h, new Snake(h, t));
            }

            foreach ((int s, int e) in laddersPos)
            {
                StartPosLadder.Add(s, new Ladder(s, e));
            }

            foreach (string playerName in playersName)
            {
                PlayerPosition.Add(playerName, 0);
            }
        }

        public void Move(string player, int newPos)
        {
            int currPos = PlayerPosition[player];

            if (HeadPosSnakes.ContainsKey(newPos))
            {
                PlayerPosition[player] = HeadPosSnakes[newPos].TailPosition;
            }
            else if (StartPosLadder.ContainsKey(newPos))
            {
                PlayerPosition[player] = StartPosLadder[newPos].EndPosition;
            }
            else if (currPos + newPos <= Size)
            {
                PlayerPosition[player] = currPos + newPos;
            }            
        }


    }
}
