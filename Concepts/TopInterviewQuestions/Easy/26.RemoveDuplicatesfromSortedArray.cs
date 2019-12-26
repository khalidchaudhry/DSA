using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _26
    {
        /*
        Given a sorted array nums, remove the duplicates in-place such that each element appear only once and return the new length.
        Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
        */
        public int RemoveDuplicates(int[] nums)
        {
            int j = 0;
            if (nums.Length == 0)
                return 0;
            for (int i = 0; i < nums.Length-1;i++)
            {
                if (nums[i] != nums[i + 1])
                {
                    nums[j] = nums[i];
                    ++j;
                }
            }

            nums[j++] =nums[nums.Length-1];


            return j;


        }

    }
}
