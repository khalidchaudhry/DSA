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
        public TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;
            if (root == p || root == q)
            {
                return root;
            }

            TreeNode left = LowestCommonAncestor2(root.left, p, q);
            TreeNode right = LowestCommonAncestor2(root.right, p, q);

            if (left == null)
                return right;
            if (right == null)
                return left;

            return root;


        }
        public TreeNode LowestCommonAncestor3(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root.val > Math.Max(p.val, q.val))
            {
                return LowestCommonAncestor3(root.left, p, q);
            }
            else if (root.val < Math.Min(p.val, q.val))
            {
                return LowestCommonAncestor3(root.right, p, q);
            }

            else
                return root;

        }
    }
}
