using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    /*
                       3
                      / \
                     0   4
                      \
                       2
                      /
                      1  
           */
    class _112
    {
        public bool HasPathSum(TreeNode root, int sum)
        {
            List<TreeNode> path = new List<TreeNode>();
            bool hasPath = HasPathSumHelper(root, sum, path);
            if (hasPath)
            {
                foreach (var item in path)
                {
                    Console.Write($"{item.val} ");
                }
            }

            return hasPath;


        }
        private bool HasPathSumHelper(TreeNode node, int sum, List<TreeNode> path)
        {
            if (node == null)
                return false;
            if (node.left == null && node.right == null)
            {
                if (node.val == sum)
                {
                    path.Add(node);

                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (HasPathSumHelper(node.left, sum - node.val, path) || HasPathSumHelper(node.right, sum - node.val, path))
            {
                path.Add(node);

                return true;
            }

            return false;
        }
        public bool HasPathSum2(TreeNode root, int sum)
        {
            if (root == null)
                return false;
            if (root.left == null && root.right == null)
            {
                if (root.val == sum)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (HasPathSum2(root.left, sum - root.val) || HasPathSum2(root.right, sum - root.val))
            {
                return true;
            }
            return false;
        }
    }
}
