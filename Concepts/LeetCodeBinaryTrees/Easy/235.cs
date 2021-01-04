using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _235
    {
        /*
                  3
                 / \
                0   4
                 \
                  2
                 /
                 1  
         */

        //! If tree is a BST 
        public TreeNode LowestCommonAncestor0(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root.val > Math.Max(p.val, q.val))
            {
                return LowestCommonAncestor0(root.left, p, q);
            }
            else if (root.val < Math.Min(p.val, q.val))
            {
                return LowestCommonAncestor0(root.right, p, q);
            }

            else
                return root;

        }

        public TreeNode LowestCommonAncesstor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return null;
            }

            Stack<TreeNode> pathToP = new Stack<TreeNode>();
            Stack<TreeNode> pathToQ = new Stack<TreeNode>();
            LCAHelper(root, p, pathToP);
            LCAHelper(root, q, pathToQ);

            while (pathToP.Peek() != pathToQ.Peek())
            {
                pathToP.Pop();
                pathToQ.Pop();

            }

            return pathToP.Peek();
        }
        public void LCAHelper(TreeNode node, TreeNode n, Stack<TreeNode> stk)
        {
            if (node == null)
            {
                return;
            }


            if (stk.Count != 0 && stk.Peek() == n)
            {
                return;
            }
            else
            {
                stk.Push(node);
            }
            LCAHelper(node.left, n, stk);
            LCAHelper(node.right, n, stk);
            if (stk.Count != 0 && stk.Peek() != n)
            {
                stk.Pop();
            }

        }

        /// <summary>
        //!  This method is more suitable if tree is not BST and regular binary tree.  
        /// </summary>
        public TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
        {

        /*
         * Our base cases. How our recursion stops. When we have an answer.
         * 
         * 1.) If the node we are holding is null then we can't search...just return
         * null 2.) If we find either value return ourselves to the caller
         * 
         * Remember, we are "grabbing"/"holding" 'root' in this call.
         */
            if (root == null)
                return null;
            if (root == p || root == q)
            {
                return root;
            }
            /*
             * 'root' doesn't satisfy any of our base cases.
             * 
             * Search left and then search right.
             */
            TreeNode left = LowestCommonAncestor2(root.left, p, q);
            TreeNode right = LowestCommonAncestor2(root.right, p, q);

            /*
            * If nothing turned up on the left, return whatever we got back on the right.
            */
            if (left == null)
                return right;
            /*
            * If nothing turned up on the right, return whatever we got back on the left.
            */
            if (right == null)
                return left;
            /*
            * If we reach here that means we got something back on the left AND
            * right...that means this node is the LCA...because our recursion returns from
            * bottom to up...so we return what we hold...'root'
            */
            return root;
        }

       
    }
}
