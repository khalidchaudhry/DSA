using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greedy.Medium
{
    public class _435
    {
        public int EraseOverlapIntervals(int[][] intervals)
        {

            intervals = intervals.OrderBy(x => x[0]).ToArray();
            int[] e1 = intervals[0];

            int intervalsToDrop = 0;
            for (int i = 1; i < intervals.Length; ++i)
            {
                int[] e2 = intervals[i];

                if (IsOverLap(e1, e2))
                {
                    ++intervalsToDrop;
                    //!We will drop an event which is ending last since it will give us the max benefit because it may overlap with other events comming later 
                    if (e2[1] < e1[1])
                    {
                        e1 = e2;
                    }
                }
                else
                {
                    e1 = e2;
                }
            }

            return intervalsToDrop;

        }
        private bool IsOverLap(int[] e1, int[] e2)
        {
            return e2[0] < e1[1];
        }


    }
}
