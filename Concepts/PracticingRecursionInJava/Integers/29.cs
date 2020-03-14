using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    class _29
    {
        double times;

        public void PrintAExpTimes(int n)
        {
            times = Math.Pow(2, n);
            PrintAExpTimesHelper(times);
        }

        private void PrintAExpTimesHelper(double n)
        {
            if (n == 1)
            {
                Console.Write('A');
            }
            else
            {
                Console.Write('A');
                PrintAExpTimesHelper(n-1);
            }
        }
    }
}
