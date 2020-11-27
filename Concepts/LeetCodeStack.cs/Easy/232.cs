using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Easy
{
    public class _232
    {

    }

    /// <summary>
    //! Main idea is to keep two stacks .. One for pushing and another one for popping 
    /// </summary>
    public class MyQueue
    {

        /** Initialize your data structure here. */
        Stack<int> _pushStack;
        Stack<int> _popStack;

        public MyQueue()
        {
            _pushStack = new Stack<int>();
            _popStack = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            _pushStack.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            Peek();
            return _popStack.Pop();
        }

        /** Get the front element. */
        public int Peek()
        {
            if (_pushStack.Count == 0 && _popStack.Count == 0) throw new Exception("Queue is empty");
            if (_popStack.Count == 0)
            {
                while (_pushStack.Count != 0)
                {
                    _popStack.Push(_pushStack.Pop());
                }
            }
            return _popStack.Peek();

        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return _pushStack.Count == 0 && _popStack.Count == 0 ? true : false;
        }
    }

}
