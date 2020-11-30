using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Easy
{
    class _69
    {

        public static void _69Main()
        {

            _69 SquareRoot = new _69();

            SquareRoot.MySqrt0(2147395599);

        }

        /// <summary>
        //! Based on the template  from Roger 
        /// </summary>
        public int MySqrt0(int x)
        {
            if (x == 0)
                return 0;

            long lo = 1; //! valid candidate 
            long hi = x / 2 + 1; //! invalid candidate 
            while (lo + 1 < hi)
            {
                long mid = lo + (hi - lo) / 2;
                if (OK(mid, x))
                {
                    lo = mid;
                }
                else
                {
                    hi = mid;
                }
            }

            return (int)lo;
        }
        //! incase we need to run it on doubles 
        public double Sqrt2(int x)
        {
            if (x == 0)
                return 0;
            double lo = 1;
            double hi = x / 2 + 1;
            for (int i = 0; i < 80; i++)
            {
                double mid = lo + (hi - lo) / 2;
                if (OK(mid,x))
                {
                    lo = mid;
                }
                else
                {
                    hi = mid;
                }
            }
            return lo;
        }

        /// <summary>
        //!TTT'T'FFFFF 
        /// </summary>
        private bool OK(long number, int x)
        {
            return number * number <= x;
        }

        /// <summary>
        //!TTT'T'FFFFF 
        /// </summary>
        private bool OK(double number, int x)
        {
            return number * number <= x;
        }

        /// <summary>
        /// https://leetcode.com/problems/sqrtx/
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt1(int x)
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

    }
}
