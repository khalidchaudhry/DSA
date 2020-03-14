using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    class _28
    {
        int numberOfDigits = 0;
        Stack<string> stk = new Stack<string>();

        public void PrintCommas(long n)
        {
            PrintCommaHelper(n);

            foreach (string s in stk)
            {
                Console.Write(s);
            }
        }

        private void PrintCommaHelper(long n)
        {
            if (n == 0)
            {
                return;
            }
            else
            {
                ++numberOfDigits;
                long quotient = n / 10;
                long remainder = n % 10; // last digit in number
                stk.Push(remainder.ToString());

                if (quotient != 0 && numberOfDigits % 3 == 0)
                {
                    stk.Push(",");
                }
                PrintCommaHelper(quotient);
            }

        }
    }
}
