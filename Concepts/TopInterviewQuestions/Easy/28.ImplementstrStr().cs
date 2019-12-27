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

                if (j == n)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
