using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _222
    {
        /// <summary>
        //! https://www.youtube.com/watch?v=CvrPf1-flAA 
        /// </summary>
        public int CountNodes0(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftLevel = 1;
            TreeNode n = root.left;
            while (n != null)
            {
                n = n.left;
                leftLevel += 1;
            }

            int rightLevel = 1;
            n = root.right;
            while (n != null)
            {
                n = n.right;
                rightLevel += 1;
            }

            if (leftLevel == rightLevel)
            {
                return (int)Math.Pow(2, leftLevel) - 1;
            }
            //! Adding 1 because we need to include the current node 
            return 1 + CountNodes0(root.left) + CountNodes0(root.right);
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
