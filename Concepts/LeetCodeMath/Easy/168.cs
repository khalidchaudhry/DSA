using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Easy
{
    public class _168
    {
        public static void _168Main()
        {

            int n = 28;
            _168 Test = new _168();
            var ans = Test.ConvertToTitle(701);
            Console.ReadLine();

        }

        public string ConvertToTitle(int n)
        {
            string result = string.Empty;
            while (n != 0)
            {
                //! Input is 1-26 for single digit(just like 0-9 for decimal) 
                //! and covert it into 0-25(base 26)
                // ! it will help us doing math in simpler way
                --n;
                int remainder = n % 26;
                result = (char)('A' + remainder) + result;
                n = n / 26;
            }

            return result;
        }


    }
}
