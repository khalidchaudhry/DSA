using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTrie
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children;
        public int WordEnd;
        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            WordEnd = 0;
        }

    }
}
