using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Easy
{
    public class _1200
    {
        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {

            Array.Sort(arr);

            int[] diff = new int[arr.Length - 1];
            int minDiff = int.MaxValue;

            List<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                diff[i] = Math.Abs(arr[i] - arr[i + 1]);
                minDiff = Math.Min(minDiff, diff[i]);
            }

            for (int i = 0; i < diff.Length; ++i)
            {
                if (diff[i] == minDiff)
                {
                    List<int> pair = new List<int>();
                    pair.Add(arr[i]);
                    pair.Add(arr[i + 1]);
                    result.Add(pair);
                }
            }
            return result;
        }


    }
}
