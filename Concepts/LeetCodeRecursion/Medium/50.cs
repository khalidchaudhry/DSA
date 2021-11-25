using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeRecursion.Medium
{
    public class _50
    {
        public static void _50Main()
        {
            _50 Test = new _50();

            double x = 0.00001;
            int n = 2147483647;

            var result = Test.MyPow2(x, n);

            Console.ReadLine();
        }
        /// <summary>
        // # <image url="$(SolutionDir)\Images\50.png"  scale="1.0"/>
        /// </summary>
        //http://www.platinumgmat.com/gmat_study_guide/exponential_powers
        //https://www.youtube.com/watch?v=GyL7FJn0gso
        //! Take away1: Look for stack overflow exception when input is large and you need to go to very base case which is very small
        //! Think about recurence relationship when n is even vs when not
        //! Space Complexity=O(logn)  ---> We are halfing the input each time
        //! Time Complexity=O(logn)
        /// </summary>
        public double MyPow(double x, int n)
        {           
            if (n < 0)
            {
                x = 1 / x;
                n = -n;
            }
            //! recurrence relationship    
            //! F(x,n)=F(x*x,n/2) for even n      e.g. 2^10= 2^(5+5) =(2*2)^5 
            //! F(x,n)=x*F(x*x,n/2) for odd n     e.g. 2^11=2^(1+10)= 2*(2*2)^5 
            return Helper(x, n);
        }
        private double Helper(double x, int n)
        {
            if (n == 0)
                return 1;
            if (n == 1)  //! power of 1 of any number is equal to that number 
                return x;

            if (n % 2 == 0)//! if number is even 
                return Helper(x * x, n / 2);

            else //!if number is odd  e.g. 2^5 can be represented as 2^4 * 2^1
                return x * Helper(x * x, n / 2);
        }
        //! Will throw out of stack exception 
        public double MyPow2(double x, int n)
        {
            if (n < 0)
            {
                x = 1 / x;
                n = -n;
            }
            return Helper2(x, n);
        }

       
        private double Helper2(double x, int n)
        {
            if (n == 0)
                return 1;
            if (n == 1)
                return x;
            //! Recurence relationship is F(x,n)=x*F(x,n-1)
            double result = x * Helper2(x, n - 1);
            return result;
        }


       

    }
}
