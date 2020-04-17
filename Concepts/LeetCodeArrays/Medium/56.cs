using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _56
    {

        public int[][] Merge(int[][] intervals)
        {

            if (intervals.Length <= 1)
                return intervals;
            List<int[]> result = new List<int[]>();

            // https://stackoverflow.com/questions/36746218/sorting-jagged-array
            // ! sorting based on the first column of the jagged array 
            // todo: Research more on how to do sorting other than default. 
            // ! Compares two objects and returns a value indicating whether one is less than, equal to or greater than the other.
            Array.Sort(intervals,
                (x, y) =>
                {
                    return x[0] < y[0] ? -1 : (x[0] > y[0] ? 1 : 0);
                }

          );

            result.Add(new int[] { intervals[0][0], intervals[0][1] });

            for (int i = 1; i < intervals.GetLength(0); i++)
            {
                int lastElement = result.Count - 1;
                if (intervals[i][0] >= result[lastElement][0] && intervals[i][0] <= result[lastElement][1])
                {
                    // merge intervals 
                    // last element's second index in result list will be overridden with the 
                    // maximum of (result last element's second index,interval array current iterating element second index
                    // ! You forgot Math.Max in first attempt and it failed for this input: [[1,4],[2,3]] 

                    result[lastElement][1] = Math.Max(intervals[i][1], result[lastElement][1]);
                }
                else
                {
                    result.Add(new int[] { intervals[i][0], intervals[i][1] });
                }
            }

            return result.ToArray();
        }

    }
}
