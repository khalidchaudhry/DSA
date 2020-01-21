using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class PrintAllPaths
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
        public void PrintAllRootToLeafPaths(TreeNode root)
        {

            Stack<int> stk = new Stack<int>();
            PrintAllRootToLeafPathsHelper(root, stk);
        }
        public void PrintAllRootToLeafPathsHelper(TreeNode node, Stack<int> stk)
        {
            if (node == null)
                return;
            stk.Push(node.val);
            if (node.left == null && node.right == null)
            {
                foreach (int val in stk)
                {
                    Console.Write($"{val} ");
                }
                stk.Pop();
                Console.WriteLine();
                return;
            }

            PrintAllRootToLeafPathsHelper(node.left, stk);
            PrintAllRootToLeafPathsHelper(node.right, stk);

            stk.Pop();

        }
    }
}
