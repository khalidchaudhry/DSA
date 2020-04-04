using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    public class _32
    {
        public void PrintTriangle(int n)
        {
            if (n == 1)
            {
                Console.Write("0");
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write("0");
                }
                Console.WriteLine();
                PrintTriangle(n - 1);
            }

        }

    }
}
