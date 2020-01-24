using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _257
    {
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            List<string> paths = new List<string>();
            Stack<int> stk = new Stack<int>();
            if (root == null)
                return paths;

            BinaryTreePathsHelper(root, paths, stk);

            return paths;
        }
        public void BinaryTreePathsHelper(TreeNode root, List<string> paths, Stack<int> stk)
        {
            if (root == null)
                return;
            stk.Push(root.val);
            if (root.left == null && root.right == null)
            {
                Stack<int> stk2 = new Stack<int>();
                StringBuilder sb = new StringBuilder();
                foreach (int val in stk)
                {
                    stk2.Push(val);
                }
                while (stk2.Count != 1)
                {
                    sb.Append($"{stk2.Pop()}->");
                }
                sb.Append(stk.Pop());
                paths.Add(sb.ToString());
                return;
            }
            BinaryTreePathsHelper(root.left, paths, stk);
            BinaryTreePathsHelper(root.right, paths, stk);
            stk.Pop();
        }
    }
}


