using System;
using System.Collections.Generic;

namespace LeetcodeBackTracking.Medium
{
    public class _77
    {

        public static void _77Main()
        {

            _77 Combintions = new _77();
            var result = Combintions.Combine(4, 2);

            Console.ReadLine();

        }
        /// <summary>
        /// https://leetcode.com/problems/combination-sum/discuss/16502/A-general-approach-to-backtracking-questions-in-Java-(Subsets-Permutations-Combination-Sum-Palindrome-Partitioning)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine0(int n, int k)
        {
            List<IList<int>> result = new List<IList<int>>();
            int[] nums = new int[n];
            for (int i = 0; i < n; ++i)
                nums[i] = i + 1;

            Combine0(nums, 0, k, new List<int>(), result);
            return result;
        }
        private void Combine0(int[] nums, int start, int k, List<int> path, IList<IList<int>> result)
        {
            if (path.Count == k)
            {
                result.Add(new List<int>(path));
                return;
            }
            if (path.Count > k)
            {
                return;
            }

            for (int i = start; i < nums.Length; ++i)
            {
                path.Add(nums[i]);
                Combine0(nums, i + 1, k, path, result);
                path.RemoveAt(path.Count - 1);
            }
        }

        /// <summary>
        //! Approach followed in sam byte by byte course. 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine(int n, int k)
        {
            List<IList<int>> result = new List<IList<int>>();

            if (k > n || n == 0)
                return result;

            int[] nums = new int[n];
            for (int i = 0; i < n; ++i)
            {
                nums[i] = i + 1;
            }

            Combine(nums, 0, k, new List<int>(), result);

            return result;
        }       

        private void Combine(int[] nums, int i, int k, List<int> path, List<IList<int>> result)
        {
            if (path.Count > k) return;
            if (i == nums.Length && path.Count != k) return;
            if (path.Count == k)
            {
                result.Add(new List<int>(path));
                return;
            }
            //include
            path.Add(nums[i]);
            Combine(nums, i + 1, k, path, result);
            path.RemoveAt(path.Count - 1);
            //exclude
            Combine(nums, i + 1, k, path, result);
        }
    }
}
