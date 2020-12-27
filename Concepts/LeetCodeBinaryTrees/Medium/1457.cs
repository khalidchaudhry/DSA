using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _1457
    {
        int count;
        public int PseudoPalindromicPaths(TreeNode root)
        {
            count = 0;
            int mask = 0;
            Helper(root, mask);
            return count;
        }
        private void Helper(TreeNode node, int mask)
        {
            if (node == null)
                return;

            mask = Flip(mask, node.val);

            if (node.left == null && node.right == null)
            {
                int ans = mask & mask - 1;
                if (ans == 0) ++count;
                return;
            }

            Helper(node.left, mask);
            Helper(node.right, mask);

        }

        private int Flip(int mask, int nodeVal)
        {
            return (1 << nodeVal) ^ mask;
        }




    }
}
