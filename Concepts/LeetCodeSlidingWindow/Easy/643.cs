using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Easy
{
    class _643
    {

        public double FindMaxAverage(int[] nums, int k)
        {

            int windowSum = 0;
            int maxSum = 0;
            for (int i = 0; i < k; ++i)
            {
                windowSum += nums[i];
            }

            maxSum = windowSum;

            for (int i = k; i < nums.Length; ++i)
            {
                windowSum = windowSum - nums[i - k] + nums[i];
                maxSum = Math.Max(windowSum, maxSum);
            }
            return (double)maxSum / k;

        }

    }
}
