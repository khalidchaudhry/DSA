using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    public class _145
    {
        /// <summary>
        //! Reverse of preorder traversal
        //! Preorder to post order traversal process  
        //! PrOrder=RootleftRight    PostOrder=LeftRightRoot 
        //!1. Reverse the part after Root= Root|RightLeft
        //!2. Reverse what got from above step=LeftRightRoot 
        /// </summary>
        public IList<int> PostorderTraversal(TreeNode root)
        {

            List<int> result = new List<int>();
            if (root == null)
            {
                return result;
            }
            Stack<TreeNode> stk = new Stack<TreeNode>();
            stk.Push(root);

            while (stk.Count > 0)
            {
                TreeNode top = stk.Pop();
                result.Add(top.val);
                if (top.left != null)
                {
                    stk.Push(top.left);
                }
                if (top.right != null)
                {
                    stk.Push(top.right);
                }
            }
            result.Reverse();
            return result;
        }

    }
}
