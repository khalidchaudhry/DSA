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
            int count = 0;
            for (int i = 0; i <= 31; ++i)
            {
                if (((n >> i) & 1) == 1)
                {
                    ++count;
                }
            }
            return count;
        }

    }
}
