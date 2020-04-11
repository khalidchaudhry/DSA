using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _12
    {
        public string IntToRoman(int num)
        {
            // if num is zero no exists for it hence we can return 
            if (num == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            /*
             Need to pay attention here as we are adding more mapping than apparently given in the question
             e.g. In question its mentioned that "I can be placed before V (5) and X (10) to make 4 and 9"
             translates into two additional entries in map
             IV---> 4
             IX--->9
           */
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
            // calculate number of digits we have
            int numOfDigits = NumberOfDigits(num);

            while (num != 0)
            {
                // calculate divisor based on number of digits in number.
                // Number of digits will change with every loop iteration
                int divisor = (int)Math.Pow(10, numOfDigits - 1);
                
                int quotient = num / divisor;
                int key = quotient * divisor;

                if (map.ContainsKey(key))
                {
                    sb.Append(map[key]);
                }
                else
                {
                    int multiply = 1;
                    while (quotient!= 0)
                    {
                        // decrementing quotient by one in loop 
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
                    // appending all the muliples to string builder. 
                    while (multiply != 0)
                    {
                        sb.Append(map[divisor]);
                        --multiply;
                    }
                }

                int remainder = num % divisor;
                numOfDigits =NumberOfDigits(remainder);

                num = remainder;

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
