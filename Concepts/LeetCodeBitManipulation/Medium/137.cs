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
        //https://www.youtube.com/watch?v=cOFAmaMBVps
        //! We save only elements having occurance of 1 and 2 
        //! once we have 3rd accurance then we reset both 1 and two
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            int ones = 0;
            int twos = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                //! Take xor of ones with current array element and then & with complement of two's 
                ones = (ones ^nums[i]) & (~twos);
                //! Take xor of two  with current array element and then & with complement of one's
                twos = (twos ^ nums[i]) & (~ones);
            }

            return ones;
        }


    }
}
