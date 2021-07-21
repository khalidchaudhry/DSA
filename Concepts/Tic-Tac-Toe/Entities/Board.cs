using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Services.Interfaces;

namespace TicTacToe.Entities
{
    public class Board
    {
        private Dictionary<int, Player> _playerIdData;
        private List<Player> _players;
        private char[,] _grid;
        private int _occupiedCellsCount;

        public int Size { get; private set; }


        public Board(int size)
        {
            Size = size;
            _grid = new char[Size, Size];
        }

        public void Initialize(List<Player> players)
        {
            _players = players;
            _playerIdData = new Dictionary<int, Player>();
            foreach (Player player in players)
            {
                _playerIdData.Add(player.PlayerId, player);
            }

            for (int r = 0; r < Size; ++r)
            {
                for (int c = 0; c < Size; ++c)
                {
                    _grid[r, c] = '-';
                }
            }
        }

        public string GetGridData()
        {
            StringBuilder sb = new StringBuilder();
            int n = _grid.GetLength(0);
            for (int r = 0; r < n; ++r)
            {
                for (int c = 0; c < n; ++c)
                {
                    sb.Append($"{_grid[r, c]} ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public char GetGirdCellValue(int r, int c)
        {
            return _grid[r, c];
        }

        public void SetGirdCellValue(int playerId, int r, int c)
        {
            _grid[r, c] = _playerIdData[playerId].PlayerSymbol;
            ++_occupiedCellsCount;

            ++_playerIdData[playerId].RowCount;
            ++_playerIdData[playerId].ColumnCount;
            if (r == c)
            {
                ++_playerIdData[playerId].DiagonalCount;
            }
            if (r == Size - 1)
            {
                ++_playerIdData[playerId].AntiDiagonalCount;
            }
        }

        public bool IsWinner(int r, int c)
        {
            foreach (var keyValue in _playerIdData)
            {
                if (keyValue.Value.RowCount == Size || keyValue.Value.ColumnCount == Size ||
                    keyValue.Value.DiagonalCount == Size || keyValue.Value.AntiDiagonalCount == Size)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsCellLeft()
        {
            return _occupiedCellsCount != (Size * Size);
        }

    }



}
