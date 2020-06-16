using System;
using System.Collections.Generic;
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

            int totalSum = 0;
            for (int i = 0; i < n; i++)
            {
                totalSum += nums[i];

            }
            int leftSideSum = 0;
            int rightSideSum = totalSum;

            for (int i = 0; i < n; i++)
            {
                //leftSideSum += i == 0 ? 0 : nums[i - 1];
                rightSideSum -= nums[i];
                if (leftSideSum == rightSideSum)
                {
                    return i;
                }

                //! Setting leftSideSum for the next iteration. 
                //! It will avoid the line commented above leftSideSum += i == 0 ? 0 : nums[i - 1];
                leftSideSum += nums[i];
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

            int[] prefix = new int[n];
            int totalSum = 0;
            for (int i = 0; i < n; i++)
            {
                totalSum += nums[i];
                prefix[i] = totalSum;
            }

            for (int i = 0; i < n; i++)
            {
                int leftSideSum = i == 0 ? 0 : prefix[i - 1];
                int rightSideSum = totalSum - prefix[i];
                if (leftSideSum == rightSideSum)
                {
                    return i;
                }
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
