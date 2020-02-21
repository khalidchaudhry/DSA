using System;
using System.Collections.Generic;
using System.Text;

namespace HashSet
{
    class _389
    {
        public char FindTheDifference(string s, string t)
        {
            int[] arr = new int[26];
            char difference= '\0';
            for (int i = 0; i < s.Length; i++)
            {
                ++arr[s[i] - 'a'];
            }
            for (int j = 0; j < t.Length; j++)
            {
                --arr[t[j]-'a'];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                   difference= (char)(i+'a');
                }
            }
            return difference;
        }
        public char FindTheDifference2(string s, string t)
        {
            int difference=0;
            for (int i = 0; i < s.Length; i++)
            {
                difference ^= s[i];
            }

            for (int i = 0; i < t.Length; i++)
            {
                difference ^= t[i];
            }
            return (char)difference;
        }

    }
}
