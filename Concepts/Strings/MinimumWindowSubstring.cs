using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class MinimumWindowSubstring
    {

        /// <summary>
        /// https://medium.com/leetcode-patterns/leetcode-pattern-2-sliding-windows-for-strings-e19af105316b
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public string MinWindow0(string s, string t)
        {

            Dictionary<char, int> lettersNeeded = new Dictionary<char, int>();

            // initialize frequency table for t
            foreach (char c in t)
            {
                if (lettersNeeded.ContainsKey(c))
                {
                    lettersNeeded[c]++;
                }
                else
                {
                    lettersNeeded.Add(c,1);
                }
                
            }

            // initialize sliding window
            int begin = 0, end = 0;
            //!assuring that every unique character in T exists in B as many times as it exists in T by maintaining a counter
            int lettersMissing = lettersNeeded.Count;
            int len = int.MaxValue;

            string ans = "";

            // start sliding window
            while (end < s.Length)
            {
                char endchar = s[end];

                // if current char found in table, decrement count
                if (lettersNeeded.ContainsKey(endchar))
                {
                    lettersNeeded[endchar]--;
                    if (lettersNeeded[endchar] == 0)
                        lettersMissing--;
                }

                end++;

                // if counter == 0, means we found an answer, now try to trim that window by sliding begin to right.
                while (lettersMissing == 0)
                {
                    // store new answer if smaller than previously best
                    if (end - begin < len)
                    {
                        len = end - begin;
                        ans = s.Substring(begin, end - begin);
                    }

                    // begin char could be in table or not, 
                    // if not then good for us, it was a wasteful char and we shortened the previously found substring.

                    // if found in table increment count in table, as we are leaving it out of window and moving ahead, 
                    // so it would no longer be a part of the substring marked by begin-end window
                    // table only has count of chars required to make the present substring a valid candidate
                    // if the count goes above zero means that the current window is missing one char to be an answer candidate
                    char startchar = s[begin];

                    if (lettersNeeded.ContainsKey(startchar))
                    {
                        lettersNeeded[startchar]++;
                        if (lettersNeeded[startchar] > 0) lettersMissing++;
                    }

                    begin++;
                }
            }

            return ans;                     
        }

        public string MinWindow(string s, string t)
        {
            Dictionary<char, int> lettersNeeded = new Dictionary<char, int>();
            Dictionary<char, int> lettersSeen = new Dictionary<char, int>();
            int lettersMissing = 0;


            for (int i = 0; i < t.Length; i++)
            {
                if (lettersNeeded.ContainsKey(t[i]))
                {
                    ++lettersNeeded[t[i]];
                }
                else
                {
                    lettersNeeded.Add(t[i], 1);
                    lettersSeen.Add(t[i], 0);
                    lettersMissing += 1;
                }
            }

            int fast = 0;
            int slow = 0;

            int[] result = new int[] { 0, int.MaxValue };

            for (; fast < s.Length; fast++)
            {

                if (lettersNeeded.ContainsKey(s[fast]))
                {
                    lettersSeen[s[fast]] += 1;
                    if (lettersSeen[s[fast]] == lettersNeeded[s[fast]])
                    {
                        lettersMissing -= 1;
                    }
                }
                // Till lettersMissing are zero u will keep shrinking the window. 
                while (lettersMissing == 0)
                {
                    if (fast - slow < result[1] - result[0])
                    {
                        result[0] = slow;
                        result[1] = fast;
                    }
                    if (lettersNeeded.ContainsKey(s[slow]))
                    {
                        lettersSeen[s[slow]] -= 1;
                        if (lettersSeen[s[slow]] < lettersNeeded[s[slow]])
                        {
                            lettersMissing += 1;
                        }
                    }

                    slow++;
                }
            }

            return result[1] == int.MaxValue ? "" : s.Substring(result[0], result[1] - result[0]+1);

        }
    }
}
