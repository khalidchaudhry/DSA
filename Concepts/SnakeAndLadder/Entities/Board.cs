using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder.Entities
{
    public class Board
    {
        public int Size { get; private set; }
        private Dictionary<int, Snake> _headPosSnakes;
        private Dictionary<int, Ladder> _startPosLadder;
        // TODO: Refactor below . It should be private field than public property becuase currently we can modify it from outside.   
        public Dictionary<string, int> PlayerNamePosition { get; private set; }

        public Board(int size)
        {
            Size = size;
            _headPosSnakes = new Dictionary<int, Snake>();
            _startPosLadder = new Dictionary<int, Ladder>();
            PlayerNamePosition = new Dictionary<string, int>();
        }

        public void InitBoard(List<(int h, int t)> snakesPos, List<(int h, int t)> laddersPos, List<string> playersName)
        {
            foreach ((int h, int t) in snakesPos)
            {
                _headPosSnakes.Add(h, new Snake(h, t));
            }

            foreach ((int s, int e) in laddersPos)
            {
                _startPosLadder.Add(s, new Ladder(s, e));
            }

            foreach (string playerName in playersName)
            {
                PlayerNamePosition.Add(playerName, 0);
            }
        }

        public void Move(string player, int newPos)
        {
            int currPos = PlayerNamePosition[player];

            if (_headPosSnakes.ContainsKey(newPos))
            {
                PlayerNamePosition[player] = _headPosSnakes[newPos].TailPosition;
            }
            else if (_startPosLadder.ContainsKey(newPos))
            {
                PlayerNamePosition[player] = _startPosLadder[newPos].EndPosition;
            }
            else if (currPos + newPos <= Size)
            {
                PlayerNamePosition[player] = currPos + newPos;
            }
        }


    }
}
