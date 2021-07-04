using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinaryTrees.Easy
{
    class _101
    {
        // space complexity =O(n)
        // Time complexity =O(h)
        /// <summary>
        //! Same as question 100 
        /// </summary>
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;

            return Helper(root.left, root.right);
        }
        
        private bool Helper(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
                return true;

            if (left == null || right == null)
                return false;
       
         return left.val==right.val && 
                Helper(left.left, right.right) && 
                Helper(left.right, right.left);

        }



    }
}
