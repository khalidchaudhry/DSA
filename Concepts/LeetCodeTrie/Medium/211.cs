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
        Dictionary<int, List<string>> map;
        /** Initialize your data structure here. */
        public WordDictionary()
        {
            map = new Dictionary<int, List<string>>();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            int length = word.Length;

            if (map.ContainsKey(length))
            {
                map[length].Add(word);
            }
            else
            {
                map.Add(length, new List<string>() { word });
            }

        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            int length = word.Length;

            if (map.ContainsKey(length))
            {
                foreach (string w in map[length])
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
