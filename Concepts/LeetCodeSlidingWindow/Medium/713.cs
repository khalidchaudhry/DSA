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

            int count = 0;
            int product = 1;
            int i = 0;
            for (int j = 0; j < nums.Length; ++j)
            {
                product = product * nums[j];
                //Once window invalid shrink it to make valid
                while (product >= k)
                {
                    product = product / nums[i];
                    ++i;
                }

                count += j - i + 1;
            }

            return count;
        }



    }
}
