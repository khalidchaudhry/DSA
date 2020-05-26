using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class PermutationsInString
    {
        public bool CheckInclusion(string s1, string s2)
        {
            int s1Len = s1.Length;
            int s2Len = s2.Length;

            if (s2.Length == 0 || s1Len > s2Len)
                return false;

            int[] s1Arr = new int[26];
            int[] s2Arr = new int[26];

            // !Put character count of array s1 in pArr
            // !Also create first window of size s1Len in s2 string
            for (int i = 0; i < s1Len; i++)
            {
                ++s1Arr[s1[i] - 'a'];
                ++s2Arr[s2[i] - 'a'];
            }
            //! s2Len-s1Len because we already have the first window so no need to iterate till s2 Length
            for (int i = 0; i < s2Len - s1Len; i++)
            {
                if (IsPermutation(s1Arr, s2Arr))
                    return true;
                //!Sliding window 
                //!Remove the character at the ith index and add element at i_sLen index
                s2Arr[s2[i] - 'a']--;
                s2Arr[s2[i+s1Len] - 'a']++;
            }

            return false;

        }

        private bool IsPermutation(int[] s1Arr, int[] s2Arr)
        {
            for (int i = 0; i < s1Arr.Length; i++)
            {
                if (s1Arr[i] != s2Arr[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
