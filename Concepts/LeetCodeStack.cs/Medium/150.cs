using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Medium
{
    public class _150
    {
        public int EvalRPN(string[] tokens)
        {
            Stack<int> stk = new Stack<int>();
            for (int i = 0; i < tokens.Length; ++i)
            {
                if (tokens[i] == "+" ||
                   tokens[i] == "-" ||
                   tokens[i] == "*" ||
                   tokens[i] == "/"
                   )
                {
                    Calculate(stk, tokens[i]);
                }
                else
                {
                    stk.Push(Convert.ToInt32(tokens[i]));
                }
            }

            return stk.Count == 0 ? 0 : stk.Peek();
        }
        private void Calculate(Stack<int> stk, string oper)
        {
            int operand2 = stk.Pop();
            int operand1 = stk.Pop();
            int result = 0;
            if (oper == "+")
            {
                result = operand1 + operand2;
            }
            else if (oper == "-")
            {
                result = operand1 - operand2;
            }
            else if (oper == "*")
            {
                result = operand1 * operand2;
            }
            else
            {
                result = operand1 / operand2;
            }

            stk.Push(result);
        }
    }
}
