using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    class _23
    {
        public void Convert(int n)
        {
            if (n == 0)
            {
                Console.Write("0");
            }
            else
            {
                Convert(n/2);
                Console.Write(n % 2);
            }
        }

    }
}
