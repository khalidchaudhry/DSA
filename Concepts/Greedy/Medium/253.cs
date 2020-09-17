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
        /// https://leetcode.com/problems/meeting-rooms-ii/solution/
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int MinMeetingRooms0(int[][] intervals)
        {
            if (intervals.Length == 0)
                return 0;

            int usedRooms = 0;

            int[] startTime = new int[intervals.Length];
            int[] endTime = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; ++i)
            {
                startTime[i] = intervals[i][0];
                endTime[i] = intervals[i][1];
            }

            Array.Sort(startTime);
            Array.Sort(endTime);

            int startTimePointer = 0;
            int endTimePointer = 0;

            while (startTimePointer < intervals.Length)
            {
                // If there is a meeting that has ended by the time the meeting at `start_pointer` starts
                if (startTime[startTimePointer] >= endTime[endTimePointer])
                {
                    --usedRooms;
                    ++endTimePointer;
                }
                // We do this irrespective of whether a room frees up or not.
                // If a room got free, then this used_rooms += 1 wouldn't have any effect. used_rooms would
                // remain the same in that case. If no room was free, then this would increase used_rooms
                ++startTimePointer;
                ++usedRooms;
            }

            return usedRooms;
        }
        /// <summary>
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

            return ss.Count+result;
        }

    }
}
