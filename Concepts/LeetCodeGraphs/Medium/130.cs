using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _130
    {
        /// <summary>
        /// https://leetcode.com/problems/surrounded-regions/discuss/41633/Java-DFS-%2B-boundary-cell-turning-solution-simple-and-clean-code-commented.
        /// </summary>
        /// <param name="board"></param>
        public void Solve(char[][] board)
        {
            if (board.Length == 0 || board[0].Length == 0)
                return;
            if (board.Length < 3 || board[0].Length < 3)
                return;

            int rows = board.Length;
            int columns = board[0].Length;

            //!Any 'O' connected to a boundary can't be turned to 'X', so ...
            //!Start from first and last column, turn 'O' to '*'.
            for (int row = 0; row < rows; row++)
            {
                //! Turning first column to '*'
                if (board[row][0] == 'O')
                    DFS(board, row, 0);
                //! Turning last column to "*"
                if (board[row][columns - 1] == 'O')
                    DFS(board, row, columns - 1);
            }

            //!starting from second column as we already covered first column above
            //!ending at < columns - 1 and not <coulmns  as we already covered last column above
            for (int column = 1; column < columns - 1; column++)
            {
                //! Turning first row second column till n-1 to '*' 
                if (board[0][column] == 'O')
                    DFS(board, 0, column);
                //! Turning last row second column till n-1 to '*' 
                if (board[rows - 1][column] == 'O')
                    DFS(board, rows - 1, column);
            }
            //!post-prcessing, turn 'O' to 'X', '*' back to 'O', keep 'X' intact.
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (board[row][column] == 'O')
                        board[row][column] = 'X';
                    else if (board[row][column] == '*')
                        board[row][column] = 'O';
                }
            }
        }
        private void DFS(char[][] board, int r, int c)
        {
            if (r < 0 ||
                c < 0 ||
                r > board.Length - 1 ||
                c > board[0].Length - 1 ||
                board[r][c] != 'O')
                return;

            board[r][c] = '*';

            DFS(board, r, c + 1);//right
            DFS(board, r, c - 1);//left
            DFS(board, r + 1, c);//up 
            DFS(board, r - 1, c);//down       
        }


    }
}
