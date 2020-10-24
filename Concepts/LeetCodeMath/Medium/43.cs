using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Medium
{
    public class _43
    {

        public static void _43Main()
        {

            _43 Multiply = new _43();
            var ans = Multiply.Multiply("2", "3");
            Console.ReadLine();
        }


        /// <summary>
        /// https://www.youtube.com/watch?v=CnEFY5Y3Z68
        /// // # <image url="https://pic1.zhimg.com/80/v2-88b017bb468f3e397d4e6823eb6d4820_720w.jpg" scale="0.4" />  
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string Multiply(string num1, string num2)
        {

            int num1Length = num1.Length;
            int num2Length = num2.Length;
            //! multiplication of two numbers can have m+n digits e.g. 3*9=27 
            int[] result = new int[num1Length + num2Length];

            //!Think of multiplying b*a rather than multiplying by a*b
            for (int i = num1.Length - 1; i >= 0; --i)
            {
                for (int j = num2.Length - 1; j >= 0; --j)
                {
                    int multiply = (num1[i] - '0') * (num2[j] - '0');
                    //! incase if there is any number from previous multiplication, we need to add it. 
                    multiply += result[i + j + 1];

                    result[i + j + 1] = multiply % 10;
                    //! need to add it here in case there was something previous already
                    result[i + j] += multiply / 10;
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (int digit in result)
            {
                //! in case of leading  zeros, just skip them 
                if (sb.Length == 0 && digit == 0)
                {
                    continue;
                }

                sb.Append(digit);
            }
            //! incase length is 0 we need to return 0
            return sb.Length == 0 ? "0" : sb.ToString();
        }

    }
}
