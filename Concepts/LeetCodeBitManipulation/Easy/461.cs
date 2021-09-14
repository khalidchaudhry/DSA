using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBitManipulation.Easy
{
    public class _461
    {


        public static void _461Main()
        {
            _461 Ham = new _461();

            var ans = Ham.HammingDistance(1, 4);

            Console.ReadLine();
        }
        /// <summary>
        //! First take xor then count number of 1's in it 
        /// </summary>
      
        public int HammingDistance(int x, int y)
        {
            int xor = x ^ y;
            int count = 0;

            while (xor != 0)
            {
                ++count;
                //! Unset(turn-off or 0) the right most set bit
                xor = xor & (xor - 1);
            }

            return count;
        }

        public int HammingDistance1(int x, int y)
        {

            int count = 0;
            for (int i = 0; i <= 31; ++i)
            {
                int xBit = (x >> i) & 1;
                int yBit = (y >> i) & 1;

                if ((xBit ^ yBit) == 1)
                {
                    ++count;
                }
            }
            return count;
        }


    }
}
