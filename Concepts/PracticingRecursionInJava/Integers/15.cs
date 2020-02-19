using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    //Given a positive integer value n, write a method to compute the sum of 
    // reciprocal values of factorials 1/1! + 1/2! + 1/3!...........+1/n!
    class _15
    {
        public double InvFacSum(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return 1 / Factorial(n) + InvFacSum(n - 1);

        }

        private double Factorial(int n)
        {
            if (n == 1)
                return 1;
            return n*Factorial(n-1);
        }

    }
}
