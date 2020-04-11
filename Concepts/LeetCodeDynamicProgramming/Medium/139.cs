using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    class _139
    {
        public bool WordBreak0(string s, IList<string> wordDict)
        {
            HashSet<string> hs = new HashSet<string>();

            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;

            foreach (string word in wordDict)
            {
                hs.Add(word);
            }

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[j] && hs.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                    }
                }
            }

            return dp[s.Length];
        }

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

        public bool WordBreak2(string s, IList<string> wordDict)
        {
            HashSet<string> hs = new HashSet<string>();
            foreach (string word in wordDict)
            {
                hs.Add(word);
            }
            return word_Break(s, hs, 0);
        }
        public bool word_Break(String s, HashSet<String> wordDict, int start)
        {
            if (start == s.Length)
            {
                return true;
            }
            for (int end = start + 1; end <= s.Length; end++)
            {
                if (wordDict.Contains(s.Substring(start, end - start)) && word_Break(s, wordDict, end))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
