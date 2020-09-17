using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Easy
{
    public class _263
    {
        /// <summary>
        //! Brute force
        //https://www.youtube.com/watch?v=IoqqgfZfiRA
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsUgly1(int num)
        {
            int[] factors = new int[] { 2, 3, 5 };

            for (int i = 0; i < factors.Length; ++i)
            {
                while (num % factors[i] == 0)
                {
                    num = num / factors[i];
                }
            }

            if (num == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        //! does not work for -2147483648
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsUgly2(int num)
        {
            int divisor = num - 1;

            while (divisor > 3)
            {
                if (divisor % 2 == 0 || divisor % 3 == 0 || divisor % 5 == 0)
                {
                    --divisor;
                    continue;
                }
                int remainder = num % divisor;

                if (remainder == 0)
                    return false;

                --divisor;
            }

            return true;
        }


    }
}
