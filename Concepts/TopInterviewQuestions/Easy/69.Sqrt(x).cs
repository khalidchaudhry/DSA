using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _69
    {

        public static void _69Main()
        {

            _69 SquareRoot = new _69();

            SquareRoot.MySqrt0(2147395599);

        }
        
        /// <summary>
        /// https://leetcode.com/problems/sqrtx/
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt0(int x)
        {
            if (x < 2) return x;

            int l = 2;
            int r = x / 2;

            while (l <= r)
            {
                int mid = l + ((r - l) / 2);
                //! declare it as long as multiple of two numbers can result in overflow
                //! First it will convert first mid in equation below to long and than multiply with mid
                //!(long) is a unary operator hence have more precedence then  multiplication operator
                //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/#operator-precedence
                long num = (long)mid * mid;

                if (num > x)
                {
                    r = mid - 1;
                }
                else if (num < x)
                {
                    l = mid + 1;
                }
                //! This is in case of number is a perfect square like 9
                else
                {
                    return mid;
                }
            }
            //!as the decimal digits are truncated and only the integer part of the result is returned.
            //! hence we are are returning r
            return r;
        }




        public int MySqrt(int x)
        {
            long start = 0;

            long end = x;

            while (start < end)
            {
                long mid = (start + end) / 2;

                if (mid * mid == x)
                    return (int)mid;
                else if ((mid * mid) < x)
                {
                    start = mid;
                }
                else
                {
                    end = mid;
                }
            }

            if (end * end == x)
            {
                return (int)end;
            }
            return (int)start;


        }

    }
}
