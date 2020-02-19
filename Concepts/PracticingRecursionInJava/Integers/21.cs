using System;
using System.Collections.Generic;
using System.Text;

namespace PracticingRecursionInJava.Integers
{
    class _21
    {
        public bool IsPalindrome(long n, int numberOfDigits)
        {
            long first, last;
            if (numberOfDigits <= 1)
            {
                return true;
            }
            else
            {
                // get the first digit
                first = (long)(n / Math.Pow(10, numberOfDigits - 1));
                // get the last digit
                last = n % 10;

                if (first != last)
                {
                    return false;
                }
                else
                {

                    // Truncate(remove) the first digit
                    long newNumber =(long)( n % Math.Pow(10, numberOfDigits - 1));
                    // Truncate(remove) the last digit
                    newNumber = newNumber / 10;

                    return IsPalindrome(newNumber, numberOfDigits - 2);
                }
            }
        }
    }
}

