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
            return Rob(nums, 0, false);
        }
        private int Rob(int[] nums, int s, bool isFirstHouseRob)
        {
            if (s >= nums.Length || (s == nums.Length - 1 && isFirstHouseRob))
                return 0;

            int skip = Rob(nums, s + 1, isFirstHouseRob);

            int rob = nums[s] + Rob(nums, s + 2, isFirstHouseRob || s == 0);


            return Math.Max(skip, rob);
        }

    }
}
