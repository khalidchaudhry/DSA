using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeStrings.Medium
{
    public class _539
    {
        /// <summary>
        /// https://leetcode.com/problems/minimum-time-difference/discuss/474787/Python3-O(nlogn)-time-with-detailed-explanation-%3A)
        /// // # <image url="https://assets.leetcode.com/users/shadio/image_1578536753.png" scale="0.5" />  
        /// </summary>
        /// <param name="timePoints"></param>
        /// <returns></returns>
        public int FindMinDifference(IList<string> timePoints)
        {
            List<int> timePointsInMinutes = new List<int>();

            foreach (string timePoint in timePoints)
            {
                string[] HourMinute = timePoint.Split(":");
                int hour = int.Parse(HourMinute[0]);
                int minute = int.Parse(HourMinute[1]);
                //! converting the time(hour and minute) into minutes
                timePointsInMinutes.Add(60 * hour + minute);
            }

            timePointsInMinutes.Sort();

            int minDiff = int.MaxValue;
            for (int i = 0; i < timePointsInMinutes.Count - 1; ++i)
            {
                minDiff = Math.Min(minDiff, Math.Abs(timePointsInMinutes[i] - timePointsInMinutes[i + 1]));
                               
            }
            //! this is the case of circular algorithm  where we need to consider last to first element difference                                  
            int lastPointDiff = 24 * 60 - timePointsInMinutes[timePointsInMinutes.Count - 1] + timePointsInMinutes[0];

            minDiff = Math.Min(minDiff, lastPointDiff);
            return minDiff;
        }


    }
}
