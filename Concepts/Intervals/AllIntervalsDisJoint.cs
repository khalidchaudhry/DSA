using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAndIntervals
{
    public class AllIntervalsDisJoint
    {
        public static void AllIntervalsDisJointMain()
        {

        }

        public bool AllIntervalsDisjoint(int[][] intervals)
        {
            var comparer = Comparer<int[]>.Create((x, y) =>
            {
                return x[0].CompareTo(y[0]);
            });
            Array.Sort(intervals, comparer);

            for (int i = 0; i < intervals.Length - 1; ++i)
            {
                int[] e1 = intervals[i];
                int[] e2 = intervals[i + 1];
                if (IsOverLapping(e1, e2))
                    return false;

            }

            return true;

        }
        private bool IsOverLapping(int[] e1, int[] e2)
        {
            return (e2[0] <= e1[1] && e2[0] >= e1[0]) ||
                   (e1[0]<=e2[0] && e1[0]>=e2[0]);
        }




    }
}
