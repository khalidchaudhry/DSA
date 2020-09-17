﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    public class _1283
    {
        public static void _1283Main()
        {
            int[] nums = new int[] { 1, 2, 5, 9 };
            int threshold = 6;
            _1283 Divisor = new _1283();

            var ans = Divisor.SmallestDivisor(nums, threshold);

            Console.ReadLine();


        }
        public int SmallestDivisor(int[] nums, int threshold)
        {
            int left = 1;
            int right = Max(nums);

            while (left < right)
            {
                int mid = left + ((right - left) / 2);
                if (AboveThreshold(nums, threshold, mid))
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        private bool AboveThreshold(int[] nums, int threshold, int mid)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; ++i)
            {   
                //! Casting to decimal is necessary , else the result will be 0 for some cases like 1/3
                sum += (int)Math.Ceiling((decimal)nums[i] /mid);
            }

            return sum > threshold;
        }

        private int Max(int[] nums)
        {
            int max = nums[0];
            for (int i = 1; i < nums.Length; ++i)
            {
                max = Math.Max(nums[i], max);
            }

            return max;
        }
    }
}
