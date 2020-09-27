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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
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


    }
}
