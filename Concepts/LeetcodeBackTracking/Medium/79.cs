using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeBackTracking.Medium
{
    public class _79
    {
        //! M =number of rows,N=No of columns
        //! Time complexity=m*n*4^L(wordLength)
        //! Space complexity=O(L)+O(m*n)  //O(L) recursion depth and O(mn) for visited array
        public bool Exist0(char[][] board, string word)
        {
            bool[,] visited = new bool[board.Length, board[0].Length];
            for (int i = 0; i < board.Length; ++i)
            {
                for (int j = 0; j < board[0].Length; ++j)
                {
                    if (IsExist(board, i, j, visited, word, 0))
                        return true;
                }
            }

            return false;
        }

        private bool IsExist(char[][] board, int i, int j, bool[,] visited, string word, int wordIndex)
        {

            if (word.Length == wordIndex)  //! recursion depth=word length(L)
                return true;

            if (
                 !IsInBound(board, i, j) || 
                  visited[i, j] || 
                  word[wordIndex] != board[i][j]
                )
                return false;

            visited[i, j] = true;

            foreach ((int nr, int nc) in GetNeighbors(board, i, j))  //! branching factor=4 ^ word Length
            {
                if (IsExist(board, nr, nc, visited, word, wordIndex + 1))
                    return true;
            }

            visited[i, j] = false;

            return false;
        }

        private IEnumerable<(int, int)> GetNeighbors(char[][] board, int row, int column)
        {
            foreach ((int nr, int nc) in new List<(int, int)> {  (row + 1, column),
                                                                 (row - 1, column),
                                                                 (row, column + 1),
                                                                 (row, column - 1) })
            {
                yield return (nr, nc);
            }
        }

        private bool IsInBound(char[][] board, int row, int column)
        {
            if (row >= 0 && row < board.Length && column >= 0 && column < board[0].Length)
            {
                return true;
            }

            return false;
        }

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
            if (row < 0 || row >= rows ||
                column < 0 || column >= columns ||
                board[row][column] != word[index])
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
