using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Hard
{
    public class _224
    {
        public static void _224Main()
        {

            _224 Test = new _224();
            var result = Test.Calculate1("2 - (5 - 6)");
            Console.ReadLine();

        }

        // # <image url="https://static.javatpoint.com/ds/images/applications-of-stack-in-data-structure2.png"  scale="0.9"/>
        //https://www.javatpoint.com/infix-to-postfix-java
        public int Calculate(string s)
        {
            List<string> postFix = InfixToPostFix(s);
            return EvalPostFix(postFix);
        }
        private List<string> InfixToPostFix(string infix)
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
                           //! Is above the most recently scanned left parenthesis
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
            return 0;

        }
        private int EvalPostFix(List<string> postFix)
        {
            Stack<int> stk = new Stack<int>();
            foreach (string token in postFix)
            {
                if (token == "+" || token == "-")
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
                    }
                }
                else
                {
                    stk.Push(Convert.ToInt32(token));
                }
            }

            return stk.Peek();
        }
       


        /// <summary>
        //https://blog.baozitraining.org/search?q=calculator
        //! Basic idea is to push operator and operand into 2 different stacks
        //! The moment you encounter operand , check if its priority <=previous operator.
        //! If yes, do the calculation , else push both the operators and operand on stack
        /// </summary>

        public int Calculate1(string s)
        {
            Stack<char> operators = new Stack<char>();
            Stack<int> operands = new Stack<int>();

            Dictionary<char, int> priority = new Dictionary<char, int>();
            BuildPriority(priority);

            int index = 0;
            while (index < s.Length)
            {
                if (s[index] == ' ')
                {
                    ++index;
                    continue;
                }
                else if (char.IsDigit(s[index]))
                {
                    int num = 0;
                    while (index < s.Length && char.IsDigit(s[index]))
                    {
                        num = num * 10 + s[index] - '0';
                        ++index;
                    }
                    operands.Push(num);
                }
                //! When encounter +,- for the second time than we need to evaluate and push the current operator to stack again
                else if (operators.Count != 0 && priority.ContainsKey(s[index]))
                {
                    CalPrevExprs(operators, operands, priority, s[index]);
                    operators.Push(s[index]);
                    ++index;
                }

                else if (s[index] == ')')
                {
                    CalPrevExprs(operators, operands, priority, s[index]);
                    operators.Pop();//Popping out ( from the stack
                    ++index;
                }
                //!Pushing ( or pushing +,- for first time when operartors does not contain anything
                else
                {
                    operators.Push(s[index]);
                    ++index;
                }

            }

            while (operators.Count != 0)
            {
                CalPrevExpr(operators, operands);
            }

            return operands.Count == 0 ? 0 : operands.Peek();
        }
        private void CalPrevExprs(Stack<char> operators, Stack<int> operands, Dictionary<char, int> priority, char currOperator)
        {

            while (operators.Count != 0 &&
                    operators.Peek() != '(' &&
                   (currOperator == ')' ||   //if encounter bracket than we need to evaluate whole expression till closing one
                    priority[currOperator] <= priority[operators.Peek()]
                   )
                  )
            {
                CalPrevExpr(operators, operands);
            }
        }


        private void CalPrevExpr(Stack<char> operators, Stack<int> operands)
        {
            int operand2 = operands.Pop();
            int operand1 = operands.Pop();
            char oper = operators.Pop();

            switch (oper)
            {
                case '+':
                    operands.Push(operand1 + operand2);
                    break;
                case '-':
                    operands.Push(operand1 - operand2);
                    break;
                case '*':
                    operands.Push(operand1 * operand2);
                    break;
                case '/':
                    operands.Push(operand1 / operand2);
                    break;
            }
        }

        private void BuildPriority(Dictionary<char, int> priority)
        {
            priority.Add('+', 0);
            priority.Add('-', 0);
            priority.Add('*', 1);
            priority.Add('/', 1);
        }

    }

}
