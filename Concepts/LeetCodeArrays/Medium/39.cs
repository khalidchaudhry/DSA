﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeArrays.Medium
{
    public class _39
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
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
                combinations.RemoveAt(combinations.Count - 1);
            }
        }
    }
}
