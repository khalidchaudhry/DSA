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
            int[] result = new int[k];

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    ++map[nums[i]];
                }
                else
                {
                    map.Add(nums[i], 1);
                }
            }

            //! size is nums.Length + 1 since we want to store the count at that index 
            //! e.g. given array [1,1] then we will store its value at index 2 
            List<int>[] bucket = new List<int>[nums.Length + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            foreach (KeyValuePair<int, int> keyValue in map)
            {
                bucket[keyValue.Value].Add(keyValue.Key);
            }

            int topK = 0;

            for (int i = bucket.Length - 1; i >= 0 && topK < k; i--)
            {
                if (bucket[i].Count > 0)
                {
                    foreach (int value in bucket[i])
                    {
                        result[topK++] = value;
                        //! safeguarding against corner case
                        if (topK >= k)
                        {
                            break;
                        }
                    }
                }

            }

            return result;
        }


        public int[] TopKFrequent1(int[] nums, int k)
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

            PQ<(int freq,int val)> pq = new PQ<(int freq,int val)>();

            foreach (var keyValue in map)
            {
                pq.Add((keyValue.Value,keyValue.Key));
                if (pq.Size > k)
                {
                    pq.Poll();
                }
            }

            int[] result = new int[k];
            for (int i = 0; i < k; ++i)
            {
                result[k - i - 1] = pq.Poll().val;
            }

            return result;
        }        
    }
}
