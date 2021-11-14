using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Medium
{
    class _731
    {

        public static void  _731Main()
        {
            MyCalendarTwo two = new MyCalendarTwo();
            two.Book(27, 36);
            two.Book(27, 36);
            two.Book(23, 28);


        }

    }
    public class MyCalendarTwo
    {       
        SortedDictionary<int, int> _intervalCount;
        public MyCalendarTwo()
        {
            _intervalCount = new SortedDictionary<int, int>();
        }

        public bool Book(int start, int end)
        {

            if (!_intervalCount.ContainsKey(start))
            {
                _intervalCount.Add(start, 0);
            }
            ++_intervalCount[start];

            if (!_intervalCount.ContainsKey(end))
            {
                _intervalCount.Add(end, 0);
            }
            --_intervalCount[end];

            int sum = 0;
            foreach (var keyValue in _intervalCount)
            {
                sum += keyValue.Value;
                if (sum == 3)
                {
                    --_intervalCount[start];
                    ++_intervalCount[end];
                    return false;
                }
            }
            return true;

        }
    }

}
