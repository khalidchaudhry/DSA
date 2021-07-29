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
        private Dictionary<int, PlayerBoardData> _playerIdData;
        private char[,] _grid;
        private int _occupiedCellsCount;

        public int Size { get; private set; }


        public Board(int size)
        {
            Size = size;
            _grid = new char[Size, Size];
            _playerIdData = new Dictionary<int, PlayerBoardData>();
        }

        public void Initialize(List<PlayerInfo> playersInfo)
        {
            foreach (PlayerInfo playerInfo in playersInfo)
            {
                _playerIdData.Add(playerInfo.PlayerId, new PlayerBoardData(Size));
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

        public void SetGirdCellValue(PlayerInfo playerInfo, int r, int c)
        {
            _grid[r, c] = playerInfo.PlayerSymbol;
            ++_occupiedCellsCount;

            ++_playerIdData[playerInfo.PlayerId].RowCount[r];
            ++_playerIdData[playerInfo.PlayerId].RowCount[c];

            if (r == c)
            {
                ++_playerIdData[playerInfo.PlayerId].DiagonalCount;
            }

            //!To calculate anti-diagonal , we need to find horizontal distance and vertical distance 
           //! if horizontal distance==verticial distance then point lies on anti-diagonal 
           // ! Horizontal distance=row+1 
           //! Vertical distance=Size -column
            if (r + 1 == Size - c)
            {
                ++_playerIdData[playerInfo.PlayerId].AntiDiagonalCount;
            }
        }

        public bool IsWinner(int playerId, int r, int c)
        {

            if (_playerIdData[playerId].RowCount[r] == Size || _playerIdData[playerId].ColumnCount[c] == Size ||
                _playerIdData[playerId].DiagonalCount == Size || _playerIdData[playerId].AntiDiagonalCount == Size)
            {
                return true;
            }

            return false;
        }
        public bool IsCellLeft()
        {
            return _occupiedCellsCount != (Size * Size);
        }
        private class PlayerBoardData
        {
            public int[] RowCount { get; set; }
            public int[] ColumnCount { get; set; }
            public int DiagonalCount { get; set; }
            public int AntiDiagonalCount { get; set; }
            public PlayerBoardData(int size)
            {
                RowCount = new int[size];
                ColumnCount = new int[size];
            }
        }


    }



}
