﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _152
    {

        /// <summary>
        //! We need to keep track of maxSoFar,minSoFar subarray at every index 
        /// </summary>
        public int MaxProduct(int[] nums)
        {          

            int maxSoFar = nums[0];
            int minSoFar = nums[0];
            int max = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                int temp = maxSoFar;

                maxSoFar = Math.Max(nums[i], Math.Max(nums[i] * maxSoFar, nums[i] * minSoFar));

                minSoFar = Math.Min(nums[i], Math.Min(nums[i] * temp, nums[i] * minSoFar));

                if (maxSoFar > max)
                {
                    max = maxSoFar;
                }
            }
            return max;
        }
    }
}
