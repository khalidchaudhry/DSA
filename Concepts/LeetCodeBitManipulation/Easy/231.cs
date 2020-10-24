using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBitManipulation.Easy
{
    public class _231
    {

        public bool IsPowerOfTwo0(int n)
        {
            if (n == 0) return false;
            long nLong = n;
            //! Power of two number will have only one 1-bit set in its binary representation 
            //! n-1 will turn that one bit to zero and all bits following that to 1 
            //! if taking & of n & n-1 results in 0 than its means its power of two
            //! e.g. 8(001000)
            //!      7(000111)
            //6(110)
            //5(011)

            //! n & n-1 will give zero for power of two else 

            if ((nLong & nLong - 1) == 0) return true;
            else return false;
        }

        public bool IsPowerOfTwo1(int n)
        {
            if (n == 0) return false;
            while (n != 1)
            {
                if (n % 2 != 0)
                    return false;
                n = n / 2;
            }
            return true;
        }

    }
}
