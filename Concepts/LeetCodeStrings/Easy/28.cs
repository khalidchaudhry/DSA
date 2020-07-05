using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _28
    {
        public int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
            {
                return 0;
            }

            int h = haystack.Length;
            int n = needle.Length;

            if (n > h)
                return -1;

            for (int i = 0; i <= h - n; i++)
            {
                int j;
                for (j = 0; j < n; j++)
                {
                    if (haystack[i + j] != needle[j])
                    {
                        break;
                    }
                }
                // j iterates number of times(did not break) the elements in needle array 
                if (j == n)
                {
                    return i;
                }
            }

            return -1;
        }
        /// <summary>
        /// https://leetcode.com/problems/implement-strstr/discuss/12807/Elegant-Java-solution
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr1(string haystack, string needle)
        {
            for (int i = 0; ; i++)
            {
                for (int j = 0; ; j++)
                {
                    if (j == needle.Length) return i;
                    if (i + j == haystack.Length) return -1;
                    if (needle[j] != haystack[i + j]) break;
                }

            }

        }

    }
}
