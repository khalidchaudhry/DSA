using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Util
{
    public static class NumberHelper
    {

        public static double RoundToTwoDecimalPlaces(double number)
        {
            return Math.Round(number, 2);
        }
    }
}
