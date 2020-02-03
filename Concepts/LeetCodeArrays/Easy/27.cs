using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    class _27
    {
        public int RemoveElement(int[] nums, int val)
        {

            if (nums.Length == 0)
            {
                return 0;
            }

            int explorer = 0;
            int anchor = nums.Length - 1;

            while (explorer < anchor)
            {
                if (nums[explorer] == val)
                {
                    Swap(nums, explorer, anchor);
                    --anchor;
                }
                else
                {
                    ++explorer;
                }
            }
            int length = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                    break;

                ++length;
            }

            return length;
        }
        private void Swap(int[] nums, int explorer, int anchor)
        {
            int temp = nums[explorer];
            nums[explorer] =nums[anchor];
            nums[anchor] = temp;            
        }
    }
}
