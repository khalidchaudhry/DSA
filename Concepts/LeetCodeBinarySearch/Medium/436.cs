using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    public class _436
    {
        public int[] FindRightInterval(int[][] intervals)
        {
            int n = intervals.Length;
            List<(int s, int e, int idx)> inter = new List<(int s, int e, int idx)>();
            for (int i = 0; i < n; ++i)
            {
                int start = intervals[i][0];
                int end = intervals[i][1];
                inter.Add((start, end, i));
            }
            inter.Sort();

            int[] rightIntervals = new int[n];
            for (int i = 0; i < inter.Count; ++i)
            {
                (int s, int e, int idx) = inter[i];
                int result = BinarySearch(i - 1, inter, e);
                rightIntervals[idx] = result;
            }

            return rightIntervals;
        }
        private int BinarySearch(int lo, List<(int s, int e, int idx)> inter, int target)
        {
            int hi = inter.Count - 1;
            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (OK(inter, mid, target))
                {
                    hi = mid;
                }
                else
                {
                    lo = mid;
                }
            }
            return inter[hi].s >= target ? inter[hi].idx : -1;
        }

        private bool OK(List<(int s, int e, int idx)> inter, int idx, int target)
        {
            return inter[idx].s >= target;
        }


    }
}
