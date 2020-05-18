using BinaryTree.Medium.scottc130;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree.Medium
{
    public class ValidBST
    {

        public bool IsValidBSTRecursive(TreeNode root)
        {
            //!datatype must be long rather than int to satisfy below test case> What about using double and then infinity froom it
            //[-2147483648,null,2147483647]

            return Helper(root, double.NegativeInfinity, double.PositiveInfinity);
        }
        /// <summary>
        /// Pre order traversal
        /// </summary>
        /// <param name="node"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private bool Helper(TreeNode node, double left, double right)
        {
            if (node == null)
                return true;
            if (node.Value > left && node.Value < right)
            {
                return Helper(node.Left, left, node.Value) &&
                       Helper(node.Right, node.Value, right);
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        //!Use InOrder travseral 
        /// !https://medium.com/leetcode-patterns/leetcode-pattern-0-iterative-traversals-on-trees-d373568eb0ec
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBSTIterative(TreeNode root)
        {
            if (root == null)
                return true;
            Stack<TreeNode> stk = new Stack<TreeNode>();
            TreeNode curr = root;
            long minVal = long.MinValue;
            //!  || stk.Count>0 for [5,1,4,null,null,3,6]
            while (curr != null || stk.Count > 0)
            {
                //! Keep pushing the left side till it reaches bottom
                while (curr != null)
                {
                    stk.Push(curr);
                    curr = curr.Left;
                }
                //! Pope item from stack as it will be last elment on left side of the tree
                curr = stk.Pop();
                //!<= for this test case [1,1]
                //!If popped node is  less than or equal to the minValue return false else set minVal to the popped node value
                if (curr.Value <= minVal)
                {
                    return false;
                }
                else
                {
                    minVal = curr.Value;
                }

                curr = curr.Right;
            }

            return true;
        }


    }
}
