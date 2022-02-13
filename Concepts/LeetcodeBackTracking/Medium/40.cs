using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeBackTracking.Medium
{
    public class _40
    {

        public static void _40Main()
        {
            int[] candidates = new int[] { 2, 5, 2, 1, 2 };
            Array.Sort(candidates);
            int target = 5;
            _40 CombinationSum = new _40();
            var result = CombinationSum.CombinationSum(candidates, target);

            Console.ReadLine();
        }

        /// <summary>
        //! Time Complexity=2^n where n are number candidates. Why 2^n because we can have 2^n possible subsets from n numbers
        //! Space=O(min(n,target)) since the min(n,target)is max depth of the recursion 
        //! Bounded Knapsack
        //! This problem  combines the  technique used in problem 90 to handle with duplicates & 
        //! problem 39 to reach the target
        /// https://leetcode.com/problems/combination-sum/discuss/16502/A-general-approach-to-backtracking-questions-in-Java-(Subsets-Permutations-Combination-Sum-Palindrome-Partitioning)
        /// </summary>       
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            Array.Sort(candidates);
            CombinationSum(candidates, 0, target, new List<int>(), result);

            return result;

        }

        private void CombinationSum(int[] candidates, int start, int target, List<int> path, List<IList<int>> result)
        {

            if (target == 0)
            {
                result.Add(new List<int>(path));
                return;
            }
            //! This condition needs tobe after above condition because in case of last element equal to target 
            //! it will not add it to the result
            //! e.g candidates = [1,2,2,5], target = 5
            //! BackTrack
            if (target < 0 || start >= candidates.Length)
            {
                return;
            }

            for (int i = start; i < candidates.Length; ++i)
            {
                //! Bounded knapsack because we can use item only once
                //! j>i not j>0 because we want to include duplicate once in path
                //! e.g. [1,2,2,2,5]  with j>0  it will skip [1,2,2] path with j>i it will include [1,2,2]
                if (i > start && candidates[i - 1] == candidates[i]) continue;
                path.Add(candidates[i]);
                //! Bounded knapsack because we can use item only once hence we are incrementing i(i+1)
                CombinationSum(candidates, i + 1, target - candidates[i], path, result);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
