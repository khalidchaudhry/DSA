using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Medium
{
    public class _625
    {
        public static void _625Main()
        {
            _625 SmalleshFactorization = new _625();
            var ans = SmalleshFactorization.SmallestFactorization(11);
            Console.ReadLine();


        }
        /// <summary>
        //! Basic intuition for this problem is divide given number by 9 till 2        
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int SmallestFactorization(int a)
        {
            if (a <= 9)
                return a;

            int divisor = 9;
            int power10 = 0;
            double ans = 0;
            while (divisor != 1)
            {
                while (a % divisor == 0) //keep dividing till it not completely divisble by divisor 
                {
                    a = a / divisor;

                    ans += divisor * Math.Pow(10, power10++);
                }

                --divisor;

            }

            //! a should be completely factorised.
            //! n should be broken in form of digits

            return a == 1 && ans <= int.MaxValue ? (int)ans : 0;
        }
    }
}
