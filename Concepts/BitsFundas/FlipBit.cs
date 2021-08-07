using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsFundas
{
    public static class FlipBit
    {

        public static int FlipBitAtithPosition(int number, int pos)
        {
            int mask = 1 << pos;
            return number ^ mask;
        }

        public static int FlipAllBits(int number)
        {
            int result = 0;
            for (int i = 0; i <= 31; ++i)
            {
                int mask = 1 << i;
                int newNumber = (number & mask);
                result += FlipBitAtithPosition(newNumber, i);
            }

            return result;

        }

    }
}
