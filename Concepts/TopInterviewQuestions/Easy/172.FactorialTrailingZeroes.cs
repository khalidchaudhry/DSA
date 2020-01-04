using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _172
    {
        public int TrailingZeroes(int n)
        {
            // Simple solution -- We can find zero and divide by 10 to find the answer 
            // but due to holding size of integer 
            // Minimal Approach is to find number of 2 and 5 which makes zero like 10 
            // Rather than finding both let's find 5 as it is lesser found than 2 
            int count = 0;
            if (n < 5)
                return count;

            while (n >= 5)
            {
                count += n / 5;
                n /= 5;
            }

            return count;
        }
    }
}
