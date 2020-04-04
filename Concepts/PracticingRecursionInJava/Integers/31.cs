using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    public class _31
    {

        public void PrintTriangle(int n)
        {
            if (n == 0)
                return;
            else
            {
                PrintTriangle(n - 1);
                for (int i = 0; i < n; i++)
                {
                    Console.Write("0");
                }

                Console.WriteLine();
            }

        }
    }
}
