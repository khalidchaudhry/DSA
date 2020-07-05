using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _94
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            Helper(root, result);
            return result;
        }

        private void Helper(TreeNode root, List<int> result)
        {
            if (root == null)
                return;
            Helper(root.left, result);
            result.Add(root.val);
            Helper(root.right, result);
        }

        /// <summary>
        //! InOrder traversal Order (left,Root,Right)
        //! In order traversal of BST produces sorted order
        //!https://www.geeksforgeeks.org/inorder-tree-traversal-without-recursion/
        //! Intuition is that just follow In Order Traversal (Left,Root,Right)
        //! Think about InOrder traversal recursive template
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal0(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stk = new Stack<TreeNode>();

            TreeNode curr = root;

            //!stk.Count!=0 is important . Otherwise it will not work correctly 
            //!e.g. for below input
            //        1
            //        \
            //        2
            //       /
            //     3   
            while (curr != null || stk.Count != 0)
            {
                //!reach to the left most node of the curr node
                //!InOrder traversal Order (left)

                while (curr != null)
                {
                    stk.Push(curr);
                    curr = curr.left;
                }
                //!InOrder traversal Order (root)
                curr = stk.Pop();
                result.Add(curr.val);
                //now its right node turn
                //!InOrder traversal Order (right)
                curr = curr.right;
            }

            return result;
        }
    }
}
