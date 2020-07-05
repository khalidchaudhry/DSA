using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _78
    {
        public IList<IList<int>> Subsets(int[] nums)
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
