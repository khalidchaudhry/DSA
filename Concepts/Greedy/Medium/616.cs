using System;
using System.Collections.Generic;
using System.Text;

namespace Greedy.Medium
{
    public class _616
    {
        public string AddBoldTag(string s, string[] words)
        {
            /*

               abcabc123
               words=["abc","123"]
               [0,2][3,5] [6,8]
               [0,8]

            */

            List<Interval> intervals = new List<Interval>();
            foreach (string word in words)
            {
                int idx = s.IndexOf(word);
                int end = word.Length - 1;
                //! What if word repeats multiple times in given string
                while (idx != -1)
                {
                    intervals.Add(new Interval(idx, idx + end));
                    idx = s.IndexOf(word, idx + 1);
                }
            }
            var comparer = Comparer<Interval>.Create((x, y) => {
                return x.Start.CompareTo(y.Start);
            });

            intervals.Sort(comparer);

            List<Interval> mergedIntervals = new List<Interval>();

            for (int i = 0; i < intervals.Count; ++i)
            {
                if (i == 0)
                {
                    mergedIntervals.Add(intervals[0]);
                    continue;
                }
                int s1 = mergedIntervals[mergedIntervals.Count - 1].Start;
                int e1 = mergedIntervals[mergedIntervals.Count - 1].End;
                int s2 = intervals[i].Start;
                int e2 = intervals[i].End;

                if (s2 <= e1 + 1)
                {
                    mergedIntervals[mergedIntervals.Count - 1].End = Math.Max(e1, e2);
                }
                else
                {
                    mergedIntervals.Add(new Interval(s2, e2));
                }
            }

            StringBuilder result = new StringBuilder();
            int prev = 0;
            foreach (Interval interval in mergedIntervals)
            {
                int start = interval.Start;
                int end = interval.End;
                //!  Start-prev derivation
                //!  j-i+1
                //! start-1-pre+1=start-prev  
                string pre = s.Substring(prev, start - prev);
                result.Append(pre);
                result.Append("<b>");
                result.Append(s.Substring(start, end - start + 1));
                result.Append("</b>");
                prev = end + 1;
            }
            //! To ensure that if something left, add it 
            result.Append(s.Substring(prev));

            return result.ToString();

        }


    }

    public class Interval
    {
        public int Start { get; set; }
        public int End { get; set; }
        public Interval(int start, int end)
        {
            Start = start;
            End = end;
        }
    }
}
