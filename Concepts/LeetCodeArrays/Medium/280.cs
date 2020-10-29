using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _280
    {
        /// <summary>
        //! Covered in Kuai's class 
        /// </summary>
        /// <param name="nums"></param>
        public void WiggleSort(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; ++i)
            {
                bool isEvenIndex = i % 2 == 0;

                //! if even index and current value is greater than the next element then swap
                if (isEvenIndex && nums[i] > nums[i + 1])
                {
                    Swap(nums, i, i + 1);
                }
                //! if odd index and current value is less then next value then swap. 
                else if (!isEvenIndex && nums[i] < nums[i + 1])
                {
                    Swap(nums, i, i + 1);
                }
            }
        }
        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

    }
}
