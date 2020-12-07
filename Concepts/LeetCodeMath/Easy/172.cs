using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Easy
{
    public class _172
    {
        public static void _172Main()
        {
            var ans = new _172();
            long test = ans.TrailingZeroes2(30);
            Console.ReadLine();
        }
        /// <summary>
        //!Take aways 
        //!Take away 1:% operator does not work correctly with double/decimal.
        //!Take way 2: C# has BigInteger that but requires referencing nuget        
        /// https://www.youtube.com/watch?v=3Hdmv_Ym8PI
        /// https://www.youtube.com/watch?v=wkvVdggCSeo
        //! Basic intution: Occurance of trailing zeros= Occurances of 5's in number factorial 8! (1*2*3*4*5*6*7*8)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int TrailingZeroes(int n)
        {
            int trailingZerosCount = 0;
            while (n >= 5)
            {
                trailingZerosCount += n / 5;
                n = n / 5;
            }

            return trailingZerosCount;
        }

        public int TrailingZeroes2(int n)
        {

            if (n == 0) return 0;
            int zerosCount = 0;
            BigInteger factorial = Factorial(n);

            var result = factorial % 10;
            while (factorial % 10 == 0)
            {
                ++zerosCount;
                factorial = factorial / 10;
            }
            return zerosCount;
        }
        private BigInteger Factorial(int n)
        {
            if (n == 0) return 0;
            BigInteger factorial = 1;
            while (n != 1)
            {
                try
                {
                    factorial = (factorial * n);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("oh noes!");

                }
                --n;
            }
            return factorial;
        }


    }
}
