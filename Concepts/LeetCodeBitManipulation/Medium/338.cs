using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBitManipulation.Medium
{
    public class _338
    {

        public static void _338Main()
        {

            int num = 2;
            _338 CountingBits = new _338();
            var ans = CountingBits.CountBits1(num);
            Console.ReadLine();

        }

        /// <summary>
        /// https://www.youtube.com/watch?v=iuqr5hHk2MI
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int[] CountBits1(int num)
        {
            int[] result = new int[num + 1];

            for (int i = 1; i < result.Length; ++i)
            {
                //! Number of 1-bits in number equals to number of 1-bits  in number/2 with one exception. 
                //! If number is odd then will add one to it
                result[i] = (result[i / 2] + (i % 2));
            }

            return result;

        }
        public int[] CountBits2(int num)
        {
            int[] result = new int[num + 1];

            for (int i = 1; i <= num; ++i)
            {
                int ones = CountOnes(i);
                result[i] = ones;
            }

            return result;
        }

        private int CountOnes(int n)
        {
            int count = 0;
            while (n != 0)
            {
                ++count;
                //! n & n-1 will turn  off  right most set bit . 
                //! keep doing it till zero will tell us how many times we did it and hence the result 
                n = n & (n - 1);
            }
            return count;
        }
    }
}
