﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _56
    {

        /// <summary>
        //! Merge(Union) 
        /// </summary>
        public int[][] Merge0(int[][] intervals)
        {

            int n = intervals.Length;
            var comparer = Comparer<int[]>.Create((x, y) => {
               return x[0].CompareTo(y[0]);
            });

            Array.Sort(intervals, comparer);

            List<int[]> merged = new List<int[]>();

            foreach (int[] e2 in intervals)
            {
                int n2 = merged.Count;
                if (merged.Count == 0 || e2[0] > merged[n2 - 1][1])
                {
                    merged.Add(e2);
                }
                else
                {
                    merged[n2 - 1][1] = Math.Max(e2[1], merged[n2 - 1][1]);
                }
            }

            return merged.ToArray();
        }



        /// <summary>
        //https://www.youtube.com/watch?v=dI2FGXiL4Js 
        /// </summary>
        public int[][] Merge(int[][] intervals)
        {

            if (intervals.Length <= 1)
                return intervals;

            // https://stackoverflow.com/questions/36746218/sorting-jagged-array
            // ! sorting based on the first column of the jagged array 
            // todo: Research more on how to do sorting other than default. 
            // ! Compares two objects and returns a value indicating whether one is less than, equal to or greater than the other.
            //  Array.Sort(intervals,
            //      (x, y) =>
            //      {
            //          //return x[0] < y[0] ? -1 : (x[0] > y[0] ? 1 : 0);
            //          return x[0].CompareTo(y[0]);
            //      }
            //);

            Comparer<int[]> comparer = Comparer<int[]>.Create((x, y) =>
            {
                return x[0].CompareTo(y[0]);
            });

            Array.Sort(intervals, comparer);

            List<int[]> result = new List<int[]>();

            //!  inserted the first interval in the result set. 

            result.Add(intervals[0]);

            for (int i = 1; i < intervals.Length; ++i)
            {
                int[] e1 = result[result.Count - 1];
                int[] e2 = intervals[i];
                //! if intervals are overlapping, merge((union) them
                if (e2[0] <= e1[1])
                {
                    //! We need to select end from two intervals that ends last
                    result[result.Count - 1][1] = Math.Max(e1[1], e2[1]);
                }
                else
                {
                    result.Add(e2);
                }
            }

            return result.ToArray();
        }
    }
}
