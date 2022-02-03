using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Expedia
{
    public class ExpediaScreening
    {

        public static void ExpediaScreeningMain()
        {
            Stack<int> stk = new Stack<int>();

            stk.Push(1);
            stk.Push(10);
            stk.Push(3);
            stk.Push(7);
            stk.Push(50);
            stk.Push(9);

            ExpediaScreening screening = new ExpediaScreening();

            var result=screening.SortStack(stk);

            Console.ReadLine();
            

        }
        public Stack<int> SortStack(Stack<int> stk)
        {
            Stack<int> temp = new Stack<int>();
            while (stk.Count > 0)
            {
                int top = stk.Pop();                
                while (temp.Count > 0 && temp.Peek() > top)
                {
                    stk.Push(temp.Pop());
                }
                temp.Push(top);
            }
            return temp;
        }

    }
}
