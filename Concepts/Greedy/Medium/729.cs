using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Medium
{
    public class _729
    {
        //! Same pattern as in 731,732
        public class MyCalendar0
        {
            SortedDictionary<int, int> _intervalCount;
            public MyCalendar0()
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
                    if (sum > 1)
                    {
                        --_intervalCount[start];
                        ++_intervalCount[end];
                        return false;
                    }
                }

                return true;
            }
        }


        public class MyCalendar
        {

            List<(int s, int e)> _booking;
            public MyCalendar()
            {
                _booking = new List<(int s, int e)>();

            }

            public bool Book(int start, int end)
            {

                if (_booking.Count == 0)
                {
                    _booking.Add((start, end - 1));
                    return true;
                }

                foreach ((int prevStart, int prevEnd) in _booking)
                {
                    int s = Math.Max(start, prevStart);
                    int e = Math.Min(end - 1, prevEnd);
                    if (s <= e)
                        return false;
                }

                _booking.Add((start, end - 1));
                return true;
            }
        }

    }
}
