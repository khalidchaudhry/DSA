using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module4
{
    public class TargetSum
    {


        public List<List<int>> TagetSumPassedVariable(int[] arr, int targetSum)
        {
            List<List<int>> results = new List<List<int>>();

            TagetSumPassedVariable(arr, 0, targetSum, new List<int>(), results);
            return results;

        }

        private void TagetSumPassedVariable(int[] arr, int i, int targetSum, List<int> path, List<List<int>> results)
        {
            if (targetSum < 0)
                return;

            if (targetSum == 0)
            {
                results.Add(new List<int>(path));
            }

            if (i == arr.Length)
                return;

            //! include 
            path.Add(arr[i]);
            TagetSumPassedVariable(arr, i, targetSum - arr[i], path, results);
            path.RemoveAt(path.Count - 1);
            //!exclude
            TagetSumPassedVariable(arr, i + 1, targetSum, path, results);
        }       
    }
}
