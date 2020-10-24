using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Medium
{
    class _592
    {
        public static  void _592Main()
        {
            string expression = "5/3+1/3";
            _592 FractionAddition = new _592();

           var result=FractionAddition.FractionAddition(expression);
            Console.ReadLine();

        }


        public string FractionAddition(string expression)
        {
            List<char> signs = new List<char>();

            char firstSymbol = expression[0] == '-' ? '-' : '+';

            signs.Add(firstSymbol);

            for (int i = 1; i < expression.Length; ++i)
            {
                if (expression[i] == '+' || expression[i] == '-')
                {
                    signs.Add(expression[i]);
                }
            }

            //!extracting numerator and denominator from expression
            List<int> numerators = new List<int>();
            List<int> denominators = new List<int>();
            string[] fractions = expression.Split(new char[] { '+', '-' });
            foreach (string fraction in fractions)
            {
                string[] numDeno = fraction.Split(new char[] { '/' });
                //! incase if first character is sign + or - just continue
                if (numDeno[0] == string.Empty) continue;
                numerators.Add(int.Parse(numDeno[0]));
                denominators.Add(int.Parse(numDeno[1]));
            }

            

            if (signs[0] == '-') numerators[0] = -numerators[0];

            //! Find out LCM 
            int lcm = 1;
            foreach (int denominator in denominators)
            {
                lcm = LCM(lcm, denominator);
            }

            //!scaling factor for a fraction
            int res = (lcm / denominators[0]) * numerators[0];

            for (int i = 1; i < denominators.Count; ++i)
            {
                if (signs[i] == '+')
                {
                    res += (lcm / denominators[i]) * numerators[i];
                }
                else
                {
                    res -= (lcm / denominators[i]) * numerators[i];
                }
            }

            int gcd = GCD(Math.Abs(res), Math.Abs(lcm));

            return $"{res / gcd}/{lcm / gcd} ";
        }

        public int LCM(int a, int b)
        {
            return (a * b) / GCD(a, b);
        }


        public int GCD(int a, int b)
        {
            if (b == 0) return a;
            return GCD(b, a % b);
        }

    }
}
