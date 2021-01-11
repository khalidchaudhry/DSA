using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _3
    {

        /// <summary>
        //! HashSet approach  
        /// </summary>
        public int LengthOfLongestSubstring(string s)
        {
            HashSet<char> hs = new HashSet<char>();
            int ans = 0;

            int i = 0;
            int j = 0;
            //! Different template for variable size sliding window
            //! Here we need to either increment i or j because for some test cases like "aab" it will fail
            while (j < s.Length)
            {
                if (!hs.Contains(s[j]))
                {
                    hs.Add(s[j]);
                    ++j;
                    ans = Math.Max(ans, hs.Count);

                }
                else
                {
                    hs.Remove(s[i]);
                    ++i;
                }
            }
            return ans;
        }


        /*!
         Sliding window problem having start and end.
         We slide start forward as soon as we encounter the repeating character in string
         Key is not to slide start backward by using below line
           start = Math.Max(start, map[s[end]] + 1);          
        
        Example input: "pwwkew","au","dvdf","abba","abcabcbb"
        */
        public int LengthOfLongestSubstring0(string s)
        {
            if (s.Length <= 1)
                return s.Length;

            int longestSubstring = 0;
            //! Key is the character and value is the its last seen index
            Dictionary<char, int> map = new Dictionary<char, int>();
            int i = 0;
            for (int j = 0; j < s.Length; j++)
            {
                if (map.ContainsKey(s[j]))
                {
                    //! Reason for below line  is we don't want to go back 
                    //!  in case we encounter the character again and its index is less than where we are right now
                    //! e.g. abba
                    i = Math.Max(i, map[s[j]] + 1);

                    map[s[j]] = j;
                }
                else
                {
                    map.Add(s[j], j);
                }

                longestSubstring = Math.Max(longestSubstring, j - i + 1);
            }
            return longestSubstring;
        }


    }
}
