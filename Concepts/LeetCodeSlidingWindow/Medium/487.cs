using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSlidingWindow.Medium
{
    public class _487
    {
        /// <summary>
        //! Same as question 1004 
        /// </summary>
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int k = 1;
            int maxConsectiveOnes = 0;
            int zeros = 0;
            int i = 0;
            for (int j = 0; j < nums.Length; ++j)
            {
                if (nums[j] == 0)
                    ++zeros;
                //! Once window invalid shrink it to make valid
                while (zeros > k)
                {
                    if (nums[i] == 0)
                        --zeros;
                    ++i;
                }
                maxConsectiveOnes = Math.Max(maxConsectiveOnes, j - i + 1);
            }

            return maxConsectiveOnes;
        }



    }
}
