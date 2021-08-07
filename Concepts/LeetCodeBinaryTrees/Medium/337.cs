using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _337
    {

        /// <summary>
        //! At every house we have 2 choices
        //! 1. Not rob(skip)
        //! 2.Rob in order for us to rob the node , parent should not be robbed.          
        /// </summary>
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
    }
}
