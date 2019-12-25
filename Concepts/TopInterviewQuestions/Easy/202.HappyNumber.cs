using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _202
    {
        public bool IsHappy(int n)
        {
            HashSet<int> hs = new HashSet<int>();
            //if n == 1 than it means number is happy number and we can break loop
            while (n != 1)
            {
                n = NewNumber(n);
                //If we encounter the same number again than it means that it's not happy number and we return it back
                if (hs.Contains(n))
                {
                    return false;
                }
                hs.Add(n);
            }

            return true;
        }

        public int NewNumber(int n)
        {
            int sum = 0;
            while (n != 0)
            {
                int mod = n % 10;
                sum += mod * mod;
                n = n / 10;
            }
            return sum;
        }
    }
}
