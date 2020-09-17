using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Medium
{
    public class _55
    {
        /// <summary>
        /// Kuai class 09/04/2020
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanJump(int[] nums)
        {
            int n = nums.Length;
            int dest = nums[n - 1];

            for (int i = n - 2; i >= 0; --i)
            {
                if (i + nums[i] >= dest)
                {
                    dest = i;
                }

            }

            return dest == 0 ? true : false;

        }

    }
}
