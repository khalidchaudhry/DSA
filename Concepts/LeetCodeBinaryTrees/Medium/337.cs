using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _337
    {

        /// <summary>
        //! At every house we have 2 choices
        //! 1. If parent is not Robbed
        //!    1. House robbed 
        //!    2. Skip    
        //! 3. If parent is robbed
        //!    1. Skip
        /// </summary>
         public int Rob0(TreeNode root)
        {
            Dictionary<(TreeNode node, bool isParentRob), int> memo = new Dictionary<(TreeNode node, bool isParentRob), int>();
            return Rob0(root, false, memo);
        }

        private int Rob0(TreeNode node, bool isParentRob, Dictionary<(TreeNode node, bool isParentRob), int> memo)
        {
            if (node == null)
                return 0;

            if (memo.ContainsKey((node, isParentRob)))
                return memo[(node, isParentRob)];

            //! If parent rob , we can't rob this node and we have to skip it
            if (isParentRob)
            {
                return memo[(node, isParentRob)] = Rob0(node.left, false, memo) + Rob0(node.right, false, memo);
            }

            //! If parent not rob then we have 2 choices either rob this node or skip it
            else
            {
                int robNode = node.val + Rob0(node.left, true, memo) + Rob0(node.right, true, memo);
                int notRobNode = Rob0(node.left, false, memo) + Rob0(node.right, false, memo);
                return memo[(node, isParentRob)] = Math.Max(robNode, notRobNode);
            }
        }


        public int Rob(TreeNode root)
        {

            int[] choices=Helper(root);
            return Math.Max(choices[0],choices[1]);

        }
        public int[] Helper(TreeNode node)
        {
            if (node == null)
                return new int[] { 0, 0 };

            int[] left = Helper(node.left);
            int[] right = Helper(node.right);
            //if we rob the parent then we can't rob its children 
            var parentRobbed = node.val + left[1] + right[1];

            var parentNotRobbed = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);

            return new int[] { parentRobbed, parentNotRobbed };
        }




    }
}
