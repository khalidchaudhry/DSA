using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class SortedInsert
    {

        public Stack<int> SortedInsertWithoutRecursion(Stack<int> stk,int element)
        {
            if (element >= stk.Peek())
            {
                stk.Push(element);
                return stk;            
            }
            Stack<int> stk2 = new Stack<int>();

            while (stk.Count != 0)
            {
                stk2.Push(stk.Pop());
            }

            var isInserted = false;
            while (stk2.Count != 0)
            {
                var pop = stk2.Pop();

                if (element < pop && !isInserted)
                {
                    stk.Push(element);
                    stk.Push(pop);
                }
                else
                {
                    stk.Push(pop);
                }
            }

            return stk;
        
        }
        public void SortedInsertWithRecursion(Stack<int> stk, int element)
        {
            if (stk.Count == 0 || element > stk.Peek())
            {
                stk.Push(element);
            }
            else
            {
                var temp = stk.Pop();
                SortedInsertWithRecursion(stk, element);
                stk.Push(temp);
            
            }

        }
    }
}
