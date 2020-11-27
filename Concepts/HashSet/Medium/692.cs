using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeHashTable.Medium
{
    public class _692
    {

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
