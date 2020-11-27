using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeHashTable.Medium
{
    public class _166
    {

        public static void _166Main()
        {
            _166 Main = new _166();
            int numerator = 2;
            int denominator =3;
            var ans = Main.FractionToDecimal(numerator, denominator);
            Console.ReadLine();

        }
        /// <summary>
        /// https://www.youtube.com/watch?v=2cRS9dNa780&t=611s
        /// </summary>
        public string FractionToDecimal(int numerator, int denominator)
        {
            (long ln, long ld) = PreProcess(numerator, denominator);

            long quotient = ln / ld;
            long remainder = ln % ld;


            StringBuilder answer = new StringBuilder();
            //!Key is the remainder and value is what was the length of string builder when remainder occured becuase we want to insert bracket in that location            
            Dictionary<long, long> map = new Dictionary<long, long>();

            answer.Append(quotient);
            if (remainder != 0)
            {
                answer.Append(".");

                while (remainder != 0)
                {
                    if (map.ContainsKey(remainder))
                    {
                        answer.Insert((int)map[remainder], '(');
                        answer.Append(")");
                        break;
                    }
                    //! saving the answer.Length not answer.Length-1
                    //! because sb.Length-1 will give us the location of . and not remainder where we are planning to add 
                    map.Add(remainder, answer.Length);

                    //!new numerator
                    ln = remainder * 10;

                    quotient = ln / ld;
                    remainder = ln % ld;

                    answer.Append(quotient);
                }
            }

            return PostProcess(numerator, denominator, answer);

        }

        private (long ln, long ld) PreProcess(int numerator, int denominator)
        {
            //!casting to long to handle negative cases. 
            //! Because negative of -2,147,483,648 will result in  2,147,483,648 which does not exist int numbers range 
            long ln = numerator;
            long ld = denominator;
            ln = ln < 0 ? -ln : ln;
            ld = ld < 0 ? -ld : ld;

            return (ln, ld);
        }
        private string PostProcess(int numerator, int denominator, StringBuilder sb)
        {
            if (numerator == 0) return "0";

            string result = sb.ToString();
            if (numerator < 0 ^ denominator < 0)
                result = "-" + result;

            return result;
        }


    }
}
