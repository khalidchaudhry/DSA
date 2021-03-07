using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _647
    {

        /// <summary>
        //! We are iterating over the length of substring to caculate the palindromic permutation
        //! Sliding window of size 1......n
        /// </summary>
        public int CountSubstrings(string s)
        {

            bool[,] isPalindrome = new bool[s.Length, s.Length];
            int count = 0;
            for (int l = 1; l <= s.Length; ++l)
            {
                for (int start = 0; start <= s.Length - l; ++start)
                {
                    int end = start + l - 1;
                    if (start == end)
                        isPalindrome[start, end] = true;
                    else if (l == 2)
                        isPalindrome[start, end] = s[start] == s[end];
                    else
                        isPalindrome[start, end] = s[start] == s[end] && isPalindrome[start + 1, end - 1];

                    if (isPalindrome[start, end])
                        ++count;
                }
            }

            return count;

        }


    }
}
