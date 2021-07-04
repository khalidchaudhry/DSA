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
            int n = s.Length;
            bool[,] isPalindrome = new bool[n, n];
            int count = 0;
            for (int l = 1; l <= n; ++l)
            {

                //!Start of window of size k ending at i : i - k + 1
               //! Start of window o size l ending at n-1=n-1-l+1=n-l
                for (int start = 0; start <= n - l; ++start)
                {
                    //!end of window starting at start=start+k-1
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
