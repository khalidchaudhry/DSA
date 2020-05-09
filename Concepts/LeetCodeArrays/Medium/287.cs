using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _287
    {
        public int FindDuplicate(int[] nums)
        {
            int duplicate = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[Math.Abs(nums[i])] < 0) //negative number 
                {
                    duplicate = nums[i];
                    break;
                }
                else
                {
                    nums[Math.Abs(nums[i])]=-nums[Math.Abs(nums[i])];
                }
            }

            return duplicate;

        }

    }
}
