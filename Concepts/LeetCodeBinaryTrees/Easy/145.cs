using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    public class _145
    {
        /// <summary>
        //! Reverse of preorder traversal  
        /// </summary>
        public IList<int> PostorderTraversal(TreeNode root)
        {

            if (root == null)
            {
                return new List<int>();
            }
            //! Using linked list so we have O(1) insertion
            LinkedList<int> ll = new LinkedList<int>();

            Stack<TreeNode> stk = new Stack<TreeNode>();
            stk.Push(root);
            while (stk.Count > 0)
            {
                TreeNode top = stk.Pop();
                ll.AddFirst(top.val);

                if (top.left != null)
                {
                    stk.Push(top.left);
                }
                if (top.right != null)
                {
                    stk.Push(top.right);
                }
            }

            List<int> postorder = new List<int>();

            while (ll.Count > 0)
            {
                postorder.Add(ll.First.Value);
                ll.RemoveFirst();
            }
            return postorder;
        }

    }
}
