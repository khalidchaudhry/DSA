using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeArrays.Easy
{
    /// <summary>
    /// https://medium.com/enjoy-algorithm/equilibrium-index-of-an-array-d1b06f067153
    /// </summary>
    public class _724
    {

        /// <summary>
        //! Time complexity=O(n) space complexity O(1)
        //! 1. Store the total sum of the array as total_sum.
        //! 2.Iterate through the array and keep track of the left_sum by adding the value at the current index and 
        //!   right_sum by subtracting the value at the current index from total_sum.
        //! 3. If left_sum equals right_sum, return the current index. Otherwise, return -1.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int PivotIndex0(int[] nums)
        {
            int n = nums.Length;
            int sumRight = nums.Sum();
            int sumLeft = 0;
            for (int i = 0; i < n; ++i)
            {
                sumRight = sumRight - nums[i];
                if (sumRight == sumLeft)
                {
                    return i;
                }

                sumLeft += nums[i];
            }

            return -1;
        }
        /// <summary>
        //!Time complexity=O(n) Space Complexity=O(n) 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int PivotIndex1(int[] nums)
        {
            int n = nums.Length;
            int[] sumRight = new int[n];

            int sum = 0;
            for (int i = n - 1; i >= 0; --i)
            {
                sumRight[i] = sum;
                sum += nums[i];
            }

            sum = 0;
            for (int i = 0; i < n; ++i)
            {
                if (sum == sumRight[i])
                {
                    return i;
                }
                sum += nums[i];
            }

            return -1;
        }
        /// <summary>
        //! Time complexity=O(n) Space Complexity=O(n^2) 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int PivotIndex2(int[] nums)
        {
            int n = nums.Length;

            int[] leftSideSum = new int[n];
            int[] rightSideSum = new int[n];

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += nums[i];
                leftSideSum[i] = sum;
            }

            sum = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                sum += nums[i];
                rightSideSum[i] = sum;
            }

            for (int i = 0; i < n; i++)
            {
                if (leftSideSum[i] == rightSideSum[i])
                {
                    return i;
                }
            }


            return -1;
        }

        /// <summary>
        //! Brute force approach
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int PivotIndex3(int[] nums)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                bool isPivotIndex = IsPivotIndex(nums, i);
                if (isPivotIndex)
                {
                    return i;
                }
            }

            return -1;
        }

        private bool IsPivotIndex(int[] nums, int start)
        {
            int leftSideSum = 0;
            for (int i = 0; i < start; i++)
            {
                leftSideSum += nums[i];
            }

            int rightSideSum = 0;

            for (int i = start + 1; i < nums.Length; i++)
            {
                rightSideSum += nums[i];
            }

            return leftSideSum == rightSideSum;

        }


    }
}
