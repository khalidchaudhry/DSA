using Greedy;
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

            Dictionary<int, int> freqMap = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!freqMap.ContainsKey(num))
                {
                    freqMap.Add(num, 0);
                }
                ++freqMap[num];
            }
            var comparer = Comparer<int>.Create((x, y) => {

                if (freqMap[x] == freqMap[y])
                {
                    return x.CompareTo(y);
                }

                return freqMap[x].CompareTo(freqMap[y]);
            });

            PQ<int> pq = new PQ<int>(comparer);

            foreach (var keyValue in freqMap)
            {
                pq.Add(keyValue.Key);
                if (pq.Size > k)
                {
                    pq.Poll();
                }
            }

            int[] topK = new int[k];
            int index = 0;
            while (pq.Size != 0)
            {
                topK[index++] = pq.Poll();
            }
            return topK;
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
        
       

    }
}
