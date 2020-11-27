using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Medium
{
    public class _394
    {
        public static void _394Main()
        {


            var res = new _394();
            var test=res.DecodeString0("3[a]2[bc]");
            Console.ReadLine();


        }
        /// <summary>
        //!   Based on idea in Kua's  class. Gotcha's in this question is that numbers canbe two digits and we need to reverse the strings in very end
        /// </summary>
        public string DecodeString0(string s)
        {

            int index = 0;
            Stack<int> intStk = new Stack<int>();
            Stack<char> stk = new Stack<char>();

            while (index < s.Length)
            {
                if (Char.IsDigit(s[index]))
                {
                    int number = 0;
                    while (s[index] != '[')
                    {
                        //! Convert.ToInt32() will give wrong result.
                        //! Either use line below or (int)char.GetNumericValue() to get corresponding digit. 
                        int digit = s[index] - '0';
                        number = number * 10 + digit;
                        ++index;
                    }

                    intStk.Push(number);
                }
                else if (s[index] == ']')
                {
                    Decode(stk, intStk);
                    ++index;
                }
                else
                {
                    stk.Push(s[index]);
                    ++index;
                }
            }
            return PrepareResult(stk);
        }

        private void Decode(Stack<char> stk, Stack<int> intStk)
        {
            StringBuilder sb = new StringBuilder();
            while (stk.Peek() != '[')
            {
                sb.Append(stk.Pop());
            }

            stk.Pop();

            int times = intStk.Pop();
            for (int i = 0; i < times; ++i)
            {
                //! We need to push in reverse order to maintain the order of the enclosed string. 
                for (int j = sb.Length - 1; j >= 0; --j)
                {
                    stk.Push(sb[j]);
                }
            }
        }

        private string PrepareResult(Stack<char> stk)
        {
            char[] charArray = new char[stk.Count];

            int i = stk.Count - 1;
            while (stk.Count != 0)
            {
                charArray[i] = stk.Pop();
                --i;
            }

            return new string(charArray);
        }
    }
}
