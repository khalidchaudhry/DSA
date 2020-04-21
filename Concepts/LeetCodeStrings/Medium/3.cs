using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _3
    {
        /*
         Sliding window problem having start and end.
         We slide start forward as soon as we encounter the repeating character in string
         Key is not to slide start backward by using below line
           start = Math.Max(start, map[s[end]] + 1);           
        */
        public int LengthOfLongestSubstring0(string s)
        {
            if (s.Length <= 1)
                return s.Length;

            int longestSubstring = 0;

            Dictionary<char, int> map = new Dictionary<char, int>();
            int start = 0;
            for (int end = 0; end < s.Length; end++)
            {
                if (map.ContainsKey(s[end]))
                {
                    //! Reason for below line  is we don't want to go back in case we encounter the character again and its index
                    //!  is less than where we are right now
                    //! e.g. abba
                    start = Math.Max(start, map[s[end]] + 1);

                    map[s[end]] = end;
                }
                else
                {
                    map.Add(s[end], end);
                }

                longestSubstring = Math.Max(longestSubstring, end - start + 1);
            }
            return longestSubstring;
        }
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length <= 1)
                return s.Length;

            int globalMax = 0;
            int currMax = 0;

            HashSet<char> hs = new HashSet<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (hs.Contains(s[i]))
                {
                    if (currMax > globalMax)
                    {
                        globalMax = currMax;
                    }
                    hs.Clear();
                    hs.Add(s[i]);
                    currMax = 1;
                }
                else
                {
                    hs.Add(s[i]);
                    ++currMax;
                }
            }
            // handle the scnerio where input is au or 
            // longest Substring Without Repeating Characters comming in last
            globalMax = currMax > globalMax ? currMax : globalMax;

            return globalMax;
        }

        public int LengthOfLongestSubstring2(string s)
        {
            if (s.Length <= 1)
                return s.Length;

            int longestSubstring = 0;

            Dictionary<char, int> map = new Dictionary<char, int>();
            int start = 0;
            for (int end = 0; end < s.Length; end++)
            {
                if (map.ContainsKey(s[end]))
                {
                    // for string abba
                    if (s[end] > end)
                    {
                        //start = map[s[end]] + 1;
                        ++start;

                    }
                    map[s[end]] = end;
                }
                else
                {
                    map.Add(s[end], end);
                }

                longestSubstring = Math.Max(longestSubstring, end - start + 1);
            }

            return longestSubstring;
        }

        public int LengthOfLongestSubstring3(string s)
        {
            if (s.Length <= 1)
                return s.Length;

            int longestSubstring = 0;

            HashSet<char> hs = new HashSet<char>();
            int start = 0;
            for (int end = 0; end < s.Length; end++)
            {
                if (hs.Contains(s[end]))
                {
                    hs.Clear();

                    hs.Add(s[end]);

                    if (s[end - 1] == s[end])
                    {
                        start = end;
                    }
                    else
                    {
                        hs.Add(s[end - 1]);
                        start = end - 1;
                    }

                }
                else
                {
                    hs.Add(s[end]);
                }

                longestSubstring = Math.Max(longestSubstring, end - start + 1);
            }

            return longestSubstring;
        }

        public int LengthOfLongestSubstring4(string s)
        {
            if (s.Length <= 1)
                return s.Length;

            int longestSubstring = 0;

            HashSet<char> hs = new HashSet<char>();
            int end = s.Length - 1;

            for (int start = s.Length - 1; start >= 0; start--)
            {
                if (hs.Contains(s[start]))
                {
                    hs.Clear();
                    hs.Add(s[start]);
                    //end = start;
                    --end;
                }
                else
                {
                    hs.Add(s[start]);
                }

                longestSubstring = Math.Max(longestSubstring, end - start + 1);
            }

            return longestSubstring;
        }

        public int LengthOfLongestSubstring5(string s)
        {
            if (s.Length <= 1)
                return s.Length;

            int longestSubstring = 0;

            Dictionary<char, int> map = new Dictionary<char, int>();
            int end = s.Length - 1;

            for (int start = s.Length - 1; start >= 0; start--)
            {
                if (map.ContainsKey(s[start]))
                {
                    end = map[s[start]] - 1;
                    //map[s[start]] = start;
                    map.Clear();
                    map.Add(s[end], end);
                }
                else
                {
                    map.Add(s[start], start);
                }

                longestSubstring = Math.Max(longestSubstring, end - start + 1);
            }

            return longestSubstring;
        }


       
    }
}
