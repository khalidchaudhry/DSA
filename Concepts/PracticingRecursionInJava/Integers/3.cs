using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    class _3
    {
        public void PrintNto1(int n)
        {
            if (n != 0)
            {
                Console.Write(n);
                PrintNto1(n-1);
            }
        }
    }
}
