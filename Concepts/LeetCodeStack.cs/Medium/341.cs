using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStack.cs.Medium
{
    public class _341
    {


    }

    public class NestedIterator
    {
        private Stack<NestedInteger> _stk;
        public NestedIterator(IList<NestedInteger> nestedList)
        {
            _stk = new Stack<NestedInteger>();
            for (int i = nestedList.Count - 1; i >= 0; --i)
            {
                _stk.Push(nestedList[i]);
            }
        }

        public bool HasNext()
        {
            //! We are doing below code in hasNext rather than next as call pattern given in question is as below.
            //! If we do below code in next then it will fail for test case [[]]
            /*
               initialize iterator with nestedList
               res = []
               while iterator.hasNext()
                append iterator.next() to the end of res
              return res
            */
            while (_stk.Count > 0 && !_stk.Peek().IsInteger())
            {
                NestedInteger top = _stk.Pop();
                IList<NestedInteger> nestedList = top.GetList();
                for (int i = nestedList.Count - 1; i >= 0; --i)
                {
                    _stk.Push(nestedList[i]);
                }
            }
            return _stk.Count > 0;
        }

        public int Next()
        {

            return _stk.Pop().GetInteger();
        }
    }

    // This is the interface that allows for creating nested lists.
    // You should not implement it, or speculate about its implementation
    public interface NestedInteger
    {
        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        bool IsInteger();

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        int GetInteger();

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        IList<NestedInteger> GetList();
    }

}

