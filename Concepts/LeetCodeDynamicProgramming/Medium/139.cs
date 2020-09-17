using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    class _139
    {
        /// <summary>
        // !Dynamic programming solution 
        //!Time complexity : O(n^2)Two loops are their to fill text dp array.
        //!Space complexity : O(n) Length of dp array is n+1n+1.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public bool WordBreak0(string s, IList<string> wordDict)
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
        /// <summary>
        //! Does not work for this input "aaaaaaa"
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public bool WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> hs = new HashSet<string>();
            foreach (string word in wordDict)
            {
                hs.Add(word);
            }

            for (int i = 0, j = 0; j < s.Length; j++)
            {
                if (hs.Contains(s.Substring(i, j - i + 1)))
                {
                    if (j == s.Length - 1)
                    {
                        return true;
                    }
                    i = j + 1;
                    continue;
                }
            }
            return false;
        }

        /// <summary>
        //!Brute Force Approach
        //! Recursively calling function
        // ! changing start index with every reucursive call and end index is end=start+1 Index
        //! Complexity Analysis: 
        //Time complexity : O(n^n)
        //Consider the worst case where ss = "\text{aaaaaaa}aaaaaaa" and every prefix of ss 
        //is present in the dictionary of words, then the recursion tree can grow upto n^n
        //Space complexity : O(n) O(n). The depth of the recursion tree can go upto nn.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public bool WordBreak2(string s, IList<string> wordDict)
        {
            HashSet<string> hs = new HashSet<string>();
            foreach (string word in wordDict)
            {
                hs.Add(word);
            }
            return word_Break(s, hs, 0);
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
                //! second argument to Substring corresponds to length and we take length one less than where end pointer is
                //! e.g. sands and assume end pointer is at s than 4 characters excluding s and hence the reason where we are specifying 
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
