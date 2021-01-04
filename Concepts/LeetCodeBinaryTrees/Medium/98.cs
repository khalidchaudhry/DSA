using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _98
    {


        /// <summary>
        //! Using inorder traversal
        //! using lower bound and upper bound concept
        /// </summary>
        public bool IsValidBST0(TreeNode root)
        {

            return IsValidBST0(root, long.MinValue, long.MaxValue);
        }

        private bool IsValidBST0(TreeNode root, long lowerBound, long upperBound)
        {
            if (root == null)
                return true;

            bool left = IsValidBST0(root.left, lowerBound, root.val);
            bool isTrue = root.val > lowerBound && root.val < upperBound;
            bool right = IsValidBST0(root.right, root.val, upperBound);

            return left && isTrue && right;
        }


        /// <summary>
        //! Iterative version
        //!Use InOrder travseral ()
        //https://medium.com/leetcode-patterns/leetcode-pattern-0-iterative-traversals-on-trees-d373568eb0ec
        /// </summary>       
        public bool IsValidBST2(TreeNode root)
        {
            if (root == null)
                return true;
            Stack<TreeNode> stk = new Stack<TreeNode>();
            TreeNode curr = root;
            long minVal = long.MinValue;
            //!  || stk.Count>0 for [5,1,4,null,null,3,6]
            while (curr != null || stk.Count > 0)
            {
                while (curr != null)
                {
                    stk.Push(curr);
                    curr = curr.left;
                }

                curr = stk.Pop();
                //!<= for this test case [1,1]
                if (curr.val <= minVal)
                {
                    return false;
                }
                else
                {
                    minVal = curr.val;
                }

                curr = curr.right;
            }

            return true;
        }
        private bool Helper(TreeNode node, long left, long right)
        {
            if (node == null)
                return true;
            return node.val > left && node.val < right &&
             Helper(node.left, left, node.val) &&
             Helper(node.right, node.val, right);
        }
    }
}
