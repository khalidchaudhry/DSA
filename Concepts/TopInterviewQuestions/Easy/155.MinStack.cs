using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{

    public class MinStack
    {

        /** initialize your data structure here. */
        Stack<int> minStack = new Stack<int>();
        Stack<int> mainStack = new Stack<int>();
        public MinStack()
        {

        }

        public void Push(int x)
        {
            if (minStack.Count==0 ||x <= minStack.Peek())
            {
                minStack.Push(x);
            }

            mainStack.Push(x);

        }

        public void Pop()
        {
            if (minStack.Peek() == mainStack.Peek())
            {
                minStack.Pop();
            }
            mainStack.Pop();
        }

        public int Top()
        {
            int topElement = mainStack.Peek();
            
            return topElement;
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }

    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(x);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
}
