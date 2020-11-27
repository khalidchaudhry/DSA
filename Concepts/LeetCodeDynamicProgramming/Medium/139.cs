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
        //!DP with memoization 
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



        /// <summary>
        // !Dynamic programming solution 
        //!Time complexity : O(n^3)Two loops are their to fill text dp array.
        //!Space complexity : O(n) Length of dp array is n+1n+1.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public bool WordBreak3(string s, IList<string> wordDict)
        {
            HashSet<string> hs = new HashSet<string>();

            bool[] dp = new bool[s.Length + 1];
            //!we initialize the element dp[0] as true, since the null string is always present in the dictionary
            dp[0] = true;

            foreach (string word in wordDict)
            {
                hs.Add(word);
            }
            // We consider substrings of all possible lengths starting from the beginning by making use of index end. 
            //  For every such substring, we partition the string into two further substrings s1'  and s2' 
            // in all possible ways using the index end
            // if the substring s1' fulfills the required criteria. If so, we further check if s2' is present in the dictionary. 
            // If both the strings fulfill the criteria, we make dp[i]  as true, otherwise as false.
            for (int end = 1; end <= s.Length; end++)
            {
                for (int start = 0; start < end; start++)
                {
                    if (dp[start] && hs.Contains(s.Substring(start, end - start)))
                    {
                        dp[end] = true;
                    }
                }
            }

            return dp[s.Length];
        }
    }
}
