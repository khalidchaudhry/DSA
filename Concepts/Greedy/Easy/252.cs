using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Easy
{
    public class _252
    {
        public bool CanAttendMeetings(int[][] intervals)
        {

            var comparer = Comparer<int[]>.Create((x, y) => {
                //! As end always occur after start,we don't need to sort them using end time
                //! We will find overlapping. 
                return x[0].CompareTo(y[0]);
            });
            Array.Sort(intervals, comparer);

            int prev = 0;
            for (int i = 1; i < intervals.Length; ++i)
            {
                if (IsOverlap(intervals[prev], intervals[i]))
                {
                    return false;
                }
                prev = i;
            }

            return true;
        }
        private bool IsOverlap(int[] e1, int[] e2)
        {
            //!No need to check end time like below
            /*
                int max=Math.Max(e1[0],e2[0]);
                int min = Math.Min(e1[1], e2[1]);
                return max < min;
            */
            return e2[0] < e1[1];
        }
    }
}
