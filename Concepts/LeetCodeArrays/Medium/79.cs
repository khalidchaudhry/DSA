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
        //! Time=M*N*4^L
        //! Space=O(L)+O(M*N)
        //! L= word length
        /// </summary>      
        public bool Exist(char[][] board, string word)
        {

            int rows = board.Length;
            int cols = board[0].Length;
            //!Time= m*n for iterating the grid
            for (int r = 0; r < rows; ++r)
            {
                for (int c = 0; c < cols; ++c)
                {
                    if (Solve(board, r, c, word, 0, new HashSet<(int r, int c)>()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        //! Time=branching factor^recursion depth= 4^L(WordLength) 
        // ! Space=recursion depth+visited set space
        //!  Space=O(L){where L is word length}+O(M*N)
        /// </summary>
        private bool Solve(char[][] board, int r, int c, string word, int wordIdx, HashSet<(int r, int c)> visited)
        {
            if (wordIdx == word.Length)
            {
                return true;
            }

            if (IsOutOfBound(board, r, c) || visited.Contains((r, c)) || board[r][c] != word[wordIdx])
            {
                return false;
            }

            visited.Add((r, c));
            foreach ((int nr, int nc) in GetNeighbors(r, c))   //branching factor=4
            {
                if (Solve(board, nr, nc, word, wordIdx + 1, visited))
                {
                    return true;
                }
            }
            visited.Remove((r, c));
            return false;
        }
        private List<(int nr, int nc)> GetNeighbors(int r, int c)
        {
            List<(int nr, int nc)> neighbors = new List<(int nr, int nc)>();
            foreach ((int nr, int nc) in new List<(int nr, int nc)>() { (r + 1, c), (r - 1, c), (r, c + 1), (r, c - 1) })
            {
                neighbors.Add((nr, nc));
            }
            return neighbors;
        }
        private bool IsOutOfBound(char[][] board, int r, int c)
        {
            return r < 0 || r >= board.Length || c < 0 || c >= board[0].Length;
        }
    }
}
