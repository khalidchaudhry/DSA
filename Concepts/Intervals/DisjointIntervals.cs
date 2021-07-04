using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAndIntervals
{
    public class DisjointIntervals
    {
        public static void DisjointIntervalsMain()
        {
            int[][] jobs = new int[][]
            {
                new int[]{10,12},
                new int[]{3,7},
                new int[]{1,2}
            };
            int[] job = new int[] {30,40 };

            var test = new DisjointIntervals();
            var ans=test.DisJoint(jobs,job);
            Console.ReadLine();

        }

        public bool DisJoint(int[][] intervals, int[] newInterval)
        {
            var comparer = Comparer<int[]>.Create((x, y) =>
            {
                return x[0].CompareTo(y[0]);
            });
            Array.Sort(intervals, comparer);

            int lo = 0;
            int hi = intervals.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int[] e1 = intervals[mid];
                if (IsOverLapping(e1, newInterval))
                {
                    return true;
                }
                else if (e1[0] > newInterval[0])
                {
                    hi = mid-1;
                }
                else
                {
                    lo = mid+1;
                }
            }

            return false;
        }
        private bool IsOverLapping(int[] e1, int[] e2)
        {
            return e2[0] <= e1[1] && e2[0] >= e1[0];
        }
    }
}
