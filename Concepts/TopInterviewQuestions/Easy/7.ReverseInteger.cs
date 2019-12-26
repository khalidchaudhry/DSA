using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _7
    {
        public int Reverse(int x)
        {
            Stack<int> stk = new Stack<int>();
            int result = 0;

            while (x != 0)
            {
                stk.Push(x % 10);
                x = x / 10;
            }

            int i = 0;
            while (stk.Count != 0)
            {
                int poppedItem = stk.Pop();
                checked
                {
                    try
                    {
                        result += poppedItem * (int)Math.Pow(10, i);
                    }
                    catch (OverflowException ex)
                    {
                        result = 0;
                        break;
                    }
                }
                ++i;
            }

            return result;

        }

        public int Reverse2(int x)
        {
            int result = 0;
            while (x != 0)
            {
                int remainder = x % 10;
                checked
                {
                    try
                    {
                        result = (result * 10) + remainder;
                    }
                    catch (OverflowException ex)
                    {
                        result = 0;
                        break;
                    }
                }

                x = x / 10;
             }


            return result;

        }
    }
}
