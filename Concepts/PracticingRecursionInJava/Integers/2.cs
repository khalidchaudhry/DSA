using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    class _2
    {

        // For a given positive integer n write a program to print numbers from 1 to n. 
        // For instance for n equals to 5, the outcome is 1,2,3,4,5
        public void Print1ToN(int n)
        {
            if (n == 1)
            {
                Console.Write($"{n} ");
            }
            else
            {
                Print1ToN(n-1);
                Console.Write($"{n} ");
            }
        }
    }
}
