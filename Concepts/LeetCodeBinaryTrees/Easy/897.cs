using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _897
    {
        public TreeNode IncreasingBST(TreeNode root)
        {
            if (root == null)
                return null;

            List<int> nodes = new List<int>();
            InOrderTraversal(root, nodes);

            TreeNode newRoot = new TreeNode(nodes[0]);
            TreeNode temp = newRoot;
            // You stuck with how to advance the pointer 
            for (int i = 1; i < nodes.Count; i++)
            {
                temp.right = new TreeNode(nodes[i]);
                temp = temp.right;
            }
            return newRoot;
        }

        private void InOrderTraversal(TreeNode node, List<int> nodes)
        {
            if (node == null)
                return;
            InOrderTraversal(node.left, nodes);
            nodes.Add(node.val);
            InOrderTraversal(node.right, nodes);
        }



    }
}
