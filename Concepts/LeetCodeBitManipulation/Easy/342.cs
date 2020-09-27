using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBitManipulation.Easy
{
    public class _342
    {
        /// <summary>
        /// https://www.youtube.com/watch?v=KwtRRZN6loU
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsPowerOfFour1(int num)
        {
            //! (num & (num - 1)) make sure that we have only one 1-bit set 
            //! (num & 0xaaaaaaaa)==0 makes sure that bit is not set at odd index
            //! 010101010(0xaaaaaaaa) =represents the bits set for powers of 2 at odd indexes
            //! num & 0xaaaaaaaa==0 because 1 bits sets at even indexes for power of 4 number. 
            
            return num != 0 &&
                   ((num & (num - 1)) == 0) && //! for number tobe power of 4, it should also be power of 2
                   (num & 0xaaaaaaaa)==0; 
        }

        /// <summary>
        /// https://www.youtube.com/watch?v=KwtRRZN6loU
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsPowerOfFour2(int num)
        {
            //! Power of two number will have only one 1-bit set in its binary representation 
            //! n-1 will turn that one bit to zero and all bits following that to 1 
            //! if taking & of n & n-1 results in 0 than its means its power of two
            //! e.g. 8(001000)
            //!      7(000111)
            //! n & n-1 will give zero for power of two else 
            return num != 0 &&
                   ((num & (num - 1)) == 0) && //! for number tobe power of 4, it should also be power of 2
                   num % 3 == 1;  //! all power of 4 numbers have remainder 1 when divided by 3. 
        }

        /// <summary>
        //! logn solution
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsPowerOfFour3(int num)
        {
            if (num == 0) return false;

            while (num != 1)
            {
                if (num % 4 != 0) return false;
                num = num / 4;
            }

            return true;
        }
    }
}
