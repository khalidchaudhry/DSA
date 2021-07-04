using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Medium
{
    public class _1272
    {
        public IList<IList<int>> RemoveInterval(int[][] intervals, int[] toBeRemoved)
        {
            List<IList<int>> result = new List<IList<int>>();
            foreach (int[] interval in intervals)
            {
                int[] e1 = interval;
                int[] e2 = toBeRemoved;

                if (IsOverlap(e1, e2))
                {
                    //! Since requreiement is to have result in sorted order
                    if (e1[0] < e2[0])
                    {
                        result.Add(new List<int>() { e1[0], e2[0] });
                    }

                    if (e1[1] > e2[1])
                    {
                        result.Add(new List<int>() { e2[1], e1[1] });
                    }
                }
                else
                {
                    result.Add(new List<int>() { e1[0], e1[1] });
                }
            }

            return result;

        }
        private bool IsOverlap(int[] e1, int[] e2)
        {
            int start = Math.Max(e1[0], e2[0]);
            int end = Math.Min(e1[1], e2[1]);
            return start < end;
        }


    }
}
