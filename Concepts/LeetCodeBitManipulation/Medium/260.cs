using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBitManipulation.Medium
{
    public class _260
    {

        /// <summary>
        /// https://www.youtube.com/watch?v=3TSC0nlur58
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SingleNumber(int[] nums)
        {

            int[] result = new int[2];

            int xy = 0;
            //! xy will give xor of two missing numbers(x and y)
            for (int i = 0; i < nums.Length; ++i)
            {
                xy = xy ^ nums[i];
            }

            //! Two missing numbers will have atleast one bit different(1 bit in one number and 0 bit in another number) as they are different numbers 
            //! below line gives the first set bit(least significant bit) from right side e.g. (000100010) will be (000000010) 
            //! or it will give the one bit differ between two numbers 
            int lowbit = xy & (-xy);

            for (int i = 0; i < nums.Length; ++i)
            {
               //! We will check that in given numbers if we have this bit set or  not 
                if ((nums[i] & lowbit) == 0)
                {
                    //!taking xor because duplicates will cancel each other.  
                    result[0] = result[0] ^ nums[i];
                }
                else
                {                    
                    result[1] = result[1] ^ nums[i];
                }
            }

            return result;
        }

    }
}
