using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStack.Medium
{
    public class _227
    {

        public static void _227Main()
        {

            var test = new _227();
            var ans = test.Calculate0("1 + 2 * 5 / 3 + 6 / 4 * 2");

            Console.ReadLine();

        }
        /// <summary>
        //https://blog.baozitraining.org/search?q=calculator
        //! Basic idea is to push operator and operand into 2 different stacks
        //! The moment you encounter operand , check if its priority <=previous operator.
        //! If yes, do the calculation , else push both the operators and operand on stack
        /// </summary>

        public int Calculate0(string s)
        {
            Dictionary<char, int> priority = new Dictionary<char, int>();
            BuildPriority(priority);

            Stack<char> operators = new Stack<char>();
            Stack<int> operands = new Stack<int>();
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
                else
                {
                    CalPrevExprs(operators,operands,priority,s[index]);
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
            int currOpPr = priority[currOperator];

            while (operators.Count != 0 &&
                   priority[currOperator] <= priority[operators.Peek()]
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

        /// <summary>
        /// https://leetcode.com/problems/basic-calculator-ii/discuss/63003/Share-my-java-solution
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Calculate(string s)
        {
            if (s.Length == 0)
                return 0;
            int n = s.Length;
            //! why initializing with '+' because in case there is only digits in the string without any operand like 23
            //! sign will hold the previous sign element
            char sign = '+';
            Stack<int> stk = new Stack<int>();
            int num = 0;
            for (int i = 0; i < n; i++)
            {
                bool isDigit = char.IsDigit(s[i]);
                if (isDigit)
                {
                    num = num * 10 + (s[i] - '0');
                }
                //! In case its operator
                if ((!isDigit && s[i] != ' ') ||
                     i == n - 1)
                {
                    switch (sign)
                    {
                        case '+':
                            stk.Push(num);
                            break;
                        case '-':
                            //! Pushing negative so that we can sum them all easily 
                            stk.Push(-num);
                            break;
                        case '*':
                            //! Poping and then pushing back
                            stk.Push(stk.Pop() * num);
                            break;
                        case '/':
                            //! Poping and then pushing back
                            stk.Push(stk.Pop() / num);
                            break;
                    }

                    num = 0;
                    sign = s[i];
                }
            }

            int result = 0;
            while (stk.Count != 0)
            {
                result += stk.Pop();
            }
            return result;
        }
    }
}
