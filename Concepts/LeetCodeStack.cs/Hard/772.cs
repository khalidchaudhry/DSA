﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Hard
{
    public class _772
    {
        //https://www.javatpoint.com/infix-to-postfix-java
        public int Calculate(string s)
        {
            List<string> postFix = ToPostFix(s);
            return EvalPostFix(postFix);
        }
        private List<string> ToPostFix(string infix)
        {

            Stack<char> operators = new Stack<char>();
            List<string> postfix = new List<string>();

            int i = 0;
            int n = infix.Length;
            while (i < n)
            {
                //skip white spaces
                if (infix[i] == ' ')
                {
                    ++i;
                }
                //!if it's an operand, add it to the string
                else if (char.IsDigit(infix[i]))
                {
                    StringBuilder operand = new StringBuilder();
                    while (i < n && char.IsDigit(infix[i]))
                    {
                        operand.Append(infix[i]);
                        ++i;
                    }
                    postfix.Add(operand.ToString());
                }
                //!push (  
                else if (infix[i] == '(')
                {
                    operators.Push(infix[i]);
                    ++i;
                }
                else if (infix[i] == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        postfix.Add(operators.Pop().ToString());
                    }
                    //!remove '('  
                    operators.Pop();
                    ++i;
                }
                //! if operator               
                else
                {
                    while (operators.Count != 0 &&
                            //! Is above the most recently scanned left parenthesis
                            // Below line not needed. We are handling in Precedence function
                            //operators.Peek() != '(' &&
                            //! Has Precedence of current operator <= operator on top of stack
                            Precedence(infix[i]) <= Precedence(operators.Peek())
                           )
                    {
                        //! append to the postfix string every operator on the stack
                        postfix.Add(operators.Pop().ToString());
                    }

                    operators.Push(infix[i]);
                    ++i;
                }

            }

            while (operators.Count != 0)
            {
                postfix.Add(operators.Pop().ToString());
            }

            return postfix;
        }

        private int Precedence(char x)
        {
            if (x == '(' || x == ')')
                return 0;
            if (x == '+' || x == '-')
                return 1;
            if (x == '*' || x == '/' || x == '%')
                return 2;
            return -1;

        }

        private int EvalPostFix(List<string> postFix)
        {

            Stack<int> stk = new Stack<int>();
            foreach (string token in postFix)
            {
                if (token == "+" || token == "-" || token == "*" || token == "/")
                {
                    if (token == "-" && stk.Count == 1)
                    {
                        int operand = stk.Pop();
                        stk.Push(-operand);
                        continue;
                    }
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
