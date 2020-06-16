using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _20
    {
        public bool IsValid(string s)
        {
            Stack<Char> stk = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '[' || s[i] == '(' || s[i] == '{')
                {
                    stk.Push(s[i]);
                }
                else
                {
                    if (stk.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        char peek = stk.Peek();
                        if ((s[i] == ']' && peek == '[') ||
                            (s[i] == ')' && peek == '(') ||
                            (s[i] == '}' && peek == '{'))
                        {
                            stk.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            if (stk.Count != 0)
            {
                return false;
            }

            return true;
        }
        public bool IsValid2(string s)
        {
            Stack<Char> stk = new Stack<Char>();
            for (int i=0;i<s.Length;i++)
            {
                char c = s[i];
                if (c == '(')
                    stk.Push(')');
                else if (c == '{')
                    stk.Push('}');
                else if (c == '[')
                    stk.Push(']');
                // ! stk.Count==0 is there becuase in case input contains only closing bracket  e.g. s="]"
                else if (stk.Count==0 || stk.Pop() != c)
                    return false;
            }
            return stk.Count == 0;
        }



    }
}
