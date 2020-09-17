using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    public class _29
    {
        public static void _29Main()
        {
            _29 Division = new _29();
            int divident = -2147483648;
            int divisor = 2;
            var ans = Division.Divide(divident, divisor);

            Console.ReadLine();
        }
        public int Divide(int dividend, int divisor)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            //for divisor 3 map will contain 
            /*
                 3      1
                 6      2
                 12     4
                 24     16                 
             */

            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }

            if (divisor == 1)
            {
                return dividend;
            }


            int negativeCount = 0;
            if (dividend < 0)
            {
                dividend = -dividend;
                ++negativeCount;
            }
            if (divisor < 0)
            {
                divisor = -divisor;
                ++negativeCount;
            }

            int result = 0;
            int current = dividend;


            for (int i = 0; i <30; ++i)
            {
                map[divisor << i] = 1 << i;
            }

            while (current >= divisor)
            {
                int q = MaxLowerThen(current, map);
                result += map[q];
                current -= q;
            }

            if (negativeCount == 1)
            {
                result = -result;
            }

            return result;
        }

        private int MaxLowerThen(int current, Dictionary<int, int> map)
        {
            int max = 0;
            foreach (KeyValuePair<int, int> entry in map)
            {
                if (entry.Key <= current)
                {
                    max = entry.Key;
                }
                else
                {
                    break;
                }
            }

            return max;
        }
    }
}
