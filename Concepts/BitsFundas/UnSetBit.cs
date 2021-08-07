using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsFundas
{
    public static class UnSetBit
    {
        public static int UnSetithBit(int n, int pos)
        {
            //! Mask generation is a 2 step process for unsetting bit
            //! Step1: left shift by pos
            int mask = 1 << pos;
            //! Negate the mask
            mask = ~mask;
            return n & mask;
        }


    }
}
