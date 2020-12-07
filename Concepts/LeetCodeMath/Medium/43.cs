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
            var ans = Multiply.Multiply0("123", "456");
            Console.ReadLine();
        }
        /// <summary>
        //! Take aways
        //! Take away 1: we can convert string to number using s[i]-'0'
        //! Take away 2: Pay attention to edge cases where  we need to skip leading zeros but don't skip in between 0's e.g. (0039089)
        //! https://www.acwing.com/solution/LeetCode/content/11159/
        //# <image url="https://cdn.acwing.com/media/article/image/2020/04/07/10285_afd7522f78-IMG_0002.PNG" scale="0.4" />  
        /// </summary>

        public string Multiply0(string num1, string num2)
        {
            //! multiplication of two numbers can have m+n digits e.g. 3*9=27 
            int[] result = new int[num1.Length + num2.Length];
            Product(result, num1, num2);
            return PrepareResult(result);
        }

        private void Product(int[] result, string num1, string num2)
        {
            //!Think of multiplying b*a rather than multiplying by a*b
            for (int i = num1.Length - 1; i >= 0; --i)
            {
                for (int j = num2.Length - 1; j >= 0; --j)
                {
                    int a = num1[i] - '0';
                    int b = num2[j] - '0';
                    result[i + j + 1] += a * b;
                }
            }
            int carry = 0;
            for (int i = result.Length - 1; i >= 0; --i)
            {
                int temp = result[i] + carry;
                result[i] = temp % 10;
                carry = temp / 10;
            }
        }
        private string PrepareResult(int[] result)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; ++i)
            {
                //! in case of leading  zeros, just skip them 
                if (sb.Length == 0 && result[i] == 0)
                {
                    continue;
                }

                sb.Append(result[i]);
            }

            //! incase length is 0 we need to return 0
            return sb.Length == 0 ? "0" : sb.ToString();
        }
    }
}
