using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeHeap.Medium
{
    public class _347
    {
        public static void _347Main()
        {
            _347 test = new _347();
            int[] nums = new int[] {1, 1, 1, 2, 2, 3 };
            int k = 2;
            var result=test.TopKFrequent1(nums,k);
            Console.ReadLine();

        }

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

            //! size is nums.Length + 1 since we want to store the count at that index 
            //! e.g. given array [1,1] then we will store its value at index 2 

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
                foreach (int item in buckets[i])
                {
                    if (k != 0)
                    {
                        topK[--k] = item;
                    }
                }
            }

            return topK;
        }

        /// <summary>
        //! T=O(nlogk)
        //! S=O(n)+O(k)=Freq map +Heap
        /// </summary>
        public int[] TopKFrequent1(int[] nums, int k)
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

            //! Min heap and min is frequency 
            PQ<int> pq = new PQ<int>(comparer);

            foreach (var keyValue in freqMap)
            {
                pq.Add(keyValue.Key);
                if (pq.Size > k)
                {
                    //! we will poll an element having min frequency
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
    }
}
