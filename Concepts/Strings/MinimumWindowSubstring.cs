using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class MinimumWindowSubstring
    {

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
                    lettersSeen[t[i]] = 0;
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
