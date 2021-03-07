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
    //!Key idea: Visualize stack as list. It will give push and pop operation in O(1)  time. 
    //! Take aways
    //! Take away: Not to over think the problem initially.
    /// </summary>
    public class CustomStack
    {

        List<int> _list;
        int _capacity;
        int _size;
        public CustomStack(int maxSize)
        {
            _list = new List<int>();
            _capacity = maxSize;
            _size = 0;
        }

        public void Push(int x)
        {

            if (IsFull())
            {
                return;
            }
            _list.Add(x);
            ++_size;
        }

        public int Pop()
        {

            if (IsEmpty())
            {
                return -1;
            }
            int toReturn = _list[_size - 1];
            _list.RemoveAt(_size - 1);
            --_size;
            return toReturn;
        }

        public void Increment(int k, int val)
        {
            for (int i = 0; i < k && i < _size; ++i)
            {
                _list[i] = _list[i] + val;
            }

        }
        private bool IsEmpty()
        {
            return _size == 0;
        }
        private bool IsFull()
        {
            return _size == _capacity;
        }
    }

    /// <summary>    
    //! Based on idea discussed in Kua's class
    //! O(1) for all the operations
    //! Idea: Only  do increment  whenever someone pops it. 
    //!1  Whenever push, always  append 0 to Adjustments array
    //!2. When Increment go to the adjustment array corresponding index(K-1) and add increment value to it.
    //!3. When pops , if adjustment array!=0 then add the element to be return and add it previous adjustment element
    /// </summary>
    public class CustomStack1
    {
        List<int> _list;
        List<int> _adj;
        int _capacity;
        int _size;
        public CustomStack1(int maxSize)
        {
            _list = new List<int>();
            _adj = new List<int>();
            _capacity = maxSize;
            _size = 0;
        }

        public void Push(int x)
        {

            if (IsFull())
            {
                return;
            }
            _list.Add(x);
            _adj.Add(0);
            ++_size;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                return -1;
            }
            int toReturn = _list[_size - 1] + _adj[_size - 1];
            if (_size > 1)
            {
                _adj[_size - 2] += _adj[_size - 1];
            }

            _list.RemoveAt(_size - 1);
            _adj.RemoveAt(_size - 1);

            --_size;
            return toReturn;
        }

        public void Increment(int k, int val)
        {
            if (IsEmpty())
            {
                return;
            }

            if (k > _size)
            {
                _adj[_size - 1] += val;
            }
            else
            {
                _adj[k - 1] += val;
            }
        }
        private bool IsEmpty()
        {
            return _size == 0;
        }
        private bool IsFull()
        {
            return _size == _capacity;
        }
    }   
}
