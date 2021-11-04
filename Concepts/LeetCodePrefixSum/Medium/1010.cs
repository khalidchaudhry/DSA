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
        //! (time[i] + time[j]) % 60==0
        //! time[i]%60 +time[j]%60=60
        //! time[j]%60=60-time[i]%60
        //! time[j]=(60-time[i]%60)%60  
        //! time[j]=(60-t1)%60
        //! 
        //! 
        /// </summary>
        public int NumPairsDivisibleBy60(int[] time)
        {

            Dictionary<int, int> timeRemainder = new Dictionary<int, int>();

            int totalPairs = 0;
            foreach (int t in time)
            {
                int t1 = t % 60;
                int t2 = (60 - t1) % 60;
                if (timeRemainder.ContainsKey(t2))
                {
                    totalPairs += timeRemainder[t2];
                }
                if (!timeRemainder.ContainsKey(t1))
                    timeRemainder.Add(t1, 0);

                ++timeRemainder[t1];
            }

            return totalPairs;

        }


    }
}
