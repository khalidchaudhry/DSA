using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _198
    {
        public int Rob(int[] nums)
        {

            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            int even = 0, odd = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    even += nums[i];
                    even = Math.Max(even, odd);
                }
                else
                {
                    odd += nums[i];
                    odd = Math.Max(odd, even);
                }
            }

            return Math.Max(even,odd);
        }

    }
}
