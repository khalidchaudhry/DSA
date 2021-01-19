using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Hard
{
    public class _51
    {
        public static void _51Main()
        {

            var test = new _51();
            var ans=test.SolveNQueens(4);
            Console.ReadLine();


        }
        public IList<IList<string>> SolveNQueens(int n)
        {

            char[,] board = new char[n, n];
            List<IList<string>> result = new List<IList<string>>();
            PopulateBoard(board);
            SolveNQueens(board, new bool[n], result, 0);
            return result;
        }
        private void SolveNQueens(char[,] board, bool[] used, List<IList<string>> result, int r)
        {
            if (r == board.GetLength(0))
            {
                AddToResult(result, board);
                return;
            }

            for (int c = 0; c < board.GetLength(1); ++c)
            {
                if (CanPlace(board, used, r, c))
                {
                    used[c] = true;
                    board[r, c] = 'Q';
                    SolveNQueens(board, used, result, r + 1);
                    used[c] = false;
                    board[r, c] = '.';
                }
            }
        }

        private void PopulateBoard(char[,] board)
        {
            for (int r = 0; r < board.GetLength(0); ++r)
            {
                for (int c = 0; c < board.GetLength(1); ++c)
                {
                    board[r, c] = '.';
                }
            }
        }

        private bool CanPlace(char[,] board, bool[] used, int r, int c)
        {
            if (used[c])
            {
                return false;
            }
            //!row < r because we have not yet filed the next rows. Otherwise it would have been row<board.GetLength(0)
            for (int row = 0; row < r; ++row)
            {
                //! Will check all the columns because we may have placed the queen in next column in previous row
                for (int column = 0; column < board.GetLength(1); ++column)
                {
                    if (board[row,column]=='Q' && Math.Abs(row - r) == Math.Abs(column - c))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void AddToResult(List<IList<string>> result, char[,] board)
        {
            List<string> totalRows = new List<string>();
            for (int r = 0; r < board.GetLength(0); ++r)
            {
                StringBuilder sb = new StringBuilder();
                for (int c = 0; c < board.GetLength(1); ++c)
                {
                    sb.Append(board[r, c]);
                }
                totalRows.Add(sb.ToString());
            }
            result.Add(totalRows);
        }

    }
}
