using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _337
    {
        public int Rob(TreeNode root)
        {

            int[] choices=Helper(root);
            return Math.Max(choices[0],choices[1]);

        }

        public int[] Helper(TreeNode node)
        {
            if (node == null)
                return new int[] { 0, 0 };

            int[] left = Helper(node.left);
            int[] right = Helper(node.right);
            //if we rob the parent then we can't rob its children 
            var parentRobbed = node.val + left[1] + right[1];

            var parentNotRobbed = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);

            return new int[] { parentRobbed, parentNotRobbed };
        }

    }
}
