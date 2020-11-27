using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _227
    {
        /// <summary>
        /// https://leetcode.com/problems/basic-calculator-ii/discuss/63003/Share-my-java-solution
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Calculate(string s)
        {
            if (s.Length == 0)
                return 0;
            int n = s.Length;
            //! why initializing with '+' because in case there is only digits in the string without any operand like 23
            //! sign will hold the previous sign element
            char sign = '+';
            Stack<int> stk = new Stack<int>();
            int num = 0;
            for (int i = 0; i < n; i++)
            {
                bool isDigit = char.IsDigit(s[i]);
                if (isDigit)
                {
                    num = num * 10 + (s[i]-'0');
                }
                //! In case its operator
                if ((!isDigit && s[i] != ' ') ||
                     i == n - 1)
                {
                    switch (sign)
                    {
                        case '+':
                            stk.Push(num);
                            break;
                        case '-':
                            //! Pushing negative so that we can sum them all easily 
                            stk.Push(-num);
                            break;
                        case '*':
                            //! Poping and then pushing back
                            stk.Push(stk.Pop() * num);
                            break;
                        case '/':
                            //! Poping and then pushing back
                            stk.Push(stk.Pop() / num);
                            break;
                    }

                    num = 0;
                    sign = s[i];
                }
            }

            int result = 0;
            while (stk.Count != 0)
            {
                result += stk.Pop();
            }
            return result;
        }
    }
}
