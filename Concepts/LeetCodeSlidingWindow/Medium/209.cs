using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Medium
{
    public class _209
    {
        /// <summary>
        //! Sliding window pattern where we keep expanding window till we are >=target
        //! THen we start shrinking the window
        /// </summary>
        public int MinSubArrayLen(int s, int[] nums)
        {
            int i = 0;
            int sum = 0;
            int min = int.MaxValue;

            for (int j = 0; j < nums.Length; ++j)
            {
                sum += nums[j];
                //! Once window invalid keep shrinking till it becomes valid
                while (sum >= s)
                {
                    //! Question is asking us to provide sum ≥ s
                    min = Math.Min(j - i + 1, min);
                    sum -= nums[i];
                    ++i;
                }
            }
            return min == int.MaxValue ? 0 : min;
        }

    }
}
