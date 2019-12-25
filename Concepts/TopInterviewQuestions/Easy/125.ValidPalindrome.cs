using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _125
    {
        public bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length==1)
                return true;

            string upperCaseString = s.ToUpper();
            Stack<Char> stk = new Stack<char>();
            int i = 0;
            while (i <upperCaseString.Length)
            {
                if ((upperCaseString[i] >= 65 && upperCaseString[i] <= 90) || (upperCaseString[i] >= 48 && upperCaseString[i] <= 57))
                {
                    stk.Push(upperCaseString[i]);
                }
                ++i;
            }
            i = 0;
            while (i < upperCaseString.Length)
            {
                if ((upperCaseString[i] >= 65 && upperCaseString[i] <= 90) || (upperCaseString[i] >= 48 && upperCaseString[i] <= 57))
                {
                    if (upperCaseString[i] != stk.Pop())
                    {
                        return false;
                    }
                }
                ++i; 
            }
            return true;
        }
        public bool IsPalindrome2(string s)
        {
            if (string.IsNullOrEmpty(s) ||s.Length==1)
            {
                return true;
            }

            int head = 0, tail = s.Length - 1;
            char cHead, cTail;
            while (head <= tail)
            {
                cHead = s[head];
                cTail = s[tail];
                if (!Char.IsLetterOrDigit(cHead))
                {
                    head++;
                }
                else if (!Char.IsLetterOrDigit(cTail))
                {
                    tail--;
                }
                else
                {
                    if (char.ToLower(cHead) != char.ToLower(cTail))
                    {
                        return false;
                    }
                    head++;
                    tail--;
                }
            }

            return true;
        }
    }
}
