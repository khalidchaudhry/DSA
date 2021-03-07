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
        int _maxSum;
        public int MaxPathSum(TreeNode root)
        {
            _maxSum = int.MinValue;
            Helper(root);
            return _maxSum;
        }

        private int Helper(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int left = Helper(node.left);
            left = left < 0 ? 0 : left;
            int right = Helper(node.right);
            right = right < 0 ? 0 : right;
            _maxSum = Math.Max(_maxSum, node.val + left + right);
            return node.val + Math.Max(left, right);
        }


    }
}
