using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _530
    {

        public int GetMinimumDifference(TreeNode root)
        {
            int minAbsDiff = int.MaxValue;
            List<int> lst = new List<int>();
            InOrder(root, lst);

            for (int i = 0; i < lst.Count - 1; i++)
            {
                int diff = Math.Abs(lst[i] - lst[i + 1]);
                minAbsDiff = Math.Min(minAbsDiff, diff);
            }

            return minAbsDiff;
        }
        public void  InOrder(TreeNode node,List<int> lst)
        {
            if (node == null)
                return;
            InOrder(node.left,lst);
            lst.Add(node.val);
            InOrder(node.right, lst);
        }


    }
}
