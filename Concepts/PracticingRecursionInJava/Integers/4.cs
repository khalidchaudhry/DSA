using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    class _4
    {

        public double Power1(double a, int n)
        {
            if (n == 0)
                return 1;

            return Power1(a, n - 1) * a;

        }
    }
}
