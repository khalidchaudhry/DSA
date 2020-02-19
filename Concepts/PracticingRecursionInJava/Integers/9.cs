using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    class _9
    {
        public int GCD(int m, int n)
        {
            if (m % n == 0)
            {
                return n;
            }
            else
            {
                return GCD(m, m % n);
            }

        }
    }
}
