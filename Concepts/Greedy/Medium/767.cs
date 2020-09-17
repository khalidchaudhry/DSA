using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Greedy.Medium
{
    class _767
    {
        public static void _767Main()
        {
            _767 Reorganize = new _767();

            string s = "aaab";

            var result=Reorganize.ReorganizeString0(s);

            Console.ReadLine();
        }
        //Kai class
        public string ReorganizeString0(string S)
        {
            Dictionary<char, int> frequencyCount = CreateFrequencyCountMap(S);

            frequencyCount = frequencyCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            int maxCount = frequencyCount.ElementAt(0).Value;

            if (maxCount > (S.Length + 1) / 2)
                return string.Empty;

            StringBuilder[] buckets = new StringBuilder[maxCount];
            //!initiazliing buckets 
            for (int b = 0; b < buckets.Length; ++b)
            {
                buckets[b] = new StringBuilder();
            }

            //! round robin 
            int i = 0;
            foreach (KeyValuePair<char, int> keyValue in frequencyCount)
            {
                for (int j = 0; j < keyValue.Value; ++j)
                {
                    buckets[i % maxCount].Append(keyValue.Key);
                    ++i;
                }
            }

            StringBuilder result = new StringBuilder();
            foreach (StringBuilder bucket in buckets)
            {
                result.Append(bucket);
            }

            return ValidateResult(result.ToString());
        }

        private string ValidateResult(string result)
        {
            for (int i = 0; i < result.Length - 1; ++i)
            {
                if (result[i] == result[i + 1])
                    return string.Empty;
            }

            return result;
        }

        private Dictionary<char, int> CreateFrequencyCountMap(string s)
        {

            Dictionary<char, int> frequencyCount = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; ++i)
            {
                if (frequencyCount.ContainsKey(s[i]))
                {
                    ++frequencyCount[s[i]];
                }
                else
                {
                    frequencyCount[s[i]] = 1;
                }
            }
            return frequencyCount;

        }

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
            //! place the highest frequently characters first into even index number (0, 2, 4 ...) char array
            char maxFreqCharacter = Convert.ToChar(maxfreqLetterIndex + 'a');
            while (charMap[maxfreqLetterIndex] > 0)
            {

                result[idx] = maxFreqCharacter;
                idx += 2;
                --charMap[maxfreqLetterIndex];
            }

            for (int i = 0; i < charMap.Length; i++)
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
