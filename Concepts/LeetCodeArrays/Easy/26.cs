using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _26
    {
        /// <summary>
        //! Slow fast pointer approach 
        //! Slow pointer will point to end of non-duplicate array 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>

        public int RemoveDuplicates0(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int i = 0;//slow pointer

            for (int j = 1; j < nums.Length; ++j)
            {
                if (nums[i] != nums[j])
                {
                    ++i;
                    nums[i] = nums[j];
                }
            }
            //!i+1 because question ask for array length  
            return i+1;

        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int j = 0;

            for (int i = 0; i < nums.Length-1; i++)
            {
                if (nums[i] != nums[i + 1])
                {
                    nums[j] = nums[i];
                    ++j;
                }
            }

            nums[j++]=nums[nums.Length-1];

            return j;
        }

    }
}
