using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinaryTrees.Easy
{
    class _543
    {
        int diameter;
        public int DiameterOfBinaryTree2(TreeNode root)
        {
            
            diameter = 0;
            Solve(root);

            return diameter;
        }
        //! Same pattern as used in problem 687
       /// </summary>      
        private int Solve(TreeNode root)
        {
            if (root == null)
                return 0;


            int left = Solve(root.left);
            int right = Solve(root.right);

            int leftMax = 0;
            int rightMax = 0;

            //Parent is checking that either it has left child or not
            if (root.left != null)
            {
                leftMax = 1 + left;
            }
            //Parent is checking that either it has right child or not
            if (root.right != null)
            {
                rightMax = 1 + right;
            }
            //!Reason using Result is that it may or may not pass through the root.
            diameter = Math.Max(diameter, leftMax + rightMax);

            return Math.Max(leftMax, rightMax);
        }
        int longest = 0;
        /// <summary>
        //! Child is doind work and letting its parent know  the height 
        /// </summary>
        public int DiameterOfBinaryTree3(TreeNode root)
        {
            Solve3(root);
            return longest;
        }

        private int Solve3(TreeNode node)
        {
            if (node == null)
                return 0;

            int left = Solve3(node.left);
            int right = Solve3(node.right);
            longest = Math.Max(longest, left + right);
            return 1 + Math.Max(left, right);
        }
    }   
}
