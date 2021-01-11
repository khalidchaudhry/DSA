using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Medium
{
    class _340
    {
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {

            Dictionary<char, int> freqCount = new Dictionary<char, int>();
            int longestSubString = 0;

            int i = 0;
            for (int j = 0; j < s.Length; ++j)
            {
                Add(freqCount, s[j]);
                while (freqCount.Count > k)
                {
                    --freqCount[s[i]];
                    if (freqCount[s[i]] == 0)
                        freqCount.Remove(s[i]);
                    ++i;
                }

                longestSubString = Math.Max(longestSubString, j - i + 1);
            }

            return longestSubString;
        }
        private void Add(Dictionary<char, int> freqCount, char c)
        {
            if (!freqCount.ContainsKey(c))
                freqCount.Add(c, 0);

            ++freqCount[c];
        }
    }
}
