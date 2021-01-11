using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Medium
{
    public class _424
    {

        /// <summary>
        //! Sliding window of variable size
        /// </summary>
        
        public int CharacterReplacement(string s, int k)
        {
            //! Key is character and value is their occurances. 
            Dictionary<char, int> FreqCount = new Dictionary<char, int>();

            int longest = 0;
            int i = 0;
            for (int j = 0; j < s.Length; ++j)
            {
                if (!FreqCount.ContainsKey(s[j]))
                {
                    FreqCount.Add(s[j], 0);
                }
                ++FreqCount[s[j]];

                //!how many letters in current window  needs replacement.                
                //!j - i + 1=length of of string/lenfth of our window
                //! subtracting max count gives the characters that needs replacement as we don't need to replace most frequent ones
                while (j - i + 1 - MostCommonCount(FreqCount) > k)
                {
                    --FreqCount[s[i]];
                    ++i;
                }
                //! current window / substring is valid till 
                //! the number of characters that need to be replaced is <= k.
                longest = Math.Max(longest, j - i + 1);
            }
            return longest;

        }
        public int MostCommonCount(Dictionary<char, int> freqCount)
        {
            int count = 0;
            foreach (var keyValue in freqCount)
            {
                count = Math.Max(count, keyValue.Value);

            }
            return count;
        }
    }
}
