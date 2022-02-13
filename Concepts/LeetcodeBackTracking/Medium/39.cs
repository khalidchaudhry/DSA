using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeBackTracking.Medium
{
    public class _39
    {


        public static void _39Main()
        {
            _39 CombinationSum = new _39();

            int[] candidates = new int[] { 2, 5, 3 };
            int target = 8;
            var result=CombinationSum.CombinationSum0(candidates,target);

            Console.ReadLine();
        }

        /// <summary>
        /// # <image url="https://raw.githubusercontent.com/aomine-sama/px/master/common/19022301.jpg"  scale="0.6"/>
        //   # <image url="$(SolutionDir)\Images\39.jpg"  scale="0.5"/>
        /// https://leetcode.com/problems/combination-sum/discuss/16502/A-general-approach-to-backtracking-questions-in-Java-(Subsets-Permutations-Combination-Sum-Palindrome-Partitioning)
       //! Unbounded Knapsack. We have unlimited supplies of numbers  
       /// </summary>
      
        public IList<IList<int>> CombinationSum0(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            
            CombinationSum0(candidates, 0, target, new List<int>(), result);

            return result;
        }

        private void CombinationSum0(int[] candidates, int start, int target, List<int> path, List<IList<int>> result)
        {
            //!BackTrack if target falls below 0
            if (target < 0) return;         
            if (target == 0)
            {
                result.Add(new List<int>(path));
                return;
            }

            for (int i = start; i < candidates.Length; ++i)
            {
                path.Add(candidates[i]);
                //! not  i+1  because we can reuse the same element(unbounded Knapsack. Unlimited supply) 
                CombinationSum0(candidates, i, target - candidates[i], path, result);
                path.RemoveAt(path.Count - 1);
            }
        }

        //! From byte by byte
        /**********************************************************************************/
        // ! Time complexity=branching_factor ^ depth of recursion * work per recursive call
        //! branching_factor=2
        //! depth of the recursion=O(target)
        //! work per recursive call=0(n) because we have to add it to the result
        //! Time complexity=2^target*n
        /**********************************************************************************/
        //! Space complexity=depth of recursion* space per recursive call
        // !depth of the recursion=O(target)
        //! Space per recursive call=none as we are not saving any extra stuff
        //! Space complexity=O(target)
        /**********************************************************************************/
        public IList<IList<int>> CombinationSum1(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();

            List<int> combinations = new List<int>();
            //! instead of having runningSum , we are descrementing the target
            CombinationSum1(candidates, 0, target, new List<int>(), result);

            return result;

        }

        private void CombinationSum1(int[] candidates, int start, int target, List<int> path, List<IList<int>> result)
        {
            //! Combination sum has exceeded the target sum  
            if (target < 0) return;
            //! Valid combination .. Add it to the path
            if (target == 0)
            {
                result.Add(new List<int>(path));
                return;
            }
            //! if we reach end of array return as we don't find the combination that is equal to the target sum 
            if (start == candidates.Length) return;

            path.Add(candidates[start]);
            //! Key here is that when we include the item it does not prevent us from including it again. 
            //! by not incrementing i, we are staying at  same point in array so that we can include the item again
            CombinationSum1(candidates, start, target - candidates[start], path, result);//include
            path.RemoveAt(path.Count - 1);
            CombinationSum1(candidates, start + 1, target, path, result);  //not include
        }       
    }
}
