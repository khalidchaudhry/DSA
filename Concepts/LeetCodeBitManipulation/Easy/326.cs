using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _326
    {

        //https://leetcode.com/problems/power-of-three/discuss/77977/Math-1-liner-no-log-with-explanation
        public bool IsPowerOfThree(int n)
        {
            //! The positive divisors of 3^ 19 are exactly the powers of 3 from 3^0 to 3^19. 
            //! That's all powers of 3 in the possible range here (signed 32-bit integer)
            return n > 0 && Math.Pow(3, 19) % n == 0;
        }

        public bool IsPowerOfThree1(int n)
        {
            if (n == 0) return false;

            while (n != 1)
            {
                if (n % 3 != 0) return false;
                n = n / 3;
            }
            return true;
        }

    }
}
