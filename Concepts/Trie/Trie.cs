using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    public class Trie
    {
        private TrieNode _root;
        public Trie()
        {
            _root = new TrieNode();
            _root.Children.Add('/', new TrieNode());
        }
        public void Insert(string word)
        {
            TrieNode curr = _root;
            foreach (char c in word)
            {
                if (!curr.Children.ContainsKey(c))
                {
                    curr.Children.Add(c, new TrieNode());
                }
                ++curr.PrefixCount;
                curr = curr.Children[c];
            }
            ++curr.WordEnd;
        }
        public int PrefixCount(string prefix)
        {
            TrieNode curr = _root;
            foreach (char c in prefix)
            {
                if (!curr.Children.ContainsKey(c))
                {
                    return 0;                    
                }
                curr = curr.Children[c];
            }
            return curr.PrefixCount;
        }
    }

    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children;
        public int WordEnd;
        public int PrefixCount;
        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            WordEnd = 0;
            PrefixCount = 0;
        }
    }
}
