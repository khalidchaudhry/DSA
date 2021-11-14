using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBitManipulation.Easy
{
    public class _693
    {
        public bool HasAlternatingBits(int n)
        {

            if (n == 0)
            {
                return false;
            }

            int prev = n & 1;
            while (n != 0)
            {
                n = n >> 1;
                int currBit = n & 1;
                if (currBit == prev)
                {
                    return false;
                }
                prev = currBit;
            }
            return true;
        }
    }
}
