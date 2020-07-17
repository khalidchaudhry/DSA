using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _78
    {

        //! Based on Sams byte by byte course
        public IList<IList<int>> Subsets0(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            Subsets0(nums, 0, new List<int>(), result);

            return result;
        }

        private void Subsets0(int[] nums, int i, List<int> path, List<IList<int>> result)
        {
            if (i == nums.Length)
            {
                result.Add(new List<int>(path));
                return;
            }
            List<int> pathWithCurrent = new List<int>(path);
            pathWithCurrent.Add(nums[i]);
            //Include
            Subsets0(nums, i + 1, pathWithCurrent, result);
            //Exclude
            Subsets0(nums, i + 1, path, result);
        }

        /// <summary>
        /// https://www.youtube.com/watch?v=VdnvmfzA1pw
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets1(int[] nums)
        {
            List<IList<int>> results = new List<IList<int>>();

            if (nums == null || nums.Length == 0)
            {
                return results;
            }

            Array.Sort(nums);

            List<int> subset = new List<int>();
            ToFindAllSubsets(nums, results, subset, 0);

            return results;
        }

        private void ToFindAllSubsets(int[] nums, List<IList<int>> results, List<int> subset, int startIndex)
        {
            results.Add(new List<int>(subset));

            for (int i = startIndex; i < nums.Length; i++)
            {
                subset.Add(nums[i]);
                ToFindAllSubsets(nums, results, subset, i + 1);
                subset.RemoveAt(subset.Count - 1);
            }
        }

    }
}
