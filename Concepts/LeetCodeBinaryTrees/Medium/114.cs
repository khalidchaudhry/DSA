using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _114
    {

        /// <summary>
        //!https://leetcode.com/problems/flatten-binary-tree-to-linked-list/solution/
        /// </summary>
        /// <param name="root"></param>
        public void Flatten(TreeNode root)
        {
            Helper(root);
        }

        public TreeNode Helper(TreeNode node)
        {
            // Handle the null scenario
            if (node == null)
                return null;
            // For a leaf node, we simply return the
            // node as is.
            if (node.left == null && node.right == null)
                return node;
            //Recursively flatten the left subtree
            TreeNode leftTail = Helper(node.left);
            // Recursively flatten the right subtree
            TreeNode rightTail = Helper(node.right);
            // If there was a left subtree, we shuffle the connections
            // around so that there is nothing on the left side
            // anymore.
            if (leftTail != null)
            {
                leftTail.right = node.right;               
                node.right =node.left;
                node.left = null;
            }
            // We need to return the "rightmost" node after we are
            // done wiring the new connections. 
            return rightTail != null ? rightTail : leftTail;
        }


    }
}
