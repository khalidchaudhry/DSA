using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Greedy.Hard
{
    public class _759
    {

        public IList<Interval> EmployeeFreeTime(IList<IList<Interval>> schedule)
        {
            /*
               1. Combine all the schedules and have one list<Interval>
               2. Sort them based on the start time
               3. Iterate the schedule and check if two adjacent intervals overlapping or not 
               4.     if(overlapping)
                          we will drop the one ending earlier
                      else
                          Add end of first interval as start and 
                              start-1 of second inerval as end
               5. Return the interval                
            */

            List<Interval> allIntervals = new List<Interval>();
            foreach (IList<Interval> intervals in schedule)
            {
                foreach (Interval interval in intervals)
                {
                    allIntervals.Add(new Interval(interval.start, interval.end));
                }
            }
            allIntervals = allIntervals.OrderBy(x => x.start).ToList();

            IList<Interval> free = new List<Interval>();

            Interval prev = allIntervals[0];
            for (int i = 1; i < allIntervals.Count; ++i)
            {
                Interval curr = allIntervals[i];
                if (IsOverlap(prev, curr))
                {
                    if (curr.end > prev.end)
                    {
                        prev = curr;
                    }
                }
                else
                {
                    int start = prev.end;
                    int end = curr.start;
                    Interval newInterval = new Interval(start, end);
                    free.Add(newInterval);
                    prev = curr;
                }
            }

            return free;
        }

        private bool IsOverlap(Interval e1, Interval e2)
        {
            return e2.start <= e1.end;
        }
    }

    // Definition for an Interval.
    public class Interval
    {
        public int start;
        public int end;

        public Interval() { }
        public Interval(int _start, int _end)
        {
            start = _start;
            end = _end;
        }
    }

}

