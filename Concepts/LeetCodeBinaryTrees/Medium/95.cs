using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _95
    {
        /// <summary>
        //! Same as 241
        //! With memoization 
        //! Time complexity=n^5 
        //!==> Our possible recursive function states are n^2 and we are performing n^3 units of work in each recursive call hence total time complexity=O(n^5)
        //! Space Complexity =O(n) for recusrion depth & O(2^n) for result
        /// </summary>
        public IList<TreeNode> GenerateTrees0(int n)
        {
            Dictionary<(int, int), List<TreeNode>> memo = new Dictionary<(int, int), List<TreeNode>>();
            return GenerateTrees0(1, n, memo);  
        }
        private List<TreeNode> GenerateTrees0(int s, int e, Dictionary<(int, int), List<TreeNode>> memo)  //! s and e possible states are N^2
        {
            if (s > e)
            {
                return new List<TreeNode>() { null };
            }
            if (memo.ContainsKey((s, e)))
            {
                return memo[(s, e)];
            }

            List<TreeNode> result = new List<TreeNode>();
            for (int i = s; i <= e; ++i)  //!O(N)
            {
                List<TreeNode> leftTrees = GenerateTrees0(s, i - 1, memo);
                List<TreeNode> rightTrees = GenerateTrees0(i + 1, e, memo);
                //!O(N^2)
                foreach (TreeNode l in leftTrees)
                {
                    foreach (TreeNode r in rightTrees)
                    {
                        TreeNode root = new TreeNode(i);
                        root.left = l;
                        root.right = r;
                        result.Add(root);
                    }
                }                
            }

            memo[(s, e)] = result;
            return memo[(s, e)];
        }


        //! Brute Force 
        //!Time Complexity=2^n * n
        public IList<TreeNode> GenerateTrees(int n)
        {

            return GenerateTrees(1, n);
        }
        private List<TreeNode> GenerateTrees(int s, int e)
        {
            if (s > e)
            {
                return new List<TreeNode>() { null };
            }

            List<TreeNode> result = new List<TreeNode>();
            for (int i = s; i <= e; ++i)
            {
                List<TreeNode> leftTrees = GenerateTrees(s, i - 1);
                List<TreeNode> rightTrees = GenerateTrees(i + 1, e);
                List<TreeNode> combs = GenerateCombinations(i, leftTrees, rightTrees);
                result.AddRange(combs);
            }
            return result;
        }
        private List<TreeNode> GenerateCombinations(int rootNodeVal, List<TreeNode> leftTrees, List<TreeNode> rightTrees)
        {
            List<TreeNode> result = new List<TreeNode>();
            foreach (TreeNode l in leftTrees)
            {
                foreach (TreeNode r in rightTrees)
                {
                    TreeNode root = new TreeNode(rootNodeVal);
                    root.left = l;
                    root.right = r;
                    result.Add(root);
                }
            }

            return result;
        }

    }
}
