using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    public class _875
    {

        public int MinEatingSpeed(int[] piles, int H)
        {
            int lo = 0;  //! invalid candidate
            int hi = piles.Max();  //!  with Max values in piles kuko can definitely eat all bananas // Valid candidate
            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (OK(piles, mid, H))
                {
                    hi = mid;
                }
                else
                {
                    lo = mid;
                }

            }
            return hi;
        }


        /// <summary>
        //! Can Koko eat all bananas in H hours with speed of eating <<bananas(mid)>>/hr
        // !FFFF'T'TTTTT
        ///</summary>
        private bool OK(int[] piles, long speed, int H)
        {
            if (speed == 0) return false;

            long timeTaken = 0;
            foreach (int pile in piles)
            {
                timeTaken += (long)Math.Ceiling((decimal)pile / speed);
            }

            return timeTaken <= H;
        }
    }
}
