using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _404
    {
        int ans;
        public int SumOfLeftLeaves(TreeNode root)
        {
            ans = 0;

            Helper(root, false);

            return ans;
        }
        //Without using the global variable
        public int SumOfLeftLeaves2(TreeNode root)
        {
            return Helper2(root, false);
        }
        // iterative version
        public int SumOfLeftLeaves3(TreeNode root)
        {
            if (root == null) return 0;
            int ans = 0;
            Stack<TreeNode> stk = new Stack<TreeNode>();
            stk.Push(root);
            while (stk.Count != 0)
            {
                TreeNode node = stk.Pop();
                if (node.left != null)
                {
                    // It means this is leaf node on the left side
                    if (node.left.left == null && node.right.right == null)
                    {
                        ans += node.left.val;
                    }
                    else
                    {
                        stk.Push(node.left);
                    }
                }
                if (node.right != null)
                {
                    // We add it to stack only if it is not a leaf.
                    if (node.right.left != null || node.left.left != null)
                    {
                        stk.Push(node.right);
                    }
                }
            }
            return ans;

        }


        private int Helper2(TreeNode node, bool isLeft)
        {
            if (node == null)
                return 0;
            if (node.left == null && node.right == null && isLeft)
            {
                return node.val;
            }

            return Helper2(node.left, true) + Helper2(node.right, false);
        }

        private void Helper(TreeNode node, bool isLeft)
        {
            if (node == null)
                return;
            if (node.left == null && node.right == null && isLeft)
            {
                ans += node.val;
                return;
            }

            Helper(node.left, true);
            Helper(node.right, false);
        }

    }
}
