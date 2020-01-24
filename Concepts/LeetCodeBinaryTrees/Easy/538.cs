using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _538
    {
        int sum = 0;
        public TreeNode ConvertBST(TreeNode root)
        {
            if (root != null)
            {
                ConvertBST(root.right);
                sum += root.val;
                root.val = sum;
                ConvertBST(root.left);
            }

            return root;
        }
    }
}
