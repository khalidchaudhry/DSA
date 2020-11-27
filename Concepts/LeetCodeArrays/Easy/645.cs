using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    public class _645
    {
        /// <summary>
        //! Using element marking technique. Another approach  is using XOR. See leetcode for discussion 
        /// </summary>
        public int[] FindErrorNums(int[] nums)
        {
            int[] ans = new int[2];
            for (int i = 0; i < nums.Length; ++i)
            {
                int index = Math.Abs(nums[i]) - 1;
                if (nums[index] < 0)
                {
                    ans[0] = Math.Abs(nums[i]);
                }
                else
                {
                    nums[index] = -nums[index];
                }
            }

            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] > 0)
                {
                    ans[1] = i + 1;
                    break;
                }
            }

            return ans;

        }
    }
}
