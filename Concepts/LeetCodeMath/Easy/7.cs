using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Easy
{
    public class _7
    {
        public static void _7Main()
        {
            int x = 1;

            _7 Reverse = new _7();
            var ans=Reverse.Reverse(x);
            Console.ReadLine();
        }
        public int Reverse(int x)
        {
            bool isNegative = x < 0 ? true : false;
            long number = x;
            //! Math.Abs will not work if input is Int.MinValue hence we need to convert it into long first before taking Abs
            number = Math.Abs(number);

            int numberOfTens = (int)Math.Floor(Math.Log10(number) + 1)-1;           
            //! ans needs tobe in double as it will cause overflow even for longS        
            double ans = 0;
            while (number != 0)
            {
                long remainder = number % 10;
                ans += remainder * Math.Pow(10, numberOfTens--);
                number = number / 10;
            }

            return ans > int.MaxValue ? 0 : isNegative ? -(int)ans : (int)ans;
        }

        public int Reverse2(int x)
        {
            int result = 0;
            while (x != 0)
            {
                int remainder = x % 10;
                checked
                {
                    try
                    {
                        result = (result * 10) + remainder;
                    }
                    catch (OverflowException ex)
                    {
                        result = 0;
                        break;
                    }
                }
                
                x = x / 10;
            }


            return result;

        }

    }
}
