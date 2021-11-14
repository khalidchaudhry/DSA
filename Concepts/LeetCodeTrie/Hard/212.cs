using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTrie.Hard._212
{
    public class _212
    {

        /// <summary>
        //! DFS + Trie
        // https://leetcode.com/problems/word-search-ii/discuss/712722/Two-Solution-or-Trie-DFS-Backtracking-or-Steps-and-Well-commented
        /// </summary>
        /// <param name="board"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<string> FindWords(char[][] board, string[] words)
        {
            // Build Trie based on the words 
            TrieNode root = new TrieNode();
            ConstructTrie(words, root);
            List<string> result = new List<string>();
            for (int row = 0; row < board.Length; ++row)
            {
                for (int column = 0; column < board[0].Length; ++column)
                {
                    if (root.Children.ContainsKey(board[row][column]))
                        DFS(board, row, column, root, result);
                }
            }

            return result;
        }

        private void DFS(char[][] board, int row, int column, TrieNode root, List<string> result)
        {
            char c = board[row][column]; // get the current character from the board at i, j
            if (c == '*' || !root.Children.ContainsKey(c))
                return;

            root = root.Children[c];
            if (root.word != null)
            {   // found one words add in the result list
                result.Add(root.word);
                root.word = null;     // de-duplicate remove the word from trie
            }

            board[row][column] = '*'; // update the character of at i , j no need for visited array

            foreach ((int x, int y) in GetNeighbors(board, row, column))
            {
                DFS(board, x, y, root, result);               
            }

            board[row][column] = c; //! backtrack the character

            //if (row > 0) DFS(board, row - 1, column, root, result); // up
            //if (column > 0) DFS(board, row, column - 1, root, result); // left
            //if (row < board.Length - 1) DFS(board, row + 1, column, root, result); // down
            //if (column < board[0].Length - 1) DFS(board, row, column + 1, root, result); // right
            //board[row][column] = c; // backtrack the character
        }

        private void ConstructTrie(string[] words, TrieNode root)
        {
            foreach (string word in words)
            {
                TrieNode node = root;
                foreach (char c in word)
                {
                    if (node.Children.ContainsKey(c))
                    {
                        node = node.Children[c];
                    }
                    else
                    {
                        TrieNode newTrieNode = new TrieNode();
                        node.Children.Add(c, newTrieNode);
                        node = newTrieNode;
                    }
                }
                node.word = word;
            }
        }

        private IEnumerable<(int x, int y)> GetNeighbors(char[][] board, int i, int j)
        {
            foreach ((int x, int y) in new List<(int, int)> { (i - 1, j), (i + 1, j), (i, j + 1), (i, j - 1) })
            {
                if (x >= 0 && x < board.Length && y >= 0 && y < board[0].Length)
                    yield return (x, y);
            }
        }
    }

    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; }
        public string word;
        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            word = null;
        }
    }
}
