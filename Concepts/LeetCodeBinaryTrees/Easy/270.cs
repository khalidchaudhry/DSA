using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _270
    {
        double minDiff;
        int ans;
        public int ClosestValue(TreeNode root, double target)
        {
            int  valueToSearch = (int)Math.Round(target, MidpointRounding.AwayFromZero);

            return Helper(root,valueToSearch);
        }

        public int ClosestValue2(TreeNode root, double target)
        {
            minDiff = double.MaxValue;
            Helper2(root,target);
            return ans;
        }

        private int Helper(TreeNode node, int target)
        {
            
                if (node.val > target)
                    return Helper(node.left, target);
                else if (node.val < target)
                    return Helper(node.right, target);
                else
                    return node.val;                
        }
        private void  Helper2(TreeNode node, double target)
        {
            if (node == null)
                return;
            double diff = Math.Abs(node.val - target);
            if (diff < minDiff)
            {
                minDiff = diff;
                ans = node.val;
            }
            Helper2(node.left,target);
            Helper2(node.right,target);
        }

    }
}
