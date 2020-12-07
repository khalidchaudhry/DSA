using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Medium
{
    class _921
    {
        public static void _921Main()
        {                
        }
        public int MinAddToMakeValid(string S)
        {
            Stack<char> stk = new Stack<char>();

            for (int i = 0; i < S.Length; ++i)
            {
                if (S[i] == ')')
                {
                    if (stk.Count != 0 && stk.Peek() == '(')
                        stk.Pop();
                    else
                        stk.Push(')');
                }
                else
                {
                    stk.Push('(');
                }
            }
            return stk.Count;
        }


    }
}
