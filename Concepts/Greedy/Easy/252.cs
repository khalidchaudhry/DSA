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
            return e2[0] < e1[1];
        }
    }
}
