using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs
{
    public class MinStack
    {

        /** initialize your data structure here. */
        Stack<int> MainStk;
        Stack<int> MinStk;
        public MinStack()
        {
            MainStk = new Stack<int>();
            MinStk = new Stack<int>();
        }

        public void Push(int x)
        {
            //! get the current min in MinStk
            int min = MinStk.Count == 0 ? x : MinStk.Peek();
            //! If current min less than current element , push the current min . Else push the new min
            MinStk.Push(min < x ? min : x);
            MainStk.Push(x);

        }

        public void Pop()
        {
            if (MainStk.Count != 0)
            {
                MinStk.Pop();
                MainStk.Pop();
            }
        }

        public int Top()
        {
          return MainStk.Peek();
        }

        public int GetMin()
        {
            return MinStk.Peek();
        }
    }
}
