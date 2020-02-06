using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _697
    {
        public int FindShortestSubArray(int[] nums)
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    List<int> values = dict[nums[i]];
                    //increment count 
                    ++values[0];
                    // last seen endindex
                    values[2] = i;
                }
                else
                {
                    List<int> values = new List<int>();
                    //count
                    values.Add(1);
                    //First Index
                    values.Add(i);
                    //LastIndex
                    values.Add(i);
                    dict.Add(nums[i], values);
                }
            }

            int shortestSubArrayLength = Int32.MaxValue;
            int maxCount = Int32.MinValue;
            foreach (var item in dict)
            {
                if (item.Value[0] > maxCount)
                {
                    shortestSubArrayLength = item.Value[2] - item.Value[1] + 1;
                    maxCount = item.Value[0];
                }
                else if (item.Value[0] == maxCount)
                {
                    shortestSubArrayLength = Math.Min(shortestSubArrayLength, (item.Value[2] - item.Value[1] + 1));
                }
            }
            return shortestSubArrayLength;
        }
    }
}
