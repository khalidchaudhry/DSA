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
            long lo = 0;
            long hi;
            hi = Sum(piles);
            while (lo + 1 < hi)
            {
                long mid = lo + (hi - lo) / 2;
                if (OK(piles, mid, H))
                {
                    hi = mid;
                }
                else
                {
                    lo = mid;
                }

            }
            return (int)hi;
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
        private long Sum(int[] piles)
        {
            long sum = 0;
            for (int i = 0; i < piles.Length; ++i)
            {
                sum += piles[i];
            }

            return sum;
        }


    }
}
