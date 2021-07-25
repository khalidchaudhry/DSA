using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe.Services.Interfaces;

namespace Tic_Tac_Toe.Entities
{
    public class Board
    {
        public char[,] Grid { get; private set; }
        public int Size { get; }
        public Dictionary<string, HashSet<Position>> PlayerNamePositions { get; private set; }

        public Board()
        {
            Size = 0;
            PlayerNamePositions = new Dictionary<string, HashSet<Position>>();
        }
        public Board(int size)
        {
            Size = size;
        }

        public void Initialize(int size, List<Player> players)
        {
            PlayerNamePositions = new Dictionary<string, HashSet<Position>>();
            Grid = new char[size, size];
            for (int r = 0; r < size; ++r)
            {
                for (int c = 0; c < size; ++c)
                {
                    Grid[r, c] = '-';
                }
            }

            foreach (Player player in players)
            {
                PlayerNamePositions.Add(player.PlayerName, new HashSet<Position>());
            }
        }

        
    }
}
