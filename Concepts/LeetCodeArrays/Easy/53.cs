using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _53
    {
        //! Kadane's algorithm(dynamic programming)
        public int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int curr_max = nums[0], global_max = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                curr_max = Math.Max(nums[i], nums[i] + curr_max);

                global_max = Math.Max(curr_max, global_max);
            }

            return global_max;
        }
        //https://www.codesdope.com/blog/article/maximum-subarray-sum-using-divide-and-conquer/
        //!Divide and conquer
        public int MaxSubArray2(int[] nums)
        {
            int lo = 0;
            int hi = nums.Length - 1;

            return MaxSubArray2(nums, lo, hi);
        }

        private int MaxSubArray2(int[] nums, int lo, int hi)
        {
            if (lo == hi)
            {
                return nums[hi];
            }

            int mid = lo + ((hi - lo) / 2);
            //! include the mid point
            int leftSubArraySum = MaxSubArray2(nums, lo, mid);

            int rightSubArraySum = MaxSubArray2(nums, mid + 1, hi);

            int crossingSubArraySum = CrossingSubArraySum(nums, lo, mid, hi);

            return Math.Max(Math.Max(leftSubArraySum, rightSubArraySum), crossingSubArraySum);

        }

        private int CrossingSubArraySum(int[] nums, int lo, int mid, int hi)
        {
            int leftSideSum = int.MinValue;
            int sum = 0;
            for (int i = mid; i >= lo; i--)
            {
                sum += nums[i];
                if (sum > leftSideSum)
                {
                    leftSideSum = sum;
                }
            }

            int rightSideSum = int.MinValue;
            sum = 0;
            for (int i = mid + 1; i <= hi; i++)
            {
                sum += nums[i];
                if (sum > rightSideSum)
                {
                    rightSideSum = sum;
                }
            }

            return leftSideSum + rightSideSum;
        }
    }
}
