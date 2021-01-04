using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _270
    {
        double minDiff;
        int ans;

        /// <summary>
        //! O(h) where h is the tree height . Worst case is still O(n) in case its unbalanced tree 
        /// </summary>
        public int ClosestValue0(TreeNode root, double target)
        {

            TreeNode curr = root;
            int closestNodeValue = root.val;
            while (curr != null)
            {
                int currNodeValue = curr.val;

                if (Math.Abs(currNodeValue - target) < Math.Abs(closestNodeValue - target))
                {
                    closestNodeValue = currNodeValue;
                }
                //! If node value is > then there is no point going to the right
                //! as difference will be more the right side and current node gives us the best result.
                if (currNodeValue > target)
                    curr = curr.left;
                //!If node value is <= target then there is no point going on left
                //! as difference will be more on the right side
                else
                    curr = curr.right;
            }

            return closestNodeValue;
        }
        
        /// <summary>
        //! Time complexity=O(N)  
        /// </summary>
        public int ClosestValue2(TreeNode root, double target)
        {
            minDiff = double.MaxValue;
            Helper2(root,target);
            return ans;
        }
             
        private void  Helper2(TreeNode node, double target)
        {
            if (node == null)
                return;
            double diff = Math.Abs(node.val - target);
            if (diff < minDiff)
            {
                minDiff = diff;
                ans = node.val;
            }
            Helper2(node.left,target);
            Helper2(node.right,target);
        }

    }
}
