using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _79
    {
        /// <summary>
        //! Similar to Problem 200,130
        //! Depth first search
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exist(char[][] board, string word)
        {
            if (board.Length == 0)
                return false;
            int rows = board.Length;
            int columns = board[0].Length;

            for (int row = 0; row < rows; row++)
                for (int column = 0; column < columns; column++)
                {
                    if (DFS(board, row, column, 0, word))
                    {
                        return true;
                    }
                }

            return false;
        }

        private bool DFS(char[][] board, int row, int column, int index, string word)
        {
            if (index == word.Length)
            {
                return true;
            }

            int rows = board.Length;
            int columns = board[0].Length;
            if (row < 0 || row >= rows || column < 0 || column >= columns || board[row][column] != word[index])
            {
                return false;
            }

            char c = board[row][column];
            board[row][column] = '#';

            bool result =
                DFS(board, row - 1, column, index + 1, word) ||  //up
                DFS(board, row + 1, column, index + 1, word) ||  //down
                DFS(board, row, column + 1, index + 1, word) || //right
                DFS(board, row, column - 1, index + 1, word); // left

            board[row][column] = c;

            return result;
        }
    }
}
