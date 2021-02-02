using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _111
    {

        public int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftNodesCount = MinDepth(root.left);
            int rightNodesCount = MinDepth(root.right);

            leftNodesCount = leftNodesCount == 0 ? rightNodesCount : leftNodesCount;
            rightNodesCount = rightNodesCount == 0 ? leftNodesCount : rightNodesCount;


            return 1 + Math.Min(leftNodesCount, rightNodesCount);
        }



        public int MinDepth2(TreeNode root)
        {
            if (root == null)
                return 0;

            int lHeight = MinDepth2(root.left);
            int rHeight = MinDepth2(root.right);
            // the reason for  lHeight + rHeight + 1 rather than Math.Min is because if no node exist
            // than we don't consider it as min height

            return lHeight == 0 || rHeight == 0 ? lHeight + rHeight + 1 : Math.Min(lHeight, rHeight) + 1;

        }

    }
}
