using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    class _1482
    {
        /// <summary>
        //! Based on template from Roger 
        /// </summary>
        public int MinDays(int[] bloomDay, int m, int k)
        {
            if (m * k > bloomDay.Length)
                return -1;

            int lo = 0;
            int hi = bloomDay.Max();

            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (OK(bloomDay, mid, m, k))
                    hi = mid;
                else
                    lo = mid;
            }
            return hi;
        }
        /// <summary>
        //!FFFFF'T'TTTT
        //! Can we make at least 'm' bouquets with k flowers  in 'mid' days
        /// </summary>
        private bool OK(int[] bloomDay, int day, int m, int k)
        {
            int flowers = 0;
            int boquets = 0;

            for (int i = 0; i < bloomDay.Length; ++i)
            {
                if (bloomDay[i] <= day)
                    ++flowers; //!index of bloomDay array represents the flower number hence incrementing flowers count
                else //! incase bloom day > provided day, reset flowers as we need to pick up adjacent flowers
                    flowers = 0;

                if (flowers == k)
                {
                    ++boquets;
                    flowers = 0;
                }                
            }
            //! We need to make atleast m . If we make more we are still good hence >=m
            return boquets>=m;
        }       
    }
}
