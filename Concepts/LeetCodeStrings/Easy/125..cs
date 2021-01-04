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
            int start = 0;
            int end = s.Length - 1;
            return Helper(s, start, end);
        }

        //! using iterative approach
        public bool IsPalindrome(string s)
        {
            int start = 0;
            int end = s.Length - 1;
            while (start < end)
            {
                if (!Char.IsLetterOrDigit(s[start]))
                    ++start;
                else if (!Char.IsLetterOrDigit(s[end]))
                    --end;
                else
                {
                    if (char.ToLower(s[start]) != char.ToLower(s[end]))
                        return false;
                    ++start;
                    --end;
                }
            }
            return true;
        }
       
        private bool Helper(string str, int s, int e)
        {
            if (s > e)
            {
                return true;
            }

            if (!char.IsLetterOrDigit(str[s]))
                return Helper(str, s + 1, e);

            if (!char.IsLetterOrDigit(str[e]))
                return Helper(str, s, e - 1);

            if (char.ToLower(str[s]) != char.ToLower(str[e]))
                return false;

            return Helper(str, s + 1, e - 1);
        }
    }
}
