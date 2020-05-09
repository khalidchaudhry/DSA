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

        private void Swap(int[] nums, int first, int second)
        {
            int temp = nums[first];
            nums[first] = nums[second];
            nums[second] = temp;
        }

    }
}
