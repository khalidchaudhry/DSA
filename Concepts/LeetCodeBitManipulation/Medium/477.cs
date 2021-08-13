using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBitManipulation.Medium
{
    public class _477
    {
        /// <summary>
        //! Essentially we are dealing with bit by bit 
        //! Extract ith bit for all the numbers 
        //! Count number of zeros and ones for ith bit of all the numbers
        //! Multiply zeros * ones to get the sum
        /// </summary>
        public int TotalHammingDistance(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i <= 31; ++i)
            {
                int zerosCount = 0;
                int onesCount = 0;
                foreach (int num in nums)
                {
                    int ithBit = (num >> i) & 1;
                    if (ithBit == 0)
                    {
                        ++zerosCount;
                    }
                    else
                    {
                        ++onesCount;
                    }
                }
                //! zerosCount * onesCount gives us number of bits different for ith bit which we calculated above
                sum += zerosCount * onesCount;
            }
            return sum;
        }

    }
}
