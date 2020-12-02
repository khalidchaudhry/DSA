﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _98
    {
        /// <summary>
        //!Recursion
        // https://www.youtube.com/watch?v=MILxfAbIhrE
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST(TreeNode root)
        {
            //!//!datatype must be long rather than int to satisfy below test case. Depends upon which type is of node.val
            //![-2147483648,null,2147483647]
            return Helper(root, long.MinValue, long.MaxValue);
        }

        /// <summary>
        //!Use InOrder travseral 
        /// !https://medium.com/leetcode-patterns/leetcode-pattern-0-iterative-traversals-on-trees-d373568eb0ec
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
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