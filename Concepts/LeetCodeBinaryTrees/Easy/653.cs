using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _653
    {
        public bool FindTarget(TreeNode root, int k)
        {
            // in order traversal of binary tree
            List<int> lst = new List<int>();

            InOrderTraversal(root,lst);
            int i = 0, j = lst.Count - 1;
            bool isFound = false;
            while (i < j)
            {
                int sum = lst[i] + lst[j];
                if (sum == k)
                {
                    isFound = true;
                    break;
                }
                else if (sum > k)
                {
                    --j;
                }
                else
                {
                    ++i;
                }
            }

            return isFound;        

        }

        public void InOrderTraversal(TreeNode root, List<int> lst)
        {
            if (root == null)
            {
                return;
            }
            InOrderTraversal(root.left, lst);
            lst.Add(root.val);
            InOrderTraversal(root.right, lst);
        }
    }
}
