using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Hard
{
    public class _37
    {

        public static void _37Main()
        {

                char[][] board = new char[9][]{
                new char[9]{'5','3','.','.','7','.','.','.','.'},
                new char[9]{'6','.','.','1','9','5','.','.','.'},
                new char[9]{'.','9','8','.','.','.','.','6','.'},
                new char[9]{'8','.','.','.','6','.','.','.','3'},
                new char[9]{'4','.','.','8','.','3','.','.','1'},
                new char[9]{'7','.','.','.','2','.','.','.','6'},
                new char[9]{'.','6','.','.','.','.','2','8','.'},
                new char[9]{'.','.','.','4','1','9','.','.','5'},
                new char[9]{'.','.','.','.','8','.','.','7','9'}
       };

            char[][] board2 = new char[4][]{
                new char[4]{'.','1','.','.'},
                new char[4]{'.','.','.','2'},
                new char[4]{'1','.','.','.'},
                new char[4]{'.', '.','4','.'}
              
       };
            var test = new _37();


            List<(int, int)> emptyIndexes = EmptyIndexes(board);
            test.SolveSudoku(board, emptyIndexes, 0);
            Print(board);

            Console.ReadLine();

        }


        private bool SolveSudoku(char[][] board, List<(int row, int column)> emptyIndexes, int index)
        {
            if (index == emptyIndexes.Count)
                return true;

            for (char digit = '1'; digit <= '9'; ++digit)
            {
                int row = emptyIndexes[index].row;
                int column = emptyIndexes[index].column;

                if (CanPlace(board, row, column, digit))
                {
                    board[row][column] = digit;
                    if (SolveSudoku(board, emptyIndexes, index + 1))
                    {
                        return true;
                    }
                    board[row][column] = '.';
                }
            }

            return false;
        }

        private bool CanPlace(char[][] board, int r, int c, char digit)
        {
            //! Check the row to ensure that we don't have same digit on it 
            for (int column = 0; column < board[0].Length; ++column)
            {
                if (board[r][column] == digit)
                    return false;
            }
            //! Check the column to ensure that we don't have digit on it 
            for (int row = 0; row < board.Length; ++row)
            {
                if (board[row][c] == digit)
                    return false;
            }

            
            int boxsize = (int)Math.Sqrt(board.Length);
            //! r/boxSize   gives us the box rank horizontally 
            //! r/boxSize   gives us the box rank vertically 
            
            //! Box start row            
            int startRow = boxsize * (r / boxsize);
            //! Box start col
            int startColumn = boxsize * (c / boxsize);

            //! Checking the baksa
            for (int row = 0; row < boxsize; ++row)
            {
                for (int column = 0; column < boxsize; ++column)
                {
                    int tr = startRow + row;
                    int tc = startColumn + column;
                    if (board[tr][tc] == digit)
                        return false;
                }
            }
            return true;
        }

        private static List<(int, int)> EmptyIndexes(char[][] board)
        {
            List<(int, int)> emptyIndexes = new List<(int, int)>();
            for (int r = 0; r < board.Length; ++r)
            {
                for (int c = 0; c < board[0].Length; ++c)
                {
                    if (board[r][c] == '.')
                    {
                        emptyIndexes.Add((r, c));
                    }
                }
            }
            return emptyIndexes;
        }

        private static void Print(char[][] grid)
        {
            for (int i = 0; i < grid.Length; ++i)
            {
                for (int j = 0; j < grid[0].Length; ++j)
                {
                    Console.Write($"{grid[i][j]}");
                }
                Console.WriteLine();
            }
        }


    }
}
