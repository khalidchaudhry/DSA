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

        private void DFS(char[][] board, int row, int column, TrieNode trieNode, List<string> result)
        {
            //! if trie children does not contain the character we are looking for just backtrack
            //!trieNode.Children.ContainsKey(board[row][column]
            if (IsOutOfBound(board, row, column) || board[row][column] == '*' || !trieNode.Children.ContainsKey(board[row][column]))
            {
                return;
            }

            char c = board[row][column];
            trieNode = trieNode.Children[c];
            if (trieNode.word != null)
            {   // found one word add in the result list
                result.Add(trieNode.word);
                trieNode.word = null;     // de-duplicate remove the word from trie
            }

            board[row][column] = '*'; // update the character of at i , j no need for visited array

            foreach ((int x, int y) in GetNeighbors(row, column))
            {
                DFS(board, x, y, trieNode, result);
            }
            board[row][column] = c; //! backtrack the character
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
