using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _75
    {
        public void SortColors(int[] nums)
        {
            if (nums.Length == 0)
                return;
            //! left  pointer points to first non-zero 
            int left = 0;
            int iterator = 0;
            int right = nums.Length - 1;

            //! should be <= otherwise it will fail for [2,0,1]
            while (iterator <= right)
            {
                if (nums[iterator] == 0)
                {
                    Swap(nums, iterator, left);
                    ++left;
                    //! element at left is at its correct position hence incremeting
                    ++iterator;
                }
                else if (nums[iterator] == 2)
                {
                   //! Not incrementing iterator because we may swapped with 0
                    //!incrementing iterator here  will fail for this test case [1 2 0]
                    Swap(nums, iterator, right);
                    --right;
                }
                //! only increament iterator if 1 is encounter. 
                else
                {
                    ++iterator;
                }
            }
        }

        /// <summary>
        //! Two pass solution
        //! Quick Sort
        //! https://www.youtube.com/watch?v=ER4ivZosqCg
        //! Very similar approach followed in https://leetcode.com/problems/move-zeroes/
        /// </summary>
        public void SortColors2(int[] nums)
        {
            if (nums.Length == 0)
                return;
            int n = nums.Length;
            int pivot = 1;
            //!Move all the values less then the pivot to the left side 
            for (int placementIndex = 0, explorer = 0; explorer < n; ++explorer)
            {
                if (nums[explorer] < pivot)
                {
                    Swap(nums, placementIndex, explorer);
                    ++placementIndex;
                }
            }
            //!Move all the values greater then the pivot to the right side 
            for (int placementIndex = n - 1, explorer = n - 1; explorer >= 0; --explorer)
            {
                if (nums[explorer] > pivot)
                {
                    Swap(nums, placementIndex, explorer);
                    --placementIndex;
                }
            }
        }


        private void Swap(int[] nums, int first, int second)
        {
            int temp = nums[first];
            nums[first] = nums[second];
            nums[second] = temp;
        }

    }
}
