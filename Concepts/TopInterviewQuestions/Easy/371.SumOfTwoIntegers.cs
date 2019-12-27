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
                /*
                 Take note of what positions will need a carry, we will left shift
                 this below and make b hold it. Remember: a carry is not applied
                 where it is discovered...it is applied 1 position to the left of
                 where it was born
               */
                int carry = a & b;

                /*
                a's job is to keep the sum we are going to be working on, '^' does
                bit addition, see explanation below to fully understand this
                */
                a = a ^ b;

               /*
               b will house the carry from the operation, we left
               shift by 1 because in the next iteration we will add
               against the carry
               */
                b = carry << 1;

            }
            return a;
        }
    }
}
