using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _700
    {
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
                return null;
            else if (root.val > val)
                return SearchBST(root.left, val);
            else if (root.val < val)
                return SearchBST(root.right, val);
            else
                return root;
        }

    }
}
