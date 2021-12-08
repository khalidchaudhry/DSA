using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _337
    {

        //! Time=O(n*2) n*2=possible recursion states
        //! Space=O(n*2) n*2=possible recursion states
        //! At every house we have 2 choices
        //! 1. Not rob(skip)
        //! 2.Rob in order for us to rob the node , parent should not be robbed.          
        public int Rob0(TreeNode root)
        {
            Dictionary<(TreeNode node, bool isParentRob), int> memo = new Dictionary<(TreeNode node, bool isParentRob), int>();
            return Solve(root, false, memo);
        }

        private int Solve(TreeNode node, bool isParentRob, Dictionary<(TreeNode node, bool isParentRob), int> memo)
        {
            if (node == null)
                return 0;

            int skip = Solve(node.left, false, memo) + Solve(node.right, false, memo);

            if (memo.ContainsKey((node, isParentRob)))
            {
                return memo[(node, isParentRob)];
            }
            int notSkipped = 0;
            if (!isParentRob)
            {
                notSkipped = node.val + Solve(node.left, true, memo) + Solve(node.right, true, memo);
            }
            return memo[(node, isParentRob)] = Math.Max(skip, notSkipped);
        }

        /// <summary>
        // TODO(not sure): Time=4^n branching factor=4 as at every node we can have 4 branches going from it
        //! Space=O(n)
        /// </summary>
        public int Rob1(TreeNode root)
        {
            return Solve1(root, false);
        }

        private int Solve1(TreeNode node, bool isParentRob)
        {
            if (node == null)
                return 0;

            int skip = Solve1(node.left, false) + Solve1(node.right, false);           
            int notSkipped = 0;
            if (!isParentRob)
            {
                notSkipped = node.val + Solve1(node.left, true) + Solve1(node.right, true);
            }
            return Math.Max(skip, notSkipped);
        }
    }
}
