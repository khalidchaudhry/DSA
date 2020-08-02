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
            var result = CombinationSum.CombinationSum2(candidates, target);

            Console.ReadLine();
        }
    
        /// <summary>
        /// https://leetcode.com/problems/combination-sum/discuss/16502/A-general-approach-to-backtracking-questions-in-Java-(Subsets-Permutations-Combination-Sum-Palindrome-Partitioning)
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            Array.Sort(candidates);
            CombinationSum2(candidates, 0, target, new List<int>(), result);

            return result;

        }

        private void CombinationSum2(int[] candidates, int i, int target, List<int> path, List<IList<int>> result)
        {
            if (target < 0)
                return;

            if (target == 0)
            {
                result.Add(new List<int>(path));
                return;
            }

            if (i == candidates.Length)
            {
                return;
            }

            for (int j = i; j < candidates.Length; ++j)
            {
                //! j>i not j>0 because we want to include duplicate once in path
                //! e.g. [1,2,2,2,5]  with j>0  it will skip [1,2,2] path with j>i it will include [1,2,2]
                if (j > i && candidates[j - 1] == candidates[j]) continue;
                path.Add(candidates[j]);
                CombinationSum2(candidates, j + 1, target - candidates[j], path, result);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
