using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _918
    {

        public static void _918Main()
        {
            int[] array = new int[] { -2, -3, -1 };
            _918 CircularSum = new _918();

            var ans = CircularSum.MaxSubarraySumCircular(array);
            Console.ReadLine();

        }



//      # <image url="$(SolutionDir)\Images\918.png"  scale="0.8"/>
        /// <summary>
        //! Apply Kadane's algorithm for getting max sum for non-circular case &  max subarray sum for circular 
        //! Answer=Max(maxSubArray sum non-circular ,maxSubArray sum circular)
        //! How to calculate "maxSubArray sum circular"=(sum - min sub array sum)
        //! min sub array sum
        //! 1. Negate all sub array elements  
        //! 2. Apply Kandanes algorithm to calculate max sub array sum
        //! 3. Negate maxsub array sum to get min sub array sum
        /// </summary>

        public int MaxSubarraySumCircular(int[] nums)
        {
            int sum = nums.Sum();
            int maxSum = nums[0];
            int minSum = nums[0];
            int maxSumSoFar = nums[0];
            int minSumSoFar = nums[0];
            for (int i = 1; i < nums.Length; ++i)
            {
                int curr = nums[i];
                maxSumSoFar = Math.Max(curr, maxSumSoFar + curr);
                maxSum = Math.Max(maxSum, maxSumSoFar);

                minSumSoFar = Math.Min(curr, minSumSoFar + curr);
                minSum = Math.Min(minSum, minSumSoFar);
            }
            //! in case array contains all negative numbers 
            return maxSum > 0 ? Math.Max(maxSum, sum - minSum) : maxSum;
        }

    }
}
