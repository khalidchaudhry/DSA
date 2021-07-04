using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePrefixSum.Medium
{
    public class _1010
    {
        /// <summary>
        //! (t1+t2)%60=0
        //! t1%60+t2%60=60
        //! t2=(60-t1%60)%60
        /// </summary>
        public int NumPairsDivisibleBy60(int[] time)
        {

            Dictionary<int, int> timeRemainder = new Dictionary<int, int>();

            int totalPairs = 0;
            foreach (int t in time)
            {
                int r1 = t % 60;
                int r2 = (60 - r1) % 60;
                if (timeRemainder.ContainsKey(r2))
                {
                    totalPairs += timeRemainder[r2];
                }
                if (!timeRemainder.ContainsKey(r1))
                    timeRemainder.Add(r1, 0);

                ++timeRemainder[r1];
            }

            return totalPairs;

        }


    }
}
