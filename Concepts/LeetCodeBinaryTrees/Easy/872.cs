using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _872
    {
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
            {
                return true;
            }
            if (root1 == null || root2 == null)
            {
                return false;
            }

            Stack<int> stk1 = new Stack<int>();
            Stack<int> stk2 = new Stack<int>();
            PostOrderTraversal(root1,stk1);
            PostOrderTraversal(root2, stk2);
            while (stk1.Count != 0 && stk2.Count != 0)
            {
                if (stk1.Pop() != stk2.Pop())
                    return false;
            }

            if (stk1.Count != 0 || stk2.Count != 0)
            {
                return false;
            }

            return true;
        }

        private void PostOrderTraversal(TreeNode node, Stack<int> stk)
        {
            if (node == null)
                return;
            if (node.left == null && node.right == null)
            {
                stk.Push(node.val);
                return;
            }
            PostOrderTraversal(node.left,stk);
            PostOrderTraversal(node.right,stk);
        }


    }
}
