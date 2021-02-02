using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _979
    {
        int steps = 0;

        /// <summary>
        //! Intuition:  Every node needs to tell to its parent that either its  going to take the coin or give the coin
        //! 
        /// </summary>
        public int DistributeCoins(TreeNode root)
        {
            Helper(root);
            return steps;
        }
        private int Helper(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            int left = Helper(node.left);
            int right = Helper(node.right);

            steps += Math.Abs(left) + Math.Abs(right);

            return left + right + node.val - 1;
        }
    }
}
