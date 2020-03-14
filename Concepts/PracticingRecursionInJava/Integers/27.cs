using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    class _27
    {
        public void PrintALognTimes(int n)
        {
            if (n <= 1)
                return;
            else
            {
                Console.Write("A ");
                PrintALognTimes(n / 2);
            }

        }

    }
}
