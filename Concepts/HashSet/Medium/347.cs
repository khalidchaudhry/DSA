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


    }
}
