using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy
{
    class _392
    {
        public bool IsSubsequence(string s, string t)
        {
            // empty string is always a subsequence of given string
            if (s.Length == 0)
                return true;

            bool isSubSequence = false;
            int i = 0, j = 0;

            while (i < s.Length)
            {
                isSubSequence = false;

                while (j < t.Length)
                {
                    if (s[i] == t[j])
                    {
                        isSubSequence = true;
                        ++j;
                        break;
                    }
                    ++j;
                }
                if (!isSubSequence)
                {
                    break;
                }

                ++i;
            }

            return isSubSequence;

        }

        // Use two pointers 
        public bool IsSubsequence2(String s, String t)
        {
            if (s.Length == 0) return true;
            int indexS = 0, indexT = 0;
            while (indexT < t.Length)
            {
                if (t[indexT] == s[indexS])
                {
                    indexS++;
                    if (indexS == s.Length) return true;
                }

                indexT++;
            }
            return false;
        }
    }
}
