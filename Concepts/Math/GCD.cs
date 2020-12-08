using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maths
{
    public class GCD
    {

        public  int CalculateGCD(int a, int b)
        {
            int divident = a >= b ? a : b;
            int divisor = a <= b ? a : b;

            while (divisor != 0)
            {
                int remainder = divident % divisor;
                divident = divisor;
                divisor = remainder;
            }
            return divident;
        }

    }
}
