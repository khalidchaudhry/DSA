using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Hard
{
    public class _124
    {


        /// <summary>
        //! Similar to leet code 687,543
        /// </summary>
        int maxPathSum;
        public int MaxPathSum(TreeNode root)
        {
            maxPathSum = int.MinValue;
            Helper(root);
            return maxPathSum;
        }

        private int Helper(TreeNode node)
        {
            if (node == null)
                return 0;

            int left = Math.Max(Helper(node.left), 0);
            int right = Math.Max(Helper(node.right), 0);

            maxPathSum = Math.Max(node.val + left + right, maxPathSum);

            return Math.Max(node.val, Math.Max(node.val + left, node.val + right));
        }


    }
}
