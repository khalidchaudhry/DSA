using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _203
    {
        public int KthSmallest(TreeNode root, int k)
        {
            List<int> inorder = new List<int>();
            Stack<TreeNode> stk = new Stack<TreeNode>();
            TreeNode curr = root;

            while (curr != null || stk.Count > 0)
            {
                while (curr != null)
                {
                    stk.Push(curr);
                    curr = curr.left;
                }

                curr = stk.Pop();
                inorder.Add(curr.val);

                curr = curr.right;
            }
            //! question is not asking for array based kth smallest hence k-1
            return inorder[k-1];
        }

        public int KthSmallest2(TreeNode root, int k)
        {
            List<int> inorder = new List<int>();
            Helper(root, inorder);
            return inorder[k - 1];
        }

        private void Helper(TreeNode root, List<int> inorder)
        {
            if (root == null)
                return;
            Helper(root.left,inorder);
            inorder.Add(root.val);
            Helper(root.right, inorder);
        }
    }
}
