using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Medium
{
    public class _150
    {
        /// <summary>
        //! Time=O(n)  
        //! Space=O(n)
        /// </summary>
        
        public int EvalRPN(string[] tokens)
        {
            Stack<int> stk = new Stack<int>();
            foreach (string token in tokens)
            {
                if (token == "+" || token == "-" || token == "*" || token == "/")
                {
                    //! We always pop twice and push once hence its O(1)
                    int operand2 = stk.Pop();
                    int operand1 = stk.Pop();
                    switch (token)
                    {
                        case "+":
                            stk.Push(operand1 + operand2);
                            break;
                        case "-":
                            stk.Push(operand1 - operand2);
                            break;
                        case "*":
                            stk.Push(operand1 * operand2);
                            break;
                        case "/":
                            stk.Push(operand1 / operand2);
                            break;
                    }
                }
                else
                {
                    stk.Push(Convert.ToInt32(token));
                }
            }
            return stk.Peek();
        }       
    }
}
