using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _114
    {



        //https://leetcode.com/problems/flatten-binary-tree-to-linked-list/discuss/36991/Accepted-simple-Java-solution-iterative
        private void Flatten0(TreeNode root)
        {
            if (root == null)
                return;

            Stack<TreeNode> stk = new Stack<TreeNode>();

            stk.Push(root);
            while (stk.Count != 0)
            {
                TreeNode curr = stk.Pop();
                if (curr.right != null)
                    stk.Push(curr.right);
                if (curr.left != null)
                    stk.Push(curr.left);
                if (stk.Count != 0)
                    curr.right = stk.Peek();

                curr.left = null;
            }
        }


        //! using extra space to flatten it 
        public void Flatten2(TreeNode root)
        {

            List<TreeNode> nodes = new List<TreeNode>();
            PreOrder(root, nodes);
            for (int i = 0; i < nodes.Count - 1; ++i)
            {
                nodes[i].right = nodes[i + 1];
                nodes[i].left = null;
            }
        }
        /// <summary>
        //!https://leetcode.com/problems/flatten-binary-tree-to-linked-list/solution/
        //! Post Order Traversal or pre order traversal
        /// </summary>
        public void Flatten1(TreeNode root)
        {
            Helper(root);
        }
        private void PreOrder(TreeNode node, List<TreeNode> nodes)
        {
            if (node == null)
                return;

            nodes.Add(node);
            PreOrder(node.left, nodes);
            PreOrder(node.right, nodes);
        }




        private TreeNode Helper(TreeNode node)
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
                node.right = node.left;
                node.left = null;
            }
            // We need to return the "rightmost" node after we are
            // done wiring the new connections. 
            return rightTail != null ? rightTail : leftTail;
        }


    }
}
