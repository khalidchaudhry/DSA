using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Easy
{
    class _225
    {
    
    }


    /// <summary>
    //! Using one queue only
    /// </summary>
    public class MyStack0
    {

        /** Initialize your data structure here. */
        Queue<int> _queue;
        public MyStack0()
        {
            _queue = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {

            _queue.Enqueue(x);
            int queueSize = _queue.Count;
            //! We are actually rotating the queue.
            //! Think about it. Moving first item to last
            while (queueSize > 1)
            {
                //!Remove from the queue and add it back at the top 
                _queue.Enqueue(_queue.Dequeue());
                --queueSize;
            }
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            if (_queue.Count == 0) throw new Exception("Stack is empty");

            return _queue.Dequeue();
        }

        /** Get the top element. */
        public int Top()
        {
            if (_queue.Count == 0) throw new Exception("Stack is empty");
            return _queue.Peek();
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return _queue.Count == 0 ? true : false;
        }
    }

    public class MyStack
    {

        /** Initialize your data structure here. */

        Queue<int> queue1;
        Queue<int> queue2;
        int _top = 0;
        public MyStack()
        {
            queue1 = new Queue<int>();
            queue2 = new Queue<int>();
            _top = 0;
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            _top = x;
            queue1.Enqueue(x);
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {

            if (queue1.Count == 0) throw new Exception("Stack is empty");

            while (queue1.Count != 1)
            {
                //! assigning every time we are dequeuing to _top so latest pop will contain _top
                _top = queue1.Dequeue();
                queue2.Enqueue(_top);
            }

            int toReturn = queue1.Dequeue();
            
            //! We need to use temp queue here  before assigning value to queue2 becuase queue is a reference type            
            Queue<int> temp = queue1;
            queue1 = queue2;
            queue2 = temp;

            return toReturn;

        }
        /** Get the top element. */
        public int Top()
        {

            if (queue1.Count == 0) throw new Exception("Stack is empty");

            return _top;

        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {

            return queue1.Count == 0 ? true : false;
        }
    }



}
