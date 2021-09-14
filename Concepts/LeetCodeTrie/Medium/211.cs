using System;
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
    /// https://leetcode.com/problems/design-add-and-search-words-data-structure/solution/
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
                    while (i < length && (word[i] ==w[i] || word[i]=='.'))
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
