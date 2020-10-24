using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Medium
{
    public class _357
    {

        /// <summary>
        /// https://www.youtube.com/watch?v=OkJKxoDbQ_c
        //! Intutition for this problem is finding out possibilities available for every digit in a number
        //! Its combinitorial problem.
        //! Important equation: 
        //! f(2)=9*9 , f(3)=f(2)*8,  f(4)=f(3)*7
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountNumbersWithUniqueDigits(int n)
        {
            if (n == 0)
                return 1;

            //! for single digit we have 10 choices 
            int result = 10;
            //! for first digit we have 9 options as we can't have 0 in number beginning 
            //!e.g 0123 is not valid
            int uniqueDigits = 9;
            int availableNumber = 9;

            while (n > 1 && availableNumber > 0)
            {
                //!f(1)=10(0,1,2,3,4,5,6...9)
                //!f(2)=9*9  (for 2 digit number we have 9 possibiities for first digit than 9 for second )
                //! f(3)=f(2)*8
                //! f(4)=f(3)*7
                //.......
                //.....

                uniqueDigits = uniqueDigits * availableNumber;

                result += uniqueDigits;
                --availableNumber;
                --n;
            }

            return uniqueDigits;
        }


    }
}
