using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _152
    {

        public int MaxProduct(int[] nums)
        {
            if (nums.Length < 1)
            {
                return 0;
            }

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
        /// <summary>
        //! Brute force 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxProduct2(int[] nums)
        {
            if (nums.Length < 1)
            {
                return 0;
            }

            int globalMax = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                int maxProduct = nums[i];
                int runningProduct = nums[i];

                for (int j = i + 1; j < nums.Length; ++j)
                {
                    runningProduct = runningProduct *nums[j];
                    maxProduct =Math.Max(maxProduct,runningProduct);
                }

                globalMax = Math.Max(globalMax,maxProduct);
            }

            return globalMax;
        }
    }
}
