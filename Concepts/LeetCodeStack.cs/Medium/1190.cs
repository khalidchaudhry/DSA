using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Medium
{
    public class _1190
    {
        ///Space and time complexity
        //!Time=O(n^2)  worst case is (((u)i)l) 
        //!Space=O(n)
      
        public string ReverseParentheses(string s)
        {
            Stack<char> stk = new Stack<char>();
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == ')')
                    Reverse(stk);
                else
                    stk.Push(s[i]);

            }

            return PrepareResult(stk);
        }
        private void Reverse(Stack<char> stk)
        {
            StringBuilder sb = new StringBuilder();
            while (stk.Peek() != '(')
            {
                sb.Append(stk.Pop());
            }

            stk.Pop();

            for (int i = 0; i < sb.Length; ++i)
            {
                stk.Push(sb[i]);
            }
        }
        private string PrepareResult(Stack<char> stk)
        {
            //! Populating at chars array from back
            char[] chars = new char[stk.Count];
            int index = stk.Count - 1;
            while (stk.Count != 0)
            {
                chars[index] = stk.Pop();
                --index;
            }

            return new string(chars);
        }
    }
}
