using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _222
    {
        int count = 0;
        public int CountNodes(TreeNode root)
        {
            Helper(root);

            return count;
        }

        private void Helper(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            count += 1;

            Helper(root.left);

            Helper(root.right);

        }

    }
}
