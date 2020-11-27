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
            List<(int x, int y)> result = new List<(int x, int y)>();

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

            Comparer<int[]> comparer = Comparer<int[]>.Create((x, y) => {
                return x[0].CompareTo(y[0]);
            });

            Array.Sort(intervals, comparer);

            //!  inserted the first interval in the result set. 
            result.Add((intervals[0][0], intervals[0][1]));

            for (int i = 1; i < intervals.Length; ++i)
            {
                //! Gives last element index in the result set to compare it with currently processing element in the array 
                int lastElementIndex = result.Count - 1;
                // ! checking  only the first element of input with interval in the result set
                // input=[2,6]
                // result =[1,3]
                // 2>=1 and 2<=6 then merge 
                if (intervals[i][0] >= result[result.Count - 1].x && intervals[i][0] <= result[result.Count - 1].y)
                {
                    // merge intervals 
                    // last element's second index in result list will be overridden with the 
                    // maximum of (result last element's second index,interval array current iterating element second index
                    // ! You forgot Math.Max in first attempt and it failed for this input: [[1,4],[2,3]] 
                    //! only changing the ending index
                    ///int min = Math.Min(result[result.Count - 1].x, intervals[i][0]);
                    int max = Math.Max(result[result.Count - 1].y, intervals[i][1]);
                    result[result.Count - 1] = (result[lastElementIndex].x, max);
                }
                else
                {
                    result.Add((intervals[i][0], intervals[i][1]));
                }
            }

            int[][] ans = new int[result.Count][];
            int j = 0;
            foreach ((int x, int y) in result)
            {
                ans[j++] = new int[] { x, y };
            }

            return ans;
        }

    }
}
