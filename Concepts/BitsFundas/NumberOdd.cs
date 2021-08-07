using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsFundas
{
    public static class NumberOdd
    {
        public static bool IsNumberOdd(int number)
        {
            return (number & 1) != 0 ? true : false;
        }
    }
}
