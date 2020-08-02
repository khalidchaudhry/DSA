using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBackTracking.Medium
{
    public class _78
    {

        /// <summary>
        /// https://leetcode.com/problems/combination-sum/discuss/16502/A-general-approach-to-backtracking-questions-in-Java-(Subsets-Permutations-Combination-Sum-Palindrome-Partitioning)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets0(int[] nums)
        {

            List<IList<int>> powerSet = new List<IList<int>>();
            Subset0(nums, 0, new List<int>(), powerSet);
            return powerSet;
        }

        private void Subset0(int[] nums, int i, List<int> path, List<IList<int>> powerSet)
        {
            powerSet.Add(new List<int>(path));

            for (int j = i; j < nums.Length; ++j)
            {
                path.Add(nums[j]);
                Subset0(nums, j + 1, path, powerSet);
                path.RemoveAt(path.Count - 1);
            }
        }
        //! Based on Sams byte by byte course
        public IList<IList<int>> Subsets1(int[] nums)
        {

            List<IList<int>> powerSet = new List<IList<int>>();
            Subset1(nums, 0, new List<int>(), powerSet);
            return powerSet;
        }

        /// <summary>
        /// https://www.youtube.com/watch?v=VdnvmfzA1pw
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets2(int[] nums)
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


        private void Subset1(int[] nums, int i, List<int> path, List<IList<int>> powerSet)
        {
            if (i == nums.Length)
            {
                // new List<int> to add new path
                powerSet.Add(new List<int>(path));
                return;
            }

            path.Add(nums[i]);
            //include the current item
            Subset1(nums, i + 1, path, powerSet);
            //exclude the current item
            path.RemoveAt(path.Count - 1);
            Subset1(nums, i + 1, path, powerSet);

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
