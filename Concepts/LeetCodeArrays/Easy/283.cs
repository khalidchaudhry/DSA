﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _283
    {
        public void MoveZeroes(int[] nums)
        {
            for (int anchor = 0, explorer = 0; explorer < nums.Length;)
            {
                if (nums[explorer] != 0)
                {
                    Swap(nums, anchor, explorer);
                    ++anchor;
                }
                ++explorer;
            }
        }
        public void Swap(int[] nums, int anchor, int explorer)
        {
            int temp = nums[anchor];
            nums[anchor] = nums[explorer];
            nums[explorer] = temp;
        }
    }
}