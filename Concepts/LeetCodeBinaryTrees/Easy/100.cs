using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    public class _100
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }
            if (p != null && q != null)
            {
                return p.val == q.val &&
                    IsSameTree(p.left, q.left) &&
                    IsSameTree(p.right, q.right);

            }
            return false;
        }
    }
}
