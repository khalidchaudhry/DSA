using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBitManipulation.Easy
{
    class _191
    {

        public int HammingWeight0(uint n)
        {

            int count = 0;
            while (n != 0)
            {
                ++count;
                //! below line turns off the last set bit to 0 
                n = (n & (n - 1));
            }

            return count;
        }


        public int HammingWeight(uint n)

        {
            //Stack<uint> stk =new Stack<uint>();
            int count=0;
            while (n != 0)
            {
                uint remainder=n % 2;
                if (remainder == 1)
                    ++count;

                n = n / 2;
            }
            return count;
        }

    }
}
