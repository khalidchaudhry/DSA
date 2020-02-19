using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    class _6
    {

        public bool NContainsK(int n, int k)
        {
            if (n % 10 == k)
            {
                return true;
            }
            else if (n == 0)
            {
                return false;
            }
            else
            {
                return NContainsK(n / 10, k);
            }
        }
    }
}
