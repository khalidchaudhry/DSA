using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Medium
{
    public class KthSmallestNode
    {
        /// <summary>
        /// https://medium.com/leetcode-patterns/leetcode-pattern-0-iterative-traversals-on-trees-d373568eb0ec
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthSmallest(TreeNode root, int k)
        {
            List<int> inorder = new List<int>();
            Stack<TreeNode> stk = new Stack<TreeNode>();
            TreeNode curr = root;

            while (curr != null || stk.Count > 0)
            {
                while (curr != null)
                {
                    stk.Push(curr);
                    curr = curr.Left;
                }

                curr = stk.Pop();
                inorder.Add(curr.Value);

                curr = curr.Right;
            }

            return inorder[k];
        }

    }
}
