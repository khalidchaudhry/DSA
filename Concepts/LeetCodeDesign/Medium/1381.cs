using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDesign.Medium
{
    public class _1381
    {



    }
    /// <summary>
    //! Based on idea discussed in Kua's class
    /// </summary>
    public class CustomStack
    {
        List<int> _nums;
        List<int> _adjustments;
        int _count;
        int _maxSize;
        public CustomStack(int maxSize)
        {
            _nums = new List<int>();

            _adjustments = new List<int>();

            _count = 0;
            _maxSize = maxSize;

        }

        public void Push(int x)
        {
            if (_count == _maxSize)
                return;

            _nums.Add(x);
            _adjustments.Add(0);
            ++_count;
        }

        public int Pop()
        {
            if (_count == 0) return -1;
            int numsLastIndex = _nums.Count - 1;
            int adjustmentsLastIndex = _adjustments.Count - 1;
            int toReturn = _nums[numsLastIndex];
            toReturn += _adjustments[adjustmentsLastIndex];

            if (adjustmentsLastIndex != 0)
            {
                _adjustments[adjustmentsLastIndex - 1] += _adjustments[adjustmentsLastIndex];
            }

            _nums.RemoveAt(numsLastIndex);
            _adjustments.RemoveAt(numsLastIndex);
            --_count;

            return toReturn;
        }

        public void Increment(int k, int val)
        {
            if (_count == 0) return;

            if (k > _count)
            {
                int index = _adjustments.Count - 1;
                _adjustments[index] += val;
                return;
            }
            _adjustments[k - 1] += val;

        }
    }




    

    public class CustomStack3
    {
        Stack<int> _stk;
        int _count;
        int _capacity;

        public CustomStack3(int maxSize)
        {
            _stk = new Stack<int>();
            _count = 0;
            _capacity = maxSize;
        }

        public void Push(int x)
        {
            if (_stk.Count == _capacity)
            {
                return;
            }

            _stk.Push(x);
            ++_count;

        }

        public int Pop()
        {
            if (_stk.Count == 0)
            {
                return -1;
            }

            --_count;

            return _stk.Pop();


        }

        public void Increment(int k, int val)
        {
            Stack<int> temp = new Stack<int>();

            while (_stk.Count != 0)
            {
                temp.Push(_stk.Pop());
            }

            while (temp.Count != 0 && k >= 0)
            {
                _stk.Push(temp.Pop() + val);
                --k;
            }
            //! need to push rest of the elements into stack as well
            while (temp.Count != 0)
            {
                _stk.Push(temp.Pop());
            }

        }
    }
}
