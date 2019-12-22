using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _6
    {
        public bool IsPowerOfThree(int n)
        {
            if (n <=0)
            {
                return false;
            }
            if (n == 1)
            {
                return true;
            }

            while (n != 0 && n != 1 && n != -1)
            {
                int quotient = n / 3;

                int remainder = n % 3;

                if (remainder != 0)
                {
                    return false;
                }

                n = quotient;
            }

            return true;
        }

    }
}
