using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAndIntervals
{
    public class TwoIntervalsOverlap
    {

        public static void TwoIntervalsOverlapTest()
        {
            //Non-overlapping
            int[] e1 = new int[] {6,10};
            int[] e2 = new int[] {1,6};
            TwoIntervalsOverlap test = new TwoIntervalsOverlap();
            var ans=test.IsOverLap(e1,e2);

            Console.ReadLine();
        }

        public bool IsOverLap(int[] e1, int[] e2)
        {
            int e1Start = e1[0];
            int e1End = e1[1];
            int e2Start = e2[0];
            int e2End = e2[1];

            return (e2Start <= e1End && e2Start >= e1Start) ||
                   (e1Start <= e2End && e1Start >= e2Start);
        }



    }
}
