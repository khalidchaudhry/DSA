using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _915
    {
        public int PartitionDisjoint(int[] nums)
        {
            int n = nums.Length;
            int[] minSuffix = new int[n];
            for (int i = n - 1; i >= 0; --i)
            {
                minSuffix[i] = i == n - 1 ? nums[i] : Math.Min(nums[i], minSuffix[i + 1]);
            }
            int maxPrefix = nums[0];
            for (int i = 0; i < n - 1; ++i)
            {
                maxPrefix = Math.Max(maxPrefix, nums[i]);
                if (maxPrefix <= minSuffix[i + 1])
                {
                    return i + 1;
                }
            }
            return 0;
        }


    }
}
