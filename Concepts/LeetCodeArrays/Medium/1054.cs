using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _1054
    {
        /// <summary>
        //! Covered in Kai's class. Using bucket sort  
        //!Same pattern as in leetcode question 767,621
        /// </summary>
        public int[] RearrangeBarcodes(int[] barcodes)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            BuildFrequency(barcodes, map);
            map = map.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            int totalBuckets = map.First().Value;

            List<List<int>> buckets = new List<List<int>>();
            InitializeBuckets(buckets, totalBuckets);

            int j = 0;
            foreach (var keyValue in map)
            {
                for (int i = 0; i < keyValue.Value; ++i)
                {
                    buckets[j % totalBuckets].Add(keyValue.Key);
                    ++j;
                }
            }

            int[] result = new int[barcodes.Length];
            PrepareResult(buckets,result);
            return result;
        }
        private void BuildFrequency(int[] barcodes, Dictionary<int, int> map)
        {
            for (int i = 0; i < barcodes.Length; ++i)
            {
                if (!map.ContainsKey(barcodes[i]))
                {
                    map.Add(barcodes[i], 0);
                }
                ++map[barcodes[i]];
            }
        }
        private void InitializeBuckets(List<List<int>> buckets, int totalBuckets)
        {
            for (int i = 0; i < totalBuckets; ++i)
            {
                buckets.Add(new List<int>());
            }
        }
        private void PrepareResult(List<List<int>> buckets,int[] result)
        {
            int index = 0;
            foreach (List<int> bucket in buckets)
            {
                foreach (int item in bucket)
                {
                    result[index] = item;
                    ++index;
                }
            }
        }

    }
}
