using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _257
    {

        /// <summary>
        //! Time complexity =O(n*logn)
        // O(n) will be taken by stringbuilder.ToString()  
        // it will be performed logn times. How?
        // For well balanced tree, there will be N/2 leaf nodes, which will be equal to nlogn
        /// </summary>
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            List<string> paths = new List<string>();
            Helper(root, new StringBuilder(), paths);
            return paths;
        }

        private void Helper(TreeNode node, StringBuilder path, List<string> paths)
        {
            if (node == null)
            {
                return;
            }
            if (node.left == null && node.right == null)
            {
                int len = path.Length;
                path.Append(node.val);
                //! sb.ToString() time complexity O(n)
                paths.Add(path.ToString());
                path.Length = len;
                return;
            }

            int length = path.Length;
            path.Append($"{node.val}->");
            Helper(node.left, path, paths);
            Helper(node.right, path, paths);
            path.Length = length;
        }

        public IList<string> BinaryTreePaths1(TreeNode root)
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


