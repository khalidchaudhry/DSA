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
            int result = 0;
            Stack<char> stk = new Stack<char>();
            for (int i = 0; i < S.Length; ++i)
            {
                if (S[i].Equals('('))
                {
                    stk.Push('(');

                }
                else
                {
                    if (stk.Count != 0)
                    {
                        stk.Pop();
                    }
                    else
                    {
                        ++result;
                    }
                }                
            }

            return result+stk.Count;
        }


    }
}
