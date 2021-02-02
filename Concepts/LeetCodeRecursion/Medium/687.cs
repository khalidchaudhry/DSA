using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeRecursion.Medium

{
    class _687
    {

        /// <summary>
        //!Post Order Traversal
        //! Same pattern as used in problem 543
        //https://medium.com/@rebeccahezhang/leetcode-687-longest-univalue-path-c7791a03c4a0
        /// </summary>       
        int ans;
        public int LongestUnivaluePath2(TreeNode root)
        {
            ans = 0;
            Length(root);
            return ans;

        }

        private int Length(TreeNode root)
        {
            if (root == null)
                return 0;

            int left = Length(root.left);

            int right = Length(root.right);
            // Variables to store maximum lengths 
            // in two directions 
            int leftMax = 0, rightMax = 0;
            // Compare parent node with child node
            // If they are the same, extend the max length by one
            if (root.left != null && root.left.val == root.val)
            {
                leftMax = left + 1;
            }
            if (root.right != null && root.right.val == root.val)
            {
                rightMax = right + 1;
            }
            // Adding because same node value can be on left side and right side
            // if not same then leftMax or rightMax will be 0 
            // hence no effect when adding number with zero

            // Update the max with the sum of left and right length
            ans = Math.Max(ans, leftMax + rightMax);

            // Return the max from left and right to upper node
            // since only one side path is valid
            return Math.Max(leftMax, rightMax);
        }



    }
}
