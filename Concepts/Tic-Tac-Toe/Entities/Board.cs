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
        private char[,] _grid;
        private int[] _xRowCount;
        private int[] _xColCount;
        private int _xDiagCount;
        private int _xAntiDiagCount;
        private int[] _oRowCount;
        private int[] _oColCount;
        private int _oDiagCount;
        private int _oAntiDiagCount;
        private int _occupiedCellsCount;

        public int Size { get; }


        public Board(int size)
        {
            Size = size;
            Initialize(size);
        }

        public void Initialize(int size)
        {
            _occupiedCellsCount = 0;
            _grid = new char[size, size];
            _xRowCount = new int[size];
            _xColCount = new int[size];
            _xDiagCount = 0;
            _xAntiDiagCount = 0;
            _oRowCount = new int[size];
            _oColCount = new int[size];
            _oDiagCount = 0;
            _oAntiDiagCount = 0;

            for (int r = 0; r < size; ++r)
            {
                for (int c = 0; c < size; ++c)
                {
                    _grid[r, c] = '-';
                }
            }
        }

        public char[,] GetGrid()
        {
            return _grid;
        }
        public char GetGirdCellValue(int r, int c)
        {
            return _grid[r, c];
        }

        public void SetGirdCellValue(int r, int c, char symbol)
        {
            _grid[r, c] = symbol;
            ++_occupiedCellsCount;
            if (symbol == 'X')
            {
                ++_xRowCount[r];
                ++_xColCount[c];

                if (r == c)
                {
                    ++_xDiagCount;
                }
                if (r == Size - 1)
                {
                    ++_xAntiDiagCount;
                }
            }
            else
            {
                ++_oRowCount[r];
                ++_oColCount[c];

                if (r == c)
                {
                    ++_oDiagCount;
                }
                if (r == Size - 1)
                {
                    ++_oAntiDiagCount;
                }
            }
        }

        public bool IsWinner(int r, int c)
        {
            if (_xRowCount[r] == Size || _xColCount[c] == Size || _xDiagCount == Size || _xAntiDiagCount == Size)
                return true;
            else if (_oRowCount[r] == Size || _oColCount[c] == Size || _oDiagCount == Size || _oAntiDiagCount == Size)
                return true;           
            else
                return false;
        }
        public bool IsCellLeft()
        {
            return _occupiedCellsCount != (Size * Size);
        }
    }
}
