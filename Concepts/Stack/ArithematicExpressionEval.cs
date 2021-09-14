using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{

    //https://www.javatpoint.com/infix-to-postfix-java
    public class ArithematicExpressionEval
    {

        public void ArithematicExpressionEvalMain()
        {
            ArithematicExpressionEval test = new ArithematicExpressionEval();
            string infix = " - 2 + 1";
            List<string> postfixExpression = test.ToPostFix(infix);

            int result = test.EvalPostFix(postfixExpression);
            Console.ReadLine();



        }

        public List<string> ToPostFix(string infix)
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
                //!Append  operators occurring before it that have greater precedence  
                else
                {
                    while (operators.Count != 0 &&
                           operators.Peek() != '(' &&
                           Precedence(infix[i]) <= Precedence(operators.Peek())
                           )
                    {
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
            if (x == '+' || x == '-')
                return 1;
            if (x == '*' || x == '/' || x == '%')
                return 2;
            return 0;

        }

        public int EvalPostFix(List<string> postFix)
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
