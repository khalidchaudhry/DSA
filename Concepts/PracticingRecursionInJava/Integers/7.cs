using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    class _7
    {
        public int NumberOfDigits(long n)
        {
            if (n == 0)
                return 0;

            return 1+NumberOfDigits(n/10);


        }
    }
}
