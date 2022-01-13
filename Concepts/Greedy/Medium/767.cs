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

            string s = "aab";

            var result = Reorganize.ReorganizeString0(s);

            Console.ReadLine();
        }

        public string ReorganizeString(string S)
        {
            Dictionary<char, int> charFreq = new Dictionary<char, int>();
            foreach (char c in S)
            {
                if (!charFreq.ContainsKey(c))
                {
                    charFreq.Add(c, 0);
                }
                ++charFreq[c];
            }

            var comparer = Comparer<(int freq, Char c)>.Create((x, y) => {

                if (x.freq == y.freq)
                    return x.c.CompareTo(y.c);

                return y.freq.CompareTo(x.freq);

            });

            PQ<(int freq, Char c)> pq = new PQ<(int freq, Char c)>(comparer);

            foreach (var keyValue in charFreq)
            {
                pq.Add((keyValue.Value, keyValue.Key));
            }

            StringBuilder sb = new StringBuilder();
            while (pq.Size != 0)
            {
                (int freq1, char char1) = pq.Poll();
                sb.Append(char1);
                --freq1;

                if (pq.Size != 0)
                {
                    (int freq2, char char2) = pq.Poll();
                    sb.Append(char2);
                    --freq2;
                    if (freq2 != 0)
                    {
                        pq.Add((freq2, char2));
                    }
                }
                if (freq1 != 0)
                {
                    pq.Add((freq1, char1));
                }
            }

            string result = sb.ToString();
            for (int i = 0; i < result.Length - 1; ++i)
            {
                if (result[i] == result[i + 1])
                    return string.Empty;
            }

            return result;

        }

        //Kai class
        //! Same concept as in 621,767
        public string ReorganizeString0(string S)
        {
            Dictionary<char, int> frequencyCount = BuildFrequencyMap(S);

            frequencyCount = frequencyCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            int maxCount = frequencyCount.ElementAt(0).Value;
            //! if maxCount > (stringLength+1)/2 then its not possible to rearrange so that they are not conecutive
            //! e.g "aab" should be good but if we use maxCount>s.Length/2 then it will give wrong result 
            //! Same as below line (int)Math.Ceiling((double)S.Length / 2))
            if (maxCount > (S.Length + 1) / 2)
                return string.Empty;

            StringBuilder[] buckets = new StringBuilder[maxCount];
            InitializeBuckets(buckets);

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

        private Dictionary<char, int> BuildFrequencyMap(string s)
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

        private void  InitializeBuckets(StringBuilder[] buckets)
        {
            //!initiazliing buckets 
            for (int b = 0; b < buckets.Length; ++b)
            {
                buckets[b] = new StringBuilder();
            }

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
        
    }
}
