using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeHashTable.Medium
{
    public class _347
    {

        /// <summary>
        //!Bucket sort 
        /// </summary>
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> freqMap = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!freqMap.ContainsKey(num))
                {
                    freqMap.Add(num, 0);
                }
                ++freqMap[num];
            }

            int n = nums.Length + 1;
            List<int>[] buckets = new List<int>[n];
            for (int i = 0; i < n; ++i)
            {
                buckets[i] = new List<int>();
            }

            foreach (var keyValue in freqMap)
            {
                buckets[keyValue.Value].Add(keyValue.Key);
            }

            int[] topK = new int[k];
            for (int i = n - 1; i >= 0; --i)
            {
                for (int j = 0; j < buckets[i].Count && k > 0; ++j)
                {
                    topK[--k] = buckets[i][j];
                }
            }

            return topK;

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
           
        }

    }
}
