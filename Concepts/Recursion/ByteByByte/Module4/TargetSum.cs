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

        public List<List<int>> TagetSumPassedVariable2(int[] arr, int targetSum)
        {
            List<List<int>> result = new List<List<int>>();

            TagetSumPassedVariable(arr, 0, targetSum, 0, new List<int>(), result);

            return result;

        }
        private void TagetSumPassedVariable(int[] arr, int i, int targetSum, int currentSum, List<int> path, List<List<int>> result)
        {
            if (currentSum > targetSum)
            {
                return;
            }

            if (i == arr.Length && currentSum != targetSum)
            {
                return;
            }
            //! The case where it where the current sum will be equal to the target sum
            if (i == arr.Length)
            {
                result.Add(new List<int>(path));
                return;
            }

            //! exclude current item
            TagetSumPassedVariable(arr, i + 1, targetSum, currentSum, path, result);

            path.Add(arr[i]);
            //! include current item
            TagetSumPassedVariable(arr, i + 1, targetSum, currentSum + arr[i], path, result);
            path.RemoveAt(path.Count - 1);

        }
    }
}
