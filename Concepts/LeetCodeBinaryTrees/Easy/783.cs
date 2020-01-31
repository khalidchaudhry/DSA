using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    // same problem as 530
    class _783
    {
        public int MinDiffInBST(TreeNode root)
        {
            List<int> nodes = new List<int>();
            InOrderTraversal(root, nodes);
            int minDiff = int.MaxValue;
            for (int i = 1; i < nodes.Count; i++)
            {
                int diff=Math.Abs(nodes[i - 1] - nodes[i]);
                minDiff = Math.Min(diff,minDiff);
            }

            return minDiff;


        }

        private void InOrderTraversal(TreeNode node, List<int> nodes)
        {
            if (node == null)
                return;
            InOrderTraversal(node.left,nodes);
            nodes.Add(node.val);
            InOrderTraversal(node.right, nodes);
        }
    }
}
