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
                return 0;

            int lHeight = MinDepth(root.left);
            int rHeight = MinDepth(root.right);

            return Math.Min(lHeight, rHeight) + 1;

        }

        public int MinDepth2(TreeNode root)
        {
            if (root == null)
                return 0;

            int lHeight = MinDepth(root.left);
            int rHeight = MinDepth(root.right);

            return lHeight == 0 || rHeight == 0 ? lHeight + rHeight + 1: Math.Min(lHeight, rHeight) + 1;

        }

    }
}
