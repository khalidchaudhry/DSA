using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    class _1
    {
        // Given a positive integer value n , write a method to print Hello n times

        public void PrintHelloNTimes(int n)
        {
            if (n == 0)
                return;
            PrintHelloNTimes(n - 1);
            Console.WriteLine("Hello");
        }

    }
}
