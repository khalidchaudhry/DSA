using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class RabinKarpSearch
    {

        private int prime = 101;

        public int PatternSearch(char[] text, char[] pattern)
        {
            int m = pattern.Length;
            int n = text.Length;
            //m-1 is because its 0 based index and in loop condition is i <= end
            long patternHash = CreateHash(pattern, m - 1);
            long textHash = CreateHash(text, m - 1);
            // i=1 is because we already calculated hash for first three characters in the text
            // and next pattern matching will start from 1 index
            for (int i = 1; i <= n - m + 1; i++)
            {
                if (patternHash == textHash)
                {
                    if(CheckEqual(text, i - 1, i + m - 2, pattern, 0, m - 1))
                    return i - 1;
                }
                if (i < n - m + 1)
                {
                    textHash = RecalculateHash(text, i - 1, i + m - 1, textHash, m);
                }
            }
            return -1;
        }

        private long RecalculateHash(char[] str, int oldIndex, int newIndex, long oldHash, int patternLen)
        {
            long newHash = oldHash - str[oldIndex];
            newHash = newHash/prime;
            newHash += str[newIndex] * ((long)Math.Pow(prime, patternLen - 1));
            return newHash;
        }

        private long CreateHash(char[] str, int end)
        {
            long hash = 0;
            for (int i = 0; i <= end; i++)
            {
                hash += str[i] * ((long)Math.Pow(prime, i));
            }
            return hash;
        }

        private bool CheckEqual(char[] str1, int start1, int end1, char[] str2, int start2, int end2)
        {
            if (end1 - start1 != end2 - start2)
            {
                return false;
            }
            while (start1 <= end1 && start2 <= end2)
            {
                if (str1[start1] != str2[start2])
                {
                    return false;
                }
                start1++;
                start2++;
            }
            return true;
        }
    }
}
