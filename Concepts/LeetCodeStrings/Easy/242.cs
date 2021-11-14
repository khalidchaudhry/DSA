using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStrings.Easy
{
    public class _242
    {

        /// <summary>
        //! We are going from target to source to validate if we can make anagram. Question is asking if we can make anagram of t from s
        /// </summary>
        public bool IsAnagram(string s, string t)
        {

            if (s.Length != t.Length)
                return false;

            Dictionary<char, int> freqMap = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!freqMap.ContainsKey(c))
                {
                    freqMap.Add(c, 0);
                }
                ++freqMap[c];
            }
            foreach (char c in t)
            {
                if (!freqMap.ContainsKey(c) || freqMap[c] == 0)
                {
                    return false;
                }

                --freqMap[c];
            }


            return true;
        }

        public bool IsAnagram2(string s, string t)
        {

            if (s.Length != t.Length)
                return false;

            int[] letters = new int[1 << 8];

            for (int i = 0; i < s.Length; i++)
                letters[s[i]]++;

            for (int i = 0; i < t.Length; i++)
                letters[t[i]]--;

            for (int i = 0; i < letters.Length; i++)
                if (letters[i] != 0)
                    return false;
            return true;
        }
    }
}
