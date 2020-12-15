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

            int left = MinDepth(root.left);
            int right = MinDepth(root.right);
            int length = 0;
            if (left == 0)
            {
                length = right;
            }
            else if (right == 0)
            {
                length = left;
            }
            else
            {
                length = Math.Min(left, right);
            }
            return 1 + length;
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
