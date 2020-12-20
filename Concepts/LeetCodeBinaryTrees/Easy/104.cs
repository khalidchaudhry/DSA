using System;

namespace LeetCodeBinaryTrees.Easy
{
    class _104
    {
        //! Similar to 559 and 364 
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            int leftTreeDepth = MaxDepth(root.left);
            int rightTreeDepth = MaxDepth(root.right);

            return Math.Max(leftTreeDepth, rightTreeDepth) + 1;
        }
    }  
}
