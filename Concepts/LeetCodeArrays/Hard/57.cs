using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Hard
{
    public class _57
    {

        /// <summary>
        //! https://www.youtube.com/watch?v=dI2FGXiL4Js&t=343s 
        /// </summary>
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> result = new List<int[]>();
            int n = intervals.Length;

            int idx = 0;
            while (idx < n && intervals[idx][0] < newInterval[0])
            {
                result.Add(intervals[idx]);
                ++idx;
            }

            if (result.Count > 0 && IsOverLapping(result[result.Count - 1], newInterval))
            {
                result[result.Count - 1] = Merge(result[result.Count - 1], newInterval);
            }
            else
            {
                result.Add(newInterval);
            }

            while (idx < n)
            {
                int[] e1 = result[result.Count - 1];
                int[] e2 = intervals[idx];
                if (IsOverLapping(e1, e2))
                {
                    result[result.Count - 1] = Merge(e1, e2);
                }
                else
                {
                    result.Add(e2);
                }
                ++idx;
            }
            return result.ToArray();
        }

        private bool IsOverLapping(int[] e1, int[] e2)
        {
            return e2[0] <= e1[1] && e2[0] >= e1[0];
        }
        private int[] Merge(int[] e1, int[] e2)
        {
            int start = Math.Min(e1[0], e2[0]);
            int end = Math.Max(e1[1], e2[1]);
            return new int[] { start, end };
        }

    }
}
