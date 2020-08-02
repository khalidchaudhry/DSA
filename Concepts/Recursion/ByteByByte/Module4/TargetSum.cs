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
            //! not incrementing i because we want to check if sums of alll current array elements equal to the target  
            TagetSumPassedVariable(arr, i, targetSum - arr[i], path, results);
            //!exclude
            path.RemoveAt(path.Count - 1);                      
            //! Not reducing target sum because we need to try current sum with next elements  in an array 
            //e.g. [2,1,7] for target=7 we need to test [2,2,2,1] 
            TagetSumPassedVariable(arr, i + 1, targetSum, path, results);
        }       
    }
}
