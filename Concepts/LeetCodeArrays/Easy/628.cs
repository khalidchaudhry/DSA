using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _628
    {
        public int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);

            int maxProduct = nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3];


            // Take second and third numbers  from array start
            maxProduct = Math.Max(maxProduct, nums[nums.Length - 1] * nums[0] * nums[1]);

            // Take third number from array start
            maxProduct = Math.Max(maxProduct, nums[nums.Length - 2] * nums[nums.Length - 1] * nums[0]);

            return maxProduct;
        }


    }
}
