using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _53
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int curr_max = nums[0], global_max = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                curr_max = Math.Max(nums[i], nums[i] + curr_max);

                global_max = Math.Max(curr_max, global_max);
            }

            return global_max;
        }

    }
}
