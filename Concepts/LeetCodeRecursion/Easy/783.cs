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
                int diff = Math.Abs(nodes[i - 1] - nodes[i]);
                minDiff = Math.Min(diff, minDiff);
            }

            return minDiff;


        }
        /// <summary>
        // !Based on idea discuss in Kuai's class 
        //! Using explicit stack
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDiffInBST2(TreeNode root)
        {
            int minDiff = int.MaxValue;
            int prevValue = int.MaxValue;
            TreeNode curr = root;
            Stack<TreeNode> stk = new Stack<TreeNode>();

            while (curr != null || stk.Count > 0)
            {
                while (curr != null)
                {
                    stk.Push(curr);
                    curr = curr.left;
                }
                curr = stk.Pop();
                //!incase there is only one node
                int diff = prevValue == int.MaxValue ? int.MaxValue : Math.Abs(prevValue - curr.val);
                minDiff = Math.Min(minDiff, diff);
                prevValue = curr.val;
                curr = curr.right;
            }

            return minDiff == int.MaxValue ? 0 : minDiff;

        }




        /// <summary>
        //! Based on idea in Kai's class. Using patten used in IsValidBST problem
        //! https://leetcode.com/problems/minimum-distance-between-bst-nodes/discuss/118420/4ms-Simple-Java-solution-O(log(N))-time-based-on-Valid-BST
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDiffInBST3(TreeNode root)
        {
            return Helper(root, int.MinValue, int.MaxValue);
        }

        private int Helper(TreeNode root, int lower, int upper)
        {
            if (root == null)
                return 0;

            int minDifference = int.MaxValue;

            //! Below two if's equivalent to node.val > left && node.val < right in IsValidBST
            if (lower != int.MinValue)
            {
                minDifference = Math.Min(minDifference, Math.Abs(root.val - lower));
            }
            if (upper != int.MaxValue)
            {
                minDifference = Math.Min(minDifference, Math.Abs(root.val - upper));
            }
            //!Below two if's equal to     
            //!Helper(node.left, left, node.val) &&
            //!Helper(node.right, node.val, right) in BST problem

            if (root.left != null)
            {
                minDifference = Math.Min(minDifference, Helper(root.left, lower, root.val));
            }
            if (root.right != null)
            {
                minDifference = Math.Min(minDifference, Helper(root.right, root.val, upper));
            }

            return minDifference == int.MaxValue ? 0 : minDifference;
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
