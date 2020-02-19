using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    class _20
    {
        public void ReverseInteger(int n)
        {
            Console.Write(n % 10);
            if (n <=9)
                return;
            else
            ReverseInteger(n / 10);

        }

    }
}
