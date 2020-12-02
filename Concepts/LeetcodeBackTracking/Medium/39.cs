﻿using System;
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
        /// https://leetcode.com/problems/combination-sum/discuss/16502/A-general-approach-to-backtracking-questions-in-Java-(Subsets-Permutations-Combination-Sum-Palindrome-Partitioning)
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum0(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            //! No sorting needed since no duplicates in the input. 
            //Array.Sort(candidates);
            CombinationSum0(candidates, 0, target, new List<int>(), result);

            return result;
        }

        private void CombinationSum0(int[] candidates, int i, int target, List<int> path, List<IList<int>> result)
        {
            if (target < 0) return;
            //! Below not needed
            //if (path.Count == candidates.Length && target != 0) return;
            if (target == 0)
            {
                result.Add(new List<int>(path));
                return;
            }

            for (int j = i; j < candidates.Length; ++j)
            {
                path.Add(candidates[j]);
                //! not  j+1  because we can reuse the same element 
                CombinationSum0(candidates, j, target - candidates[j], path, result);
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

        private void CombinationSum1(int[] candidates, int i, int target, List<int> path, List<IList<int>> result)
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
            if (i == candidates.Length) return;

            path.Add(candidates[i]);
            //! Key here is that when we include the item it does not prevent us from including it again. 
            //! by not incrementing i, we are staying at  same point in array so that we can include the item again
            CombinationSum1(candidates, i, target - candidates[i], path, result);
            path.RemoveAt(path.Count - 1);
            CombinationSum1(candidates, i + 1, target, path, result);
        }




        /// <summary>
        /// http://www.goodtecher.com/leetcode-39-combination-sum/
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            List<IList<int>> results = new List<IList<int>>();

            if (candidates.Length == 0)
            {
                return results;
            }

            Array.Sort(candidates);

            List<int> combinations = new List<int>();

            DFS(results, combinations, candidates, target, 0);

            return results;

        }

        private void DFS(List<IList<int>> results, List<int> combinations, int[] candidates, int target, int startIndex)
        {
            if (target == 0)
            {
                //! Deep copy of the combinations List<int>
                results.Add(new List<int>(combinations));
                return;
            }
            for (int i = startIndex; i < candidates.Length; i++)
            {
                if (candidates[i] > target)
                {
                    break;
                }
                combinations.Add(candidates[i]);
                DFS(results, combinations, candidates, target - candidates[i], i);
                //! Remove the last element from combintation as we are going to the next level 
                combinations.RemoveAt(combinations.Count - 1);
            }
        }
    }
}