using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Easy
{
    public class _1071
    {
        public string GcdOfStrings(string str1, string str2)
        {

            if (str1 + str2 != str2 + str1) //! Check whether or not a GCD is possible, first
                return "";

            int gcd = GCD(str1.Length, str2.Length);

            return str1.Substring(0, gcd);

        }

        private int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);

        }


    }
}
