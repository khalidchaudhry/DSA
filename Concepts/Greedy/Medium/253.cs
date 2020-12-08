using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Greedy.Medium
{
    public class _253
    {
        public static void _253Main()
        {
            int[][] intervals = new int[3][] {
                new int[]{1,5 },
                new int[]{8,9 },
                new int[]{8,9 }

            };

            _253 MinRooms = new _253();

            var result = MinRooms.MinMeetingRooms1(intervals);

            Console.ReadLine();

        }
        /// <summary>
        /// https://leetcode.com/problems/meeting-rooms-ii/discuss/67855/Explanation-of-%22Super-Easy-Java-Solution-Beats-98.8%22-from-%40pinkfloyda
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int MinMeetingRooms0(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0) return 0;
            int n = intervals.Length, index = 0;
            int[] begins = new int[n];
            int[] ends = new int[n];
            foreach (int[] interval in intervals)
            {
                begins[index] = interval[0];
                ends[index] = interval[1];
                index++;
            }
            Array.Sort(begins);
            Array.Sort(ends);
            int rooms = 0, pre = 0;
            for (int i = 0; i < n; i++)
            {
                //!whenever there is a start meeting, we need to add one room
                rooms++;
                //! check to see if any previous meeting ends, which is why we check start with the first end. 
                //! When the start is bigger than end, it means at this time one of the previous meeting ends,
                //! and it can take and reuse that room.
                if (begins[i] >= ends[pre])
                {
                    rooms--;
                    pre++;
                }
            }
            return rooms;
        }
        /// <summary>
        /// https://www.youtube.com/watch?v=DFEf8_fjb_0
        /// https://leetcode.com/problems/meeting-rooms-ii/solution/
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int MinMeetingRooms1(int[][] intervals)
        {
            if (intervals.Length == 0)
                return 0;

            int[][] sortedIntervals = intervals.OrderBy(x => x[0]).ToArray();

            SortedSet<int> ss = new SortedSet<int>();
            ss.Add(sortedIntervals[0][1]);
            int result = 0;

            for (int i = 1; i < sortedIntervals.Length; ++i)
            {
                // If the room due to free up the earliest is free, assign that room to this meeting.
                if (sortedIntervals[i][0] >= ss.Min)
                {
                    ss.Remove(ss.Min);
                }
                // If a new room is to be assigned, then also we add to the heap,
                // If an old room is allocated, then also we have to add to the heap with updated end time
                //! if (ss.Contains(sortedIntervals[i][1])) ++result;  is to just case when endTime already exists in sortedSet
                if (ss.Contains(sortedIntervals[i][1])) ++result;
                ss.Add(sortedIntervals[i][1]);
            }

            return ss.Count + result;
        }

    }
}
