﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTrie.Medium
{
    public class _211
    {

    }

    /// <summary>
    // !Based on trie 
    /// </summary>
    public class WordDictionary0
    {
        TrieNode _root;
        public WordDictionary0()
        {
            _root = new TrieNode();
            _root.Children.Add('/', new TrieNode());
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            TrieNode curr = _root;
            foreach (char c in word)
            {
                if (!curr.Children.ContainsKey(c))
                {
                    curr.Children.Add(c, new TrieNode());
                }
                curr = curr.Children[c];
            }
            ++curr.WordEnd;
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            return Solve(word, 0, _root);

        }
        private bool Solve(string word, int start, TrieNode node)
        {
            for (int i = start; i < word.Length; ++i)
            {
                char currChar = word[i];
                //! if char found go down next level in trie 
                if (node.Children.ContainsKey(currChar))
                {
                    node = node.Children[currChar];
                }
                else
                {
                    if (currChar == '.')
                    {
                        // if the current character is '.'
                        // check all possible nodes at this level
                        foreach (char key in node.Children.Keys)
                        {
                            TrieNode currNode = node.Children[key];
                            if (Solve(word, i + 1, currNode))
                            {
                                return true;
                            }
                        }
                        // if no nodes lead to answer
                        // or the current character != '.'
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return node.WordEnd > 0;
        }


    }

    /// <summary>
    /// https://leetcode.com/problems/design-add-and-search-words-data-structure/solution/
    //! Below implementation is not efficeint for 
    //! 1. Finding all the keys with common prefix
    //! 2. Enumerating a dataset of strings in lexicographical order.
    //! 3. caling for the large datasets. When hashset size increases , it resulted in multiple collisions
    /// </summary>
    public class WordDictionary
    {
        Dictionary<int, List<string>> _lenWords;
        /** Initialize your data structure here. */
        public WordDictionary()
        {
            _lenWords = new Dictionary<int, List<string>>();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            int length = word.Length;

            if (_lenWords.ContainsKey(length))
            {
                _lenWords[length].Add(word);
            }
            else
            {
                _lenWords.Add(length, new List<string>() { word });
            }

        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            int length = word.Length;

            if (_lenWords.ContainsKey(length))
            {
                foreach (string w in _lenWords[length])
                {
                    int i = 0;
                    while (i < length && (word[i] == w[i] || word[i] == '.'))
                    {
                        ++i;
                    }

                    if (i == length)
                        return true;
                }

            }
            return false;
        }
    }
}
