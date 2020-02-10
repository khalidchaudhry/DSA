using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LeetCodeStrings.Easy
{
    public class _67
    {
        public string AddBinary(string a, string b)
        {
            string result = string.Empty;
            string carryOver = string.Empty;

            if (a.Length == 0)
                return b;
            if (b.Length == 0)
                return a;
            // Making their length equal so that we can run below while loop 
            // without writing addiitonal while loop in case one string is shorter than other

            if (a.Length > b.Length)
            {
                int diff = a.Length - b.Length;
                for (int k = 0; k < diff; k++)
                {
                    b = "0" + b;
                }
            }
            else if (b.Length > a.Length)
            {
                int diff = b.Length - a.Length;
                for (int k = 0; k < diff; k++)
                {
                    a = "0" + a;
                }
            }

            int i = a.Length - 1;
            int j = b.Length - 1;

            while (i >= 0 && j >= 0)
            {
                if (a[i].Equals('1') && b[j].Equals('1'))
                {
                    if (carryOver.Equals(string.Empty))
                    {
                        result = '0' + result;
                    }
                    else if (carryOver.Equals("1"))
                    {
                        result = '1' + result;
                    }
                    carryOver = "1";
                }
                else if (a[i].Equals('1') || b[j].Equals('1'))
                {
                    if (carryOver.Equals(string.Empty))
                    {
                        result = "1" + result;
                    }
                    else if (carryOver.Equals("1"))
                    {
                        result = "0" + result;
                        carryOver = "1";
                    }
                }
                else
                {
                    if (carryOver.Equals(string.Empty))
                    {
                        result = "0" + result;
                    }
                    else if (carryOver.Equals("1"))
                    {
                        result = "1" + result;
                        carryOver = string.Empty;
                    }
                }
                --i;
                --j;
            }

            if (carryOver != string.Empty)
            {
                result = carryOver + result;
            }
            return result;
        }

        //https://leetcode.com/problems/add-binary/discuss/24488/Short-AC-solution-in-Java-with-explanation
        public String AddBinary2(String a, String b)
        {
            StringBuilder sb = new StringBuilder();
            //two pointers starting from the back, just think of adding two regular ints from you add from back
            int i = a.Length - 1, j = b.Length - 1, carry = 0;
            while (i >= 0 || j >= 0)
            {
                int sum = carry; //if there is a carry from the last addition, add it to carry 
                if (j >= 0) sum += b[j--] - '0';
                if (i >= 0) sum += a[i--] - '0';
                //if sum==2 or sum==0 append 0 cause 1+1=0 in this case as this is base 2 (just like 1+9 is 0 if adding ints in columns)
                sb.Append(sum % 2);
                //if sum==2 we have a carry, else no carry 1/2 rounds down to 0 in integer arithematic
                carry = sum / 2;
            }
            if (carry != 0) sb.Append(carry); //leftover carry, add it

            // To reverse string
            // Java sb has reverse function. In c# , need to first convert into charArray then call Array.Reverse(charArray)
            char[] charArray = sb.ToString().ToCharArray();
            Array.Reverse(charArray);

            string result = new string(charArray);

            return result;
        }
        
    }
}
