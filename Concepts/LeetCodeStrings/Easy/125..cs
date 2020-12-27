using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStrings.Easy
{
    class _125
    {

        public static void _125Main()
        {
            string s = "A man, a plan, a canal: Panama";
            _125 Test = new _125();
            var result = Test.IsPalindrome0(s);
            Console.ReadLine();
        }

        /// <summary>
        //! using recursion 
        /// </summary>
        public bool IsPalindrome0(string s)
        {
            string str = Normalize(s);
            return Helper(str, 0, str.Length - 1);
        }

        public bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
                return true;

            string upperCaseString = s.ToUpper();
            Stack<Char> stk = new Stack<char>();
            int i = 0;
            while (i < upperCaseString.Length)
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
            if (string.IsNullOrEmpty(s) || s.Length == 1)
            {
                return true;
            }

            int head = 0, tail = s.Length - 1;
            char cHead, cTail;
            while (head <= tail)
            {
                cHead = s[head];
                cTail = s[tail];
                if (!char.IsLetterOrDigit(cHead))
                {
                    head++;
                }
                else if (!char.IsLetterOrDigit(cTail))
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
        private bool Helper(string s, int start, int end)
        {
            if (start > end)
                return true;
            if (start == end)
                return true;

            return s[start] == s[end] && Helper(s, start + 1, end - 1);
        }
        private string Normalize(string s)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in s)
            {
                if (char.IsLetterOrDigit(c))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }


    }
}
