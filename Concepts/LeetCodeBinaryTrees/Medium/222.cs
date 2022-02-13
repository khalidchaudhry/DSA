using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _222
    {
        /// <summary>        
        //https://www.youtube.com/watch?v=u-yWemKGWO0
        //! Number of Nodes in perfect binary Tree=2^height - 1
        //! TC=Log(n)^2= logn for tree height and we will do it at max logn times 
        //! SC=Log(n)==Height of the recursion. As its complete binary tree , height will be logn
        /// </summary>
        public int CountNodes0(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            //! Whatever we get from left subtree we need to add 1 to it to include the current node
            //! Whatever we get from right subtree we need to add 1 to it to include the current node
            int leftTreeHeight =1+ LeftTreeHeight(root.left);
            int rightTreeHeight =1+ LeftTreeHeight(root.right);

            if (leftTreeHeight == rightTreeHeight)
            {
                return (int)Math.Pow(2, leftTreeHeight) - 1;
            }
            //! Adding 1 because we need to include the current node 
            return 1 + CountNodes0(root.left) + CountNodes0(root.right);
        }

        private int LeftTreeHeight(TreeNode node)
        {
            int height = 0;
            while (node != null)
            {
                ++height;
                node = node.left;
            }
            return height;
        }
        private int RightTreeHeight(TreeNode node)
        {
            int height = 0;
            while (node != null)
            {
                ++height;
                node = node.right;
            }
            return height;
        }



        int count = 0;
        public int CountNodes(TreeNode root)
        {
            Helper(root);

            return count;
        }

        private void Helper(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            count += 1;

            Helper(root.left);

            Helper(root.right);

        }

    }
}
