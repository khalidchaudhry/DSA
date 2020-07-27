using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _250
    {
        public static void _250Main()
        {
            _250 univalue = new _250();

            //    5
            //   / \
            //  1   5
            // / \   \
            //5   5   5

            TreeNode node = new TreeNode(5);

            node.left = new TreeNode(1);
            node.left.left = new TreeNode(5);
            node.left.right = new TreeNode(5);

            node.right = new TreeNode(5);
            node.right.right = new TreeNode(5);


            univalue.CountUnivalSubtrees(node);

        }
        public int CountUnivalSubtrees(TreeNode root)
        {
            ResultWrapper wrapper = new ResultWrapper();
            CountUnivalSubtrees(root, wrapper);

            return wrapper.Count;
        }

        private bool CountUnivalSubtrees(TreeNode root, ResultWrapper wrapper)
        {
            if (root == null)
            {
                return true;
            }

            bool left = CountUnivalSubtrees(root.left, wrapper);
            bool right = CountUnivalSubtrees(root.right, wrapper);

            if (
               left == true &&
               right == true &&
               (root.left == null || root.val == root.left.val) &&
               (root.right == null || root.val == root.right.val)
               )
            {
                ++wrapper.Count;
                return true;
            }
            else
            {
                return false;
            }
        }

        public class ResultWrapper
        {
            public int Count { get; set; }
        }
    }
}
