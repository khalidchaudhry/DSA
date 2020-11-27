using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeHashTable.Medium
{
    public class _347
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            if (nums.Length == 0 || k == 0)
                return new int[] { };

            Dictionary<int, int> map = new Dictionary<int, int>();
            int totalBuckets = BuildFrequency(nums, map);

            List<int>[] buckets = new List<int>[totalBuckets + 1];
            PopulateBuckets(map, buckets);

            return TopK(buckets, k);
        }


        //! Using sorted set 
        //! Time comlexity=O(kn) where k are the top k items 
        //! Space complexity=O(n+k)
        public int[] TopKFrequent2(int[] nums, int k)
        {

            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; ++i)
            {
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], 0);
                }
                ++map[nums[i]];
            }

            SortedSet<(int freq, int val)> ss = new SortedSet<(int freq, int val)>();

            foreach (var keyValue in map)
            {
                ss.Add((keyValue.Value, keyValue.Key));//! worst case O(n)
                if (ss.Count > k)
                {
                    ss.Remove(ss.Min); //! worst case O(n)
                }
            }

            int[] result = new int[k];
            foreach ((int freq, int val) in ss)
            {
                result[--k] = val;
            }

            return result;
        }

        private int BuildFrequency(int[] nums, Dictionary<int, int> map)
        {

            int max = 0;
            foreach (int num in nums)
            {
                if (map.ContainsKey(num))
                    ++map[num];
                else
                    map.Add(num, 1);

                max = Math.Max(map[num], max);
            }
            return max;
        }
        private void PopulateBuckets(Dictionary<int, int> map, List<int>[] buckets)
        {
            for (int i = 0; i < buckets.Length; ++i)
            {
                buckets[i] = new List<int>();
            }

            foreach (var keyValue in map)
            {
                buckets[keyValue.Value].Add(keyValue.Key);
            }
        }
        private int[] TopK(List<int>[] buckets, int k)
        {
            List<int> topK = new List<int>();
            for (int i = buckets.Length - 1; i >= 0; --i)
            {
                for (int j = 0; j < buckets[i].Count; ++j)
                {
                    topK.Add(buckets[i][j]);
                    if (topK.Count == k)
                        return topK.ToArray();
                }
            }

            return topK.ToArray();
        }

    }
}
