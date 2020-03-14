using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    class _26
    {
        //Precondition : n>=0
        public int NumberOfDigits(int n)
        {
            if (n == 1 || n == 0)
                return 1;
            else
            {
                return 1 + NumberOfDigits(n / 2);
            }
        }

    }
}
