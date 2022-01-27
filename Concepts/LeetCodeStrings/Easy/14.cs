using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeStrings.Easy
{
    public class _14
    {


        public static void _14Main()
        {
            string[] strs = new string[] { "ab", "a" };
            _14 test = new _14();
            var answer = test.LongestCommonPrefix2(strs);
            Console.WriteLine(answer);
            Console.ReadLine();
        }

        //! Time complexity=O(nlogn)+min(among all strings length)*n  where n is the string length
        //! Space Complexity=O(1)
        public string LongestCommonPrefix(string[] strs)
        {

            strs = strs.OrderBy(x => x.Length).ToArray();
            string shortest = strs[0];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < shortest.Length; ++i)
            {
                for (int j = 1; j < strs.Length; ++j)
                {
                    if (shortest[i] != strs[j][i])
                    {
                        return sb.ToString();
                    }
                }
                sb.Append(shortest[i]);
            }
            return sb.ToString();
        }
        public string LongestCommonPrefix2(string[] strs)
        {

            Trie trie = new Trie();
            foreach (string str in strs)
            {
                trie.Add(str);
            }
            return trie.Search(strs[0]);
        }
    }
    public class Trie
    {
        public TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
            _root.Children.Add('/', new TrieNode());
            _root = _root.Children['/'];
        }
        public void Add(string str)
        {
            TrieNode curr = _root;
            foreach (char c in str)
            {
                if (!curr.Children.ContainsKey(c))
                {
                    curr.Children.Add(c, new TrieNode());
                }             
                curr = curr.Children[c];
            }
            ++curr.WordEnd;
        }
        public string Search(string word)
        {
            StringBuilder result = new StringBuilder();
            TrieNode curr = _root;
            foreach (char c in word)
            {
                //1. If trie does not contain the word we are searching for 
                //2. If  current node has >1 child  than it means that found path not common among all the words
                //3. We have reached to one of the word ends so no point searching further
                if (!curr.Children.ContainsKey(c) || curr.Children.Count !=1 || curr.WordEnd>=1)
                {
                    return result.ToString();
                }
                result.Append(c);
                curr = curr.Children[c];
            }
            return result.ToString();
        }
    }
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
