using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    class _139
    {

        public static void _139Main()
        {

            _139 WordBreak = new _139();

            List<string> wordDict = new List<string>()
            {
               "leet","code"
            };

            var answer = WordBreak.WordBreak0("leetcode", wordDict);
            Console.ReadLine();
        }

        /// <summary>
        //! With AA 
        //!Time complexity With memoization=O(n^3)       
        //!(possible recursive function states) * (amount of work we are doing per recursive call)
        //! n*(substring cost=n *loop inside going from 1---n)
        //! Space=O(n)
        //! Time complexity without memoization=2^n*n
        //!branchingFactor^recurion depth=2^n * amount of work(n)          
        /// </summary>
        public bool WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> hs = new HashSet<string>();
            PopulateHashSet(wordDict, hs);
            Dictionary<int, bool> cache = new Dictionary<int, bool>();
            return WordBreak(s, 0, hs, cache);
        }
        private bool WordBreak(string s, int start, HashSet<string> hs, Dictionary<int, bool> cache)
        {
            //!We will only reach here if we have valid case for previous substring in string. 
            //! Otherwise we will never reach here because of the condition  if (!hs.Contains(pre)) continue;
            if (start == s.Length)
            {
                return true;
            }
            if (cache.ContainsKey(start))
                return cache[start];

            for (int i = start; i < s.Length; ++i)
            {
                string pre = s.Substring(start, i - start + 1);
                if (!hs.Contains(pre))
                    continue;

                if (WordBreak(s, i + 1, hs, cache))
                {
                    return cache[start]=true;
                }
            }
            return cache[start]=false;
        }

        private void PopulateHashSet(IList<string> wordDict, HashSet<string> hs)
        {
            foreach (string s in wordDict)
            {
                hs.Add(s);
            }
        }

        //! Solution based on Trie.
        //! insert all words dictionary in Trie.Serch the string in Trie
        public bool WordBreak1(string s, IList<string> wordDict)
        {

            Trie trie = new Trie();
            foreach (string word in wordDict)
            {
                trie.Insert(word);
            }
            Dictionary<int, bool> memo = new Dictionary<int, bool>();
            return trie.Search(s, 0, memo);
        }
        public class Trie
        {
            TrieNode _root;
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
                    curr = curr.Children[c];
                }
                ++curr.WordEnd;
            }

            public bool Search(string word, int start, Dictionary<int, bool> memo)
            {
                if (start == word.Length)
                    return true;

                if (memo.ContainsKey(start))
                    return memo[start];

                //! We will always start from the root
                TrieNode curr = _root;
                for (int i = start; i < word.Length; ++i)
                {
                    char c = word[i];
                    if (!curr.Children.ContainsKey(c))
                    {
                        return memo[start] = false;
                    }
                    curr = curr.Children[c];
                    if (curr.WordEnd > 0 && Search(word, i + 1, memo))
                    {
                        return memo[start] = true;
                    }

                }
                return memo[start] = false;
            }
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children;
            public int WordEnd;
            public TrieNode()
            {
                Children = new Dictionary<Char, TrieNode>();
                WordEnd = 0;
            }
        }

        /// <summary>
        //!DP with memoization based on idea in Kuai's class 
        /// </summary>
        public bool WordBreak0(string s, IList<string> wordDict)
        {
            HashSet<string> hs = new HashSet<string>();
            foreach (string word in wordDict)
            {
                hs.Add(word);
            }
            Dictionary<string, bool> memo = new Dictionary<string, bool>();           
            return CanBreak(s, memo, hs);
            //return word_Break(s, hs, 0);
        }
        private bool CanBreak(string s, Dictionary<string, bool> memo, HashSet<string> wordDict)
        {
            if (wordDict.Contains(s))
                return true;

            if (memo.ContainsKey(s)) return memo[s];

            for (int i = 0; i < s.Length; ++i)
            {
                string fs = s.Substring(0, i);
                string ss = s.Substring(i);

                if (CanBreak(fs, memo, wordDict) && CanBreak(ss, memo, wordDict))
                {
                    memo[s] = true;
                    return memo[s];
                }
            }

            memo[s] = false;

            return memo[s];
        }

        /// <summary>
        //!Brute Force Approach based on idea in Kuai's class
        //! Recursively calling function
        // ! changing start index with every reucursive call and end index is end=start+1 Index
        //! Complexity Analysis: 
        //Time complexity : O(n^n)
        //Consider the worst case where ss = "\text{aaaaaaa}aaaaaaa" and every prefix of ss 
        //is present in the dictionary of words, then the recursion tree can grow upto n^n
        //Space complexity : O(n) O(n). The depth of the recursion tree can go upto nn.
        /// </summary>

        public bool WordBreak3(string s, IList<string> wordDict)
        {
            HashSet<string> hs = new HashSet<string>();
            foreach (string word in wordDict)
            {
                hs.Add(word);
            }

            return CanBreak(s, hs);
            //return word_Break(s, hs, 0);
        }

        private bool CanBreak(string s, HashSet<string> wordDict)
        {
            if (wordDict.Contains(s))
                return true;

            for (int i = 0; i < s.Length; ++i)
            {
                string firstSegment = s.Substring(0, i); //!O(n)

                string secondSegment = s.Substring(i);  //!O(n)

                if (CanBreak(firstSegment, wordDict) && CanBreak(secondSegment, wordDict))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
