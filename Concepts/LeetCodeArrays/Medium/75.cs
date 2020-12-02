﻿using System;
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
            int front = 0;
            int iterator = 0;
            int back = nums.Length - 1;

            //! should be <= otherwise it will fail for [2,0,1]
            while (iterator <= back)
            {
                if (nums[iterator] == 0)
                {
                    Swap(nums, iterator, front);
                    ++front;
                    ++iterator;
                }
                else if (nums[iterator] == 2)
                {
                    //! we are not incrementing iterator when array element is 2
                    Swap(nums, iterator, back);
                    --back;
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
        //! https://www.youtube.com/watch?v=ER4ivZosqCg
        /// </summary>
        public void SortColors2(int[] nums)
        {
            if (nums.Length == 0)
                return;
            int n = nums.Length;
            int pivot = 1;
            //!Move all the values less then the pivot to the left side 
            for (int anchor = 0, explorer = 0; explorer < n; ++explorer)
            {
                if (nums[explorer] < pivot)
                {
                    Swap(nums, anchor, explorer);
                    ++anchor;
                }
            }
            //!Move all the values greater then the pivot to the right side 
            for (int anchor = n - 1, explorer = n - 1; explorer >= 0; --explorer)
            {
                if (nums[explorer] > pivot)
                {
                    Swap(nums, anchor, explorer);
                    --anchor;
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