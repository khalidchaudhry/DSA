using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinarySearch.Medium
{
    public class _1235
    {
        public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            /* 
               1. Combine startTime,endTime and Profit in class . Create list from it
               2. Order by end time 
               3. Create dp array to store profit up to that point
               4. Do binary search to find interval that is not overlap
               5. Return dp[n-1]          
            */

            int n = startTime.Length;
            List<Job> jobs = new List<Job>();
            for (int i = 0; i < n; ++i)
            {
                jobs.Add(new Job(startTime[i], endTime[i], profit[i]));
            }

            //! We are sorting based on end time because we want previous event to finish before the current time
            var comparer = Comparer<Job>.Create((x, y) => {
                return x.EndTime.CompareTo(y.EndTime);
            });

            jobs.Sort(comparer);

            int[] dp = new int[n];

            for (int i = 0; i < n; ++i)
            {
                int currProfit = jobs[i].Profit;
                //! We will try to find out that what interval we can extend(if they are not overlapping)
                //! if not overlapping then idx !=-1
                int idx = BinarySearch(jobs, 0, i - 1, jobs[i].StartTime);
                if (idx != -1)
                {
                    currProfit += dp[idx];
                }

                dp[i] = i == 0 ? currProfit : Math.Max(currProfit, dp[i - 1]);
            }
            return dp[n - 1];
        }
        private int BinarySearch(List<Job> jobs, int lo, int hi, int startTime)
        {
            //making hi as invalid  
            ++hi;
            while (lo + 1 < hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (IsNonOverlap(jobs[mid], startTime))
                {
                    lo = mid;
                }
                else
                {
                    hi = mid;
                }
            }

            return startTime >= jobs[lo].EndTime ? lo : -1;

        }
        private bool IsNonOverlap(Job j, int startTime)
        {
            return startTime >= j.EndTime;
        }
    }
    public class Job
    {
        public int StartTime;
        public int EndTime;
        public int Profit;
        public Job(int startTime, int endTime, int profit)
        {
            StartTime = startTime;
            EndTime = endTime;
            Profit = profit;
        }
    }

}
