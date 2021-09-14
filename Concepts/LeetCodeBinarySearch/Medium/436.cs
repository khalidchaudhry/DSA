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
            List<Interval> intervalsLst = new List<Interval>();
            for (int i = 0; i < n; ++i)
            {
                int start = intervals[i][0];
                int end = intervals[i][1];
                intervalsLst.Add(new Interval(i, start, end));
            }
            intervalsLst = intervalsLst.OrderBy(x => x.Start).ToList();

            int[] result = new int[n];
            for (int i = 0; i < intervalsLst.Count; ++i)
            {
                int idx = intervalsLst[i].Index;
                int start = intervalsLst[i].Start;
                int end = intervalsLst[i].End;
                //! once we process the interval in list , we will do binary search from i since we already set previous i
                //! i essentially signifies from where we will do binary search
                int rightIntervalIdx = BinarySearch(intervalsLst, i, end);
                result[idx] = rightIntervalIdx;
            }
            return result;
        }
        private int BinarySearch(List<Interval> intervals, int startIdx, int target)
        {
            int lo = startIdx - 1; //! making lo invalid  
            int hi = intervals.Count - 1;
            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (OK(intervals, mid, target))
                {
                    hi = mid;
                }
                else
                {
                    lo = mid;
                }
            }
            //! returning interval index  for which  start >= target 
            return intervals[hi].Start >= target ? intervals[hi].Index : -1;
        }
        private bool OK(List<Interval> intervals, int mid, int target)
        {
            return intervals[mid].Start >= target;
        }
    }
    public class Interval
    {
        public int Index;
        public int Start;
        public int End;
        public Interval(int index, int start, int end)
        {
            Index = index;
            Start = start;
            End = end;
        }
    }

}
