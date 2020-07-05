using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _144
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
            {
                return result;
            }
            Stack<TreeNode> stk = new Stack<TreeNode>();
            //! 1. Initialize the stack
            stk.Push(root);

            while (stk.Count != 0)
            {
                //!2. Pop out the curre node
                TreeNode curr= stk.Pop();

                result.Add(curr.val);

                if (curr.right != null)
                {
                    stk.Push(curr.right);
                }
                if (curr.left != null)
                {
                    stk.Push(curr.left);
                }
            }
            return result;
    }


    }
}
