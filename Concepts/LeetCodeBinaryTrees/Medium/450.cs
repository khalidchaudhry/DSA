using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _450
    {
        public static void _450Main()
        {

            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(3);
            root.right = new TreeNode(6);
            root.right.left = new TreeNode(4);
            _450 DeleteNode = new _450();

            var ans = DeleteNode.DeleteNode(root, 6);
        }

        /// <summary>
        /// https://leetcode.com/problems/delete-node-in-a-bst/solution/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
                return null;

            if (root.val < key)
            {
                root.right= DeleteNode(root.right, key);
            }
            else if (root.val > key)
            {
                root.left= DeleteNode(root.left, key);
            }
            else
            {
                if (root.left == null && root.right == null)
                {
                    root = null;
                }
                else if (root.right != null)
                {
                    //!assign successor value to the root
                    root.val = Successor(root.right);
                    root.right=DeleteNode(root.right, root.val);
                }
                else
                {
                    //! assign predecessor value
                    root.val = Predecessor(root.left);
                    root.left=DeleteNode(root.left, root.val);
                }
            }

            return root;

        }

        private int Successor(TreeNode node)
        {
            while (node.left != null)
            {
                node = node.left;
            }
            return node.val;
        }
        private int Predecessor(TreeNode node)
        {
            while (node.right != null)
            {
                node = node.right;
            }
            return node.val;
        }

    }
}
