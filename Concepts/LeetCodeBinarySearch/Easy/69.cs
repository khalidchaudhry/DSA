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
        //! Binary search will be performed from 0 till number/2 since Sqrt(number) can't be greater than number/2
        //! At every index , we will check if number*number<=target or number<=target/number
        // n=8;   8/2
        //!1,2,3,4,5,6,7,8
       //! ^     ^--Binary search space     
        /// </summary>
        public int MySqrt0(int x)
        {
            //! Corner case
            if (x == 0)
                return 0;
            //! We are strting from 1 rather than 0 because in case of x=1 it will return 0 rather than returning 1 
            int lo = 1; //! valid candidate 
            int hi = x / 2 + 1; //! invalid candidate 
            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;
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
        //! incase we need to return  doubles 
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
        //! Is number^2 <= to given number?
        //! ans=sqrt(x)
        //! ans^2=x
        //! ans=x/2
        /// </summary>
        private bool OK(int number, int x)
        {
            //!or we can write it like that as well and can avoid  using int.... number<=x/number;
            return number <= x / number;
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
