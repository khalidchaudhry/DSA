using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRecursion.Medium
{
    public class _50
    {


        //https://www.youtube.com/watch?v=GyL7FJn0gso
        public double MyPow(double x, int n)
        {
            //! Using long is becuase n is in range -2^31 <= n <= 2^31-1
            //! if n is int.MinValue then taking negative will still keep it as min

            long pow = n;
            if (n < 0)
            {
                x = 1 / x;
                pow = -pow;
            }
            //! recurrence relationship    
            //! For even: x^n=x^(n/2) * x^(n/2)= (x*x)^n/2     e.g. 2^10=(2^10/2) * (2^10/2)= 2^5 * 2^5=(2*2)^5 
            //! For odd: x^n=x*x^(n/2) * x^(n/2)= x*(x*x)^n/2     e.g. 2^11=2 * (2^10/2) * (2^10/2)= 2(2^5 * 2^5)= 2 * (2*2)^5 
            return Helper(x, pow);
        }      

        private double Helper(double x, long n)
        {
            if (n == 0)
                return 1;
            if (n == 1)  //! power of 1 of any number is equal to that number 
                return x;

            if (n % 2 == 0)//! if number is even 
                return Helper(x * x, n / 2);
            //! why halfing by 2 becuase 

            else //!if number is odd  e.g. 2^5 can be represented as 2^4 * 2^1
                return x * Helper(x * x, n / 2);
        }

    }
}
