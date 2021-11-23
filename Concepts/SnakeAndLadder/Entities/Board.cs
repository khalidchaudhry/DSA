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
        //! Done
        private Dictionary<string, int> _playerNamePosition;

        public Board(int size)
        {
            Size = size;
            _headPosSnakes = new Dictionary<int, Snake>();
            _startPosLadder = new Dictionary<int, Ladder>();
            _playerNamePosition = new Dictionary<string, int>();
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
                _playerNamePosition.Add(playerName, 0);
            }
        }
        public Dictionary<string, int> GetPlayerNamesPositions()
        {
            //! The reason for returning new dictionary is because we don't want class dictionary to get modified
            return new Dictionary<string, int>(_playerNamePosition);
        }
        public int GetPlayersCount()
        {
            return _playerNamePosition.Count;
        }
        public int GetPlayerPosition(string  playerName)
        {
            return _playerNamePosition[playerName];
        }
       

        public void Move(string player, int newPos)
        {
            int currPos = _playerNamePosition[player];

            if (_headPosSnakes.ContainsKey(newPos))
            {
                _playerNamePosition[player] = _headPosSnakes[newPos].TailPosition;
            }
            else if (_startPosLadder.ContainsKey(newPos))
            {
                _playerNamePosition[player] = _startPosLadder[newPos].EndPosition;
            }
            else if (currPos + newPos <= Size)
            {
                _playerNamePosition[player] = currPos + newPos;
            }
        }


    }
}
