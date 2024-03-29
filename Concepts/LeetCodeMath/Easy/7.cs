﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Easy
{
    public class _7
    {
        public static void _7Main()
        {
            int x = -321;

            _7 Reverse = new _7();
            var ans = Reverse.Reverse1(x);
            Console.ReadLine();
        }
        /// <summary>
        //! Take aways 
        //! Take away 1: Read problem statement carefully . We are not allowed to use 64 bit integer
        //! Take away 2: result = (result * 10) + remainder is very important to understand
        /// </summary>


        public int Reverse1(int x)
        {
            int reversedNumber = 0;
            while (x != 0)
            {
                int lastDigit = x % 10;
                int newResult = reversedNumber * 10 + lastDigit;
                if ((newResult - lastDigit) / 10 != reversedNumber)
                {
                    return 0;
                }
                reversedNumber = newResult;
                x = x / 10;
            }
            return reversedNumber;
        }
        /// <summary>
        //! Wrong solution below. We are not allowed to use long
        /// </summary>

        public int Reverse(int x)
        {
            bool isNegative = x < 0 ? true : false;
            long number = x;
            //! Math.Abs will not work if input is Int.MinValue hence we need to convert it into long first before taking Abs
            number = Math.Abs(number);

            int numberOfTens = (int)Math.Floor(Math.Log10(number) + 1) - 1;
            //! ans needs tobe in double as it will cause overflow even for longS        
            double ans = 0;
            while (number != 0)
            {
                long remainder = number % 10;
                ans += remainder * Math.Pow(10, numberOfTens--);
                number = number / 10;
            }

            return ans > int.MaxValue ? 0 : isNegative ? -(int)ans : (int)ans;
        }

    }
}
