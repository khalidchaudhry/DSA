using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    class _5
    {
        public int NumberOfDigits(int n)
        {
            if (n >= 0 && n <= 9)
            {
                return 1;
            }
            return NumberOfDigits(n/10)+1;
        }
    }
}
