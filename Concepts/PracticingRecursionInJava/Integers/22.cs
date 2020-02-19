using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    class _22
    {
        public int Binomial(int n, int k)
        {
            if (k == 0 || n == k)
            {
                return 1;
            }

            return Binomial(n-1,k-1)+ Binomial(n-1,k);

        }

    }
}
