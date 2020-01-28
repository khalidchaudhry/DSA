using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _563
    {
        int ans;
        public int FindTilt(TreeNode root)
        {
            ans = 0;
            Helper(root);
            return ans;
        }

        private int Helper(TreeNode node)
        {
            if (node == null)
                return 0;
            int left = Helper(node.left);
            int right = Helper(node.right);
            ans+= Math.Abs(left - right);
            // This is where i stuck. I was adding absDiff to node.val  however it should be 
            // left + right  as we go from botom to top we sum everything on left side & right side
            // and return
            return node.val+ left+right;
        }


    }
}
