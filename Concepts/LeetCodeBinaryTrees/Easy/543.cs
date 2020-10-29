using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinaryTrees.Easy
{
    class _543
    {

        public int DiameterOfBinaryTree2(TreeNode root)
        {
            ResultWrapper wrapper = new ResultWrapper();

            DiameterOfBinaryTree2(root, wrapper);

            return wrapper.Result;
        }
        /// <summary>
        //! Same pattern as used in problem 687
        /// </summary>      
        /// <returns></returns>
        private int DiameterOfBinaryTree2(TreeNode root, ResultWrapper wrapper)
        {
            if (root == null)
                return 0;

            int left = DiameterOfBinaryTree2(root.left, wrapper);
            int right = DiameterOfBinaryTree2(root.right, wrapper);

            int leftMax = 0;
            int rightMax = 0;

            if (root.left != null)
            {
                leftMax = 1 + left;
            }
            if (root.right != null)
            {
                rightMax = 1 + right;
            }
            //!Reason using Result is that it may or may not pass through the root.
            wrapper.Result = Math.Max(wrapper.Result, leftMax + rightMax);

            return Math.Max(leftMax, rightMax);
        }

        public int DiameterOfBinaryTree0(TreeNode root)
        {

            if (root == null)
                return 0;

            int lHeight = Height(root.left);
            int rHeight = Height(root.right);

            int lDiameter = DiameterOfBinaryTree(root.left);
            int rDiameter = DiameterOfBinaryTree(root.right);

            return Math.Max((lHeight + rHeight), Math.Max(lDiameter, rDiameter));

        }

        public int DiameterOfBinaryTree(TreeNode root)
        {

            if (root == null)
                return 0;

            int lHeight = Height(root.left);
            int rHeight = Height(root.right);

            int lDiameter = DiameterOfBinaryTree(root.left);
            int rDiameter = DiameterOfBinaryTree(root.right);

            return Math.Max((lHeight + rHeight), Math.Max(lDiameter, rDiameter));

        }

        private int Height(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftTreeHeight = Height(node.left);
            int rightTreeHeight = Height(node.right);

            return 1 + Math.Max(leftTreeHeight, rightTreeHeight);

        }

    }

    class ResultWrapper
    {
        public int Result { get; set; }

    }
}
