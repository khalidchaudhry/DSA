using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _767
    {

        /// <summary>
        /// https://leetcode.com/problems/reorganize-string/discuss/232469/Java-No-Sort-O(N)-0ms-beat-100
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public string ReorganizeString(string S)
        {
            int[] charMap = new int[26];

            int n = S.Length;

            for (int i = 0; i < n; i++)
            {
                charMap[S[i] - 'a']++;
            }

            char[] result = new char[n];
            //Find the first highest frequency item as we need to place them first in our resultant array
            int maxFreq = 0;
            int maxfreqLetterIndex = 0;

            for (int i = 0; i < charMap.Length; i++)
            {
                if (charMap[i] > maxFreq)
                {
                    maxFreq = charMap[i];
                    maxfreqLetterIndex = i;
                }
            }
            // If  max frequency > (N + 1) / 2, the task is impossible as we can't place them .
            if (maxFreq > ((n + 1) / 2))
                return string.Empty;


            int idx = 0;
            //! place the highest frequently characters first
            char maxFreqCharacter = Convert.ToChar(maxfreqLetterIndex + 'a');
            while (charMap[maxfreqLetterIndex] > 0)
            {

                result[idx] = maxFreqCharacter;
                idx += 2;
                --charMap[maxfreqLetterIndex];
            }

            for (int i = 0; i <charMap.Length; i++)
            {
                if (charMap[i] == 0)
                    continue;

                while (charMap[i] > 0)
                {
                    //!Because we can reach the end and we want to add new letter at the first available position.
                    //! Notice that this will happen once because if that's not the case, 
                    //!then more slots would have been needed to add at the end of our result.
                    if (idx >= result.Length)
                    {
                        idx = 1;
                    }
                    result[idx] = Convert.ToChar(i + 'a');
                    idx += 2;
                    charMap[i]--;
                }
            }

            return new string(result);
        }
    }
}
