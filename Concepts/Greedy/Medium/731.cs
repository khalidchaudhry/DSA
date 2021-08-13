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
        SortedDictionary<int, int> _eventCount;
        public MyCalendarTwo()
        {
            _eventCount = new SortedDictionary<int, int>();
        }

        public bool Book(int start, int end)
        {           

            if (!_eventCount.ContainsKey(start))
            {
                _eventCount.Add(start, 0);
            }
            ++_eventCount[start];


            if (!_eventCount.ContainsKey(end))
            {
                _eventCount.Add(end, 0);
            }
            --_eventCount[end];

            bool canBook = true;
            int max = 0;
            int sum = 0;
            foreach (var keyValue in _eventCount)
            {
                sum += keyValue.Value;
                max = Math.Max(sum, max);
                if (max >= 3)
                {
                    canBook = false;
                    Console.WriteLine("HJ");
                    break;
                }
            }

            if (!canBook)
            {
                --_eventCount[start];
                ++_eventCount[end];
            }

            return canBook;
        }
    }

}
