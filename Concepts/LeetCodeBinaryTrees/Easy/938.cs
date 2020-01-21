using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _938
    {
        public int RangeSumBST(TreeNode root, int L, int R)
        {
            int[] sum = new int[1];
            RangeSumSBSTHelper(root, L, R, sum);
            return sum[0];
        }
        public void RangeSumSBSTHelper(TreeNode node, int L, int R, int[] sum)
        {
            if (node == null)
                return;
            if (node.val >= L && node.val <= R)
            {
                sum[0] += node.val;
            }
            RangeSumSBSTHelper(node.left, L, R, sum);
            RangeSumSBSTHelper(node.right, L, R, sum);
        }

    }
}
