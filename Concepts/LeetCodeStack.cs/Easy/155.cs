using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.Easy
{

    /// <summary>
    //! This approach actually avoid pushing duplicates in the stack
    /// </summary>
    public class MinStack0
    {

        /** initialize your data structure here. */
        Stack<int> _stack;
        Stack<(int item, int count)> _minStack;
        public MinStack0()
        {

            _stack = new Stack<int>();
            _minStack = new Stack<(int item, int count)>();

        }

        public void Push(int x)
        {
            _stack.Push(x);
            if (_minStack.Count == 0 || x < _minStack.Peek().item)
            {
                _minStack.Push((x, 1));
                return;
            }
            if (x == _minStack.Peek().item)
            {
                (int item, int count) = _minStack.Pop();
                _minStack.Push((item, ++count));
            }

        }
        /// <summary>
        //! In real interview , make sure that you ask interviewer , what should we return in case stack is empty. Good practice is to raise an excpetion 
        /// </summary>
        public void Pop()
        {
            int item = _stack.Pop();
            (int minItem, int minItemCount) = _minStack.Peek();
            if (item == minItem)
            {
                (minItem, minItemCount) = _minStack.Pop();
                --minItemCount;
                if (minItemCount > 0)
                {
                    _minStack.Push((minItem, minItemCount));
                }
            }

        }

        public int Top()
        {
            return _stack.Peek();
        }

        public int GetMin()
        {
            return _minStack.Peek().item;
        }
    }

    /// <summary>
    //! We keep pushing if current element is less than or equal to stack top
    //! Its is monotonically descreasing stack
    //! we only push if element is <=element on peak of stack
    /// </summary>
    public class MinStack
    {

        /** initialize your data structure here. */
        Stack<int> _stack;
        Stack<int> _minStack;
        public MinStack()
        {

            _stack = new Stack<int>();
            _minStack = new Stack<int>();

        }

        public void Push(int x)
        {
            _stack.Push(x);
            //!Incase of equal we also need to push
            if (_minStack.Count == 0 || x <= _minStack.Peek())
            {
                _minStack.Push(x);
            }

        }
        /// <summary>
        //! In real interview , make sure that you ask interviewer , what should we return in case stack is empty. Good practice is to raise an excpetion 
        /// </summary>
        public void Pop()
        {
            int poppedItem = _stack.Pop();
            if (poppedItem == _minStack.Peek())
            {
                _minStack.Pop();
            }

        }

        public int Top()
        {
            return _stack.Peek();
        }

        public int GetMin()
        {
            return _minStack.Peek();
        }
    }


    public class MinStack2
    {

        /** initialize your data structure here. */
        Stack<int> MainStk;
        Stack<int> MinStk;
        public MinStack2()
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
