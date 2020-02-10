using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Easy
{
    class _415
    {
        public string AddStrings(string num1, string num2)
        {
            if (num1.Length == 0 && num2.Length == 0)
            {
                return string.Empty;
            }
            if (num1.Length == 0 && num2.Length != 0)
            {
                return num2;
            }
            if (num1.Length != 0 && num2.Length == 0)
            {
                return num1;
            }
            StringBuilder sb = new StringBuilder();
            int i = num1.Length - 1;
            int j = num2.Length - 1;
            int carry = 0;
            while (i >= 0 || j >= 0)
            {
                int sum = carry;
                if (i >= 0)
                {
                    sum += num1[i--] - '0';
                }
                if (j >= 0)
                {
                    sum += num2[j--] - '0';
                }

                sb.Append(sum % 10);

                carry = sum / 10;
            }

            if (carry != 0)
            {
                sb.Append(carry);
            }
            // important to note how to reverse string in C#
            var charArray = sb.ToString().ToCharArray();

            Array.Reverse(charArray);

            return new string(charArray);
        }


    }
}
