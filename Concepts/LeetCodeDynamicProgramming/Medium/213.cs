using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDynamicProgramming.Medium
{
    public class _213
    {
        public int Rob(int[] nums)
        {

            if (nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return nums[0];
            if (nums.Length == 2)
            {
                return Math.Max(nums[0], nums[1]);
            }

            return Math.Max(Helper(nums, 0, nums.Length-1),Helper(nums,1,nums.Length));
        }

        private int Helper(int[] nums, int startIndex, int endIndex)
        {
            int length = endIndex - startIndex;
            int[] dp = new int[length + 1];
            dp[0] = 0;
            dp[1] = nums[startIndex];

            for (int i = 2; i < dp.Length; i++)
            {
                dp[i] = Math.Max(nums[startIndex+i - 1] + dp[i - 2], dp[i - 1]);
            }
            return dp[dp.Length-1];
        }
    }
}
