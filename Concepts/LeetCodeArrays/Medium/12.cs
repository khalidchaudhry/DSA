using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _12
    {
        public string IntToRoman(int num)
        {


            if (num == 0)
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            Dictionary<int, string> map = new Dictionary<int, string>()
            {
                {1,"I"},
                {5,"V"},
                {10,"X"},
                {50,"L"},
                {100,"C"},
                {500,"D"},
                {1000,"M"},
                {4,"IV"},
                {9,"IX"},
                {40,"XL"},
                {90,"XC"},
                {400,"CD"},
                {900,"CM"}
            };

            int numOfDigits = NumberOfDigits(num);

            while (num != 0)
            {
                int divisor = (int)Math.Pow(10, numOfDigits - 1);

                int quotient = num / divisor;
                int key = quotient * divisor;

                if (map.ContainsKey(key))
                {
                    sb.Append(map);
                }
                else
                {
                    int multiply = 1;
                    while (quotient!= 0)
                    {
                        int temp = divisor *--quotient;
                        if (map.ContainsKey(temp))
                        {
                            sb.Append(map[temp]);
                            break;
                        }
                        else
                        {
                            ++multiply;
                        }                        
                    }
                    while (multiply != 0)
                    {
                        sb.Append(map[divisor]);
                        --multiply;
                    }
                }

                --numOfDigits;

                num = num % divisor;

            }

            return sb.ToString();
        }

        private int NumberOfDigits(int num)
        {
            int numberOfDigits = 0;
            while (num != 0)
            {
                ++numberOfDigits;
                num = num / 10;
            }
            return numberOfDigits;
        }
    }
}
