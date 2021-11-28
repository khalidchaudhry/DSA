using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBitManipulation.Medium
{
    public class _137
    {

        /// <summary>
        /// https://www.youtube.com/watch?v=cOFAmaMBVps
        //! Counting set bit approach  
        //! Time=O(32*n)
        //! Space=O(1)
        /// </summary>
        public int SingleNumber0(int[] nums)
        {
            int result = 0;
            for (int bitPos = 0; bitPos <= 31; ++bitPos)
            {
                int setBitCount = 0;
                foreach (int num in nums)
                {
                    int ithBit = (num >> bitPos) & 1;
                    if (ithBit == 1)
                    {
                        ++setBitCount;
                    }
                }
                //! setBitCount value will be either 1 or 0 after below operation
                setBitCount = setBitCount % 3;
                //! either  setBitCount will be 0 or 1. If 1 it means that bit is set in the number or 0 if bit is not set 
                // set the ith bit of the number. Value of  setBitCount will be 0 or 1 
                //and we are taking OR(|) so even in case of 0 it will impact the result
                result = result | (setBitCount << bitPos);


            }

            return result;
        }





        /// <summary>
        //https://www.youtube.com/watch?v=cOFAmaMBVps
        //! We save only elements having occurance of 1 and 2 
        //! once we have 3rd accurance then we reset both 1 and two
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            int occurOnce = 0;
            int occurTwice = 0;
            foreach (int num in nums)
            {
                //! Take xor of ones with current array element and then & with complement of two's 
                occurOnce = (occurOnce ^ num) & (~occurTwice);
                //! Take xor of two  with current array element and then & with complement of one's
                occurTwice = (occurTwice ^ num) & (~occurOnce);
            }

            return occurOnce;
        }


    }
}
