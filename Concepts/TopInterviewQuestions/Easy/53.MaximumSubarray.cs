using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _53
    {
        public int MaxSubArray(int[] nums)
        {
            int max = nums[0], maxSoFar = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                maxSoFar = Math.Max(nums[i], nums[i] + maxSoFar);

                if (max<maxSoFar)
                {
                    max = maxSoFar;
                }
            }

            return max;

        }

    }
}
