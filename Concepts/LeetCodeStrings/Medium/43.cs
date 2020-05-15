using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _43
    {
        /// <summary>
        /// https://www.youtube.com/watch?v=CnEFY5Y3Z68    
        //!Time complexity is O(m*n)
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>



        public string Multiply0(string num1, string num2)
        {
            int m = num1.Length;
            int n = num2.Length;
            int[] result = new int[m + n];
            ///     j
            ///     ^
            /// m=123
            /// n=456
            ///     ^
            ///     i
            for (int i = n - 1; i >= 0; --i)
            {
                for (int j = m - 1; j >= 0; --j)
                {

                    int multiply = (num2[i] - '0') * (num1[j] - '0');
                    int sum = result[i + j + 1] + multiply;

                    int remainder = sum % 10;
                    int quotient = sum / 10;

                    result[i + j + 1] = remainder;
                    result[i + j] += quotient;
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //! For input m=9133  and n=0 . Without it output will be "0000" but expected is "0"
                //! Below line isbeautiful 
                if (sb.Length != 0 || result[i] != 0)
                {
                    sb.Append(result[i]);
                }


            }
            //! For below input we need to add this condition sb.Length == 0 ? "0" 
            //m="0"
            //n="0"
            return sb.Length == 0 ? "0" : sb.ToString();


        }
        public string Multiply(string num1, string num2)
        {

            double num1Number = StringToNumber(num1);
            double num2Number = StringToNumber(num2);
            double product = num1Number * num2Number;

            string defaultNumber = product.ToString(); //9E-05
            string numberFromToString = product.ToString("N5"); //0.00009
            string numberFromStringFormat = string.Format("{0:F5}", product);

            return string.Empty;
        }

        private string Multiply(double product)
        {
            StringBuilder sb = new StringBuilder();
            double quotient = product;

            while (quotient != 0)
            {
                double remainder = quotient % 10;
                quotient = Math.Truncate(quotient / 10);
                sb.Append(remainder);
            }
            string str = sb.ToString();
            var strArray = str.ToCharArray();
            Array.Reverse(strArray);
            return new string(strArray);
        }

        private double StringToNumber(string num1)
        {
            double multiplier = 1;
            double result = 0;
            for (int i = num1.Length - 1; i >= 0; --i, multiplier = multiplier * 10)
            {
                result += (num1[i] - '0') * multiplier;
            }

            return result;
        }
    }
}
