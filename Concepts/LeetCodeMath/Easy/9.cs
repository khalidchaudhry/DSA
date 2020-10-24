using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeMath.Easy
{
    public class _9
    {

        /// <summary>
        //! intuition here is to mod  elements and put remainder in stack.
        //! Mod again and compare with popped element. If not equal return false. By default retun true
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            //single digit is always palindrome
            if (x < 10) return true;

            Stack<int> stk = new Stack<int>();
            int input = x;

            while (input != 0)
            {
                stk.Push(input % 10);
                input = input / 10;
            }

            input = x;

            while (input != 0)
            {
                int remainder = input % 10;
                if (stk.Pop() != remainder)
                {
                    return false;
                }

                input = input / 10;
            }

            return true;
        }
        public bool IsPalindrome2(int x)
        {
            if (x < 0) return false;
            //single digit is always palindrome
            if (x < 10) return true;

            double reverseNumber = 0;
            int input = x;
            int powerOf10 = (int)Math.Floor(Math.Log10(x) + 1) - 1;

            while (input != 0)
            {
                reverseNumber += (input % 10) * Math.Pow(10, powerOf10--);
                input = input / 10;
            }
            if (x != (int)reverseNumber)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
