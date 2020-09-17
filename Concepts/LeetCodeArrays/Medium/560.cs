﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _560
    {

        public static void _560Main()
        {
            int[] nums = new int[] { 1, 1, 1 };

            _560 subArraySum = new _560();
            subArraySum.SubarraySum(nums, 2);

        }


        //https://www.youtube.com/watch?v=AmlVSNBHzJg
        //https://www.youtube.com/watch?v=HbbYPQc-Oo4
        public int SubarraySum0(int[] nums, int k)
        {
            int n = nums.Length;
            if (n == 0) return 0;
            int result = 0;
            int leftSum = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            //! Reason we are adding  zero is because when we calculate subarray sum from i to j , 
            //! we take difference between i and j index and adding 0 really gives us convenience 
            //!                   i        j
            //! e.g. for array [3,4, 7, 2,-3, 1, 4, 2 ]
            //! current_sum [0, 3,7,14,16,13, 14,18,20]

            //! Below video for more explanation
            //https://youtu.be/HbbYPQc-Oo4?t=122
            map.Add(0, 1);
            for (int i = 0; i < nums.Length; ++i)
            {
                leftSum += nums[i];

                if (map.ContainsKey(leftSum - k))
                {
                    result += map[leftSum - k];
                }
                if (map.ContainsKey(leftSum))
                    ++map[leftSum];
                else
                    map[leftSum] = 1;
            }

            return result;
        }

        public int SubarraySum(int[] nums, int k)
        {
            int n = nums.Length;
            if (n == 0) return 0;
            int result = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                int sum = 0;
                for (int j = i; j < nums.Length; ++j)
                {
                    sum += nums[i];
                    if (sum == k) ++result;
                }
            }

            return result;
        }


    }
}
