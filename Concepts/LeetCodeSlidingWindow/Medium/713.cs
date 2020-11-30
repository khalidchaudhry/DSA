using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Medium
{
    public class _713
    {
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {

            int runningProduct = 1;
            int total = 0;

            int i = 0;
            for (int j = 0; j < nums.Length; ++j)
            {
                runningProduct = runningProduct * nums[j];
                while (i < nums.Length && runningProduct >= k)
                {
                    runningProduct = runningProduct / nums[i];
                    ++i;
                }

                total += j - i + 1;
            }

            return total < 0 ? 0 : total;
        }



    }
}
