using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _697
    {
        public int FindShortestSubArray(int[] nums)
        {
            // Map will contain below entries 
            /*
                 0  1  2  3  4
                [1, 2, 2, 3, 1]
                Key               Value(List of integers with three entries)
                array element     array element Count  FirstIndex  LastSeenEndIndex
                1                 2                    0           4
                2                 2                    1           2
                3                 1                    3           3
             */
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
                // ! if count is equal we need to pick one having min shortest subarray length as ask in question is to find smallest possible length of 
                // ! contiguous subarray of nums 
                else if (item.Value[0] == maxCount)
                {
                    shortestSubArrayLength = Math.Min(shortestSubArrayLength, (item.Value[2] - item.Value[1] + 1));
                }
            }
            return shortestSubArrayLength;
        }
    }
}
