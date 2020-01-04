using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _581
    {
        public int FindUnsortedSubarray(int[] nums)
        {

            int[] sortedArray = new int[nums.Length];
            nums.CopyTo(sortedArray,0);
            Array.Sort(sortedArray);

            int i = 0, j = nums.Length - 1;
            while (i < nums.Length && sortedArray[i] == nums[i])
            {
                ++i;
            }
            while (i < j && nums[j] == sortedArray[j])
            {
                --j;
            }

            return j - i + 1;
        }

    }
}
