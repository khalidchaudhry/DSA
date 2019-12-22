using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions
{
    public static class SumOfTwoIntegers
    {
        public static int GetSum(int a, int b)
        {
            while (b != 0)
            {
                int carry = a & b;

                a = a ^ b;

                b = carry << 1;

            }
            return a;
        }
    }
}
