using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeSlidingWindow.Medium
{
    public class _567
    {

        public static void _567Main()
        {
            _567 Permutations = new _567();

            string s1 = "abcdxabcde";
            string s2 = "abcdeabcdx";
            var result=Permutations.CheckInclusion(s1, s2);
        }

        public bool CheckInclusion(string s1, string s2)
        {
            int s1Length = s1.Length;
            int s2Length = s2.Length;
            if (s1Length == 0 || s2Length == 0 || s1Length == 0 || s1Length > s2Length)
                return false;

            int[] s1Map = new int[26];
            int[] s2Map = new int[26];

            //! Create the map that contains character frequency. We will  also calcuate frequency for first window
            for (int i = 0; i < s1.Length; ++i)
            {
                ++s1Map[s1[i] - 'a'];
                ++s2Map[s2[i] - 'a'];// ! calculating the first window of s2 
            }

            //!s2Length - s1Length because we already calculated the first window 
            for (int i = 0; i < s2Length - s1Length; ++i)
            {
                if (AreEqual(s1Map, s2Map)) return true;
                //! right most character in sliding window
                char rightMostCharacter = s2[s1Length + i];
                //! left most character in the sliding window
                char leftMostCharacter = s2[i];
                ++s2Map[rightMostCharacter - 'a']; //! increasing the window from  the right side. 
                --s2Map[leftMostCharacter - 'a']; //! decreasing the window from  the left side. 
            }
            //!in case both the strings are of same length , above loop will not detect it
            return AreEqual(s1Map,s2Map);

        }

        private bool AreEqual(int[] s1Map, int[] s2Map)
        {
            for (int i = 0; i < 26; ++i)
            {
                if (s1Map[i] != s2Map[i]) return false;
            }
            return true;
        }
    }
}
