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
        /// <summary>
        //! Similar to question 257 in which we need to add paths from root to leaf
        //! Code template is same . We need to do something before going into recursion. 
        /// </summary>
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;

            if (root.left == null && root.right == null)
            {
                sum = sum - root.val;
                if (sum == 0)
                    return true;
                return false;
            }

            sum -= root.val;
            bool left = HasPathSum(root.left, sum);
            bool right = HasPathSum(root.right, sum);
            if (left || right)
                return true;

            return false;
        }
    }
}
