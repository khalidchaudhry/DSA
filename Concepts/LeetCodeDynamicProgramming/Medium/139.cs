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
                    cache[start] = true;
                    return cache[start];
                }
            }
            cache[start] = false;
            return cache[start];
        }

        private void PopulateHashSet(IList<string> wordDict, HashSet<string> hs)
        {
            foreach (string s in wordDict)
            {
                hs.Add(s);
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

        public bool WordBreak1(string s, IList<string> wordDict)
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
        

        private bool word_Break(String s, HashSet<String> wordDict, int start)
        {
            if (start == s.Length)
            {
                return true;
            }
            for (int end = start + 1; end <= s.Length; end++)
            {
                //! rather than end-start we can also use end only
                //! second argument to Substring corresponds to length
                //! e.g. sands and assume end pointer is at last than 4 characters excluding s and hence the reason where we are specifying 
                //! <= in for loop
                //! Rather than passing s in word_break() we can also pass substring starting from end
                //! e.gword_Break(s.Substring(end),0,hs) as it implies the same thing. 
                if (wordDict.Contains(s.Substring(start, end - start)) && word_Break(s, wordDict, end))
                {
                    return true;
                }
            }
            return false;
        }        
    }
}
