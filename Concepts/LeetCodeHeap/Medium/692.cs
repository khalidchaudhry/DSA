using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeHeap.Medium
{
    public class _692
    {

        public IList<string> TopKFrequent0(string[] words, int k)
        {

            Dictionary<string, int> freqMap = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; ++i)
            {
                if (!freqMap.ContainsKey(words[i]))
                {
                    freqMap.Add(words[i], 0);
                }
                ++freqMap[words[i]];
            }
            //! If frequency not equal than keep minimum one at the Heap top
            var comparer = Comparer<string>.Create((x, y) =>
            {
                if (freqMap[x] != freqMap[y])
                {
                    return freqMap[x].CompareTo(freqMap[y]);
                }
                //! If Frequency equal than word with the higher alphabetical order comes first as we are going to remove them
                return y.CompareTo(x);
            });

            List<string> result = new List<string>();

            PQ<string> pq = new PQ<string>(comparer);

            foreach (var keyValue in freqMap)
            {
                pq.Add(keyValue.Key);

                if (pq.Size > k)
                {
                    pq.Poll();
                }
            }

            while (pq.Size != 0)
            {
                result.Add(pq.Poll());
            }
            //! Since Heap top will contain last element first, reversing will return it in desired order.  
            result.Reverse();
            return result;
        }
        /// <summary>
        ///! Using Bucket approach 
        /// </summary>
        public IList<string> TopKFrequent(string[] words, int k)
        {
            if (words.Length == 0 || k == 0)
                return new List<string>();
            Dictionary<string, int> map = new Dictionary<string, int>();
            int totalBuckets = BuildFrequency(words, map);

            SortedSet<string>[] buckets = new SortedSet<string>[totalBuckets + 1];
            PopulateBuckets(map, buckets);

            return TopK(buckets, k);
        }
        private int BuildFrequency(string[] words, Dictionary<string, int> map)
        {
            int max = 0;
            foreach (string word in words)
            {
                if (map.ContainsKey(word))
                    ++map[word];
                else
                    map.Add(word, 1);

                max = Math.Max(max, map[word]);
            }

            return max;
        }
        private void PopulateBuckets(Dictionary<string, int> map, SortedSet<string>[] buckets)
        {
            for (int i = 0; i < buckets.Length; ++i)
            {
                buckets[i] = new SortedSet<string>();
            }

            foreach (var keyValue in map)
            {
                buckets[keyValue.Value].Add(keyValue.Key);
            }
        }
        private IList<string> TopK(SortedSet<string>[] buckets, int k)
        {
            List<string> result = new List<string>();
            for (int i = buckets.Length - 1; i >= 0; --i)
            {
                foreach (var item in buckets[i])
                {
                    result.Add(item);
                    if (result.Count == k)
                        return result;
                }
            }
            return result;
        }

    }
}
