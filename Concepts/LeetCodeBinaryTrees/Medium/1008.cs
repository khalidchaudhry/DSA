using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{

    public class _1008
    {
        int PreStart;
        int[] PreOrder;
        public TreeNode BstFromPreorder(int[] preorder)
        {

            this.PreStart = 0;
            this.PreOrder = preorder;
            return BstFromPreorder(int.MinValue, int.MaxValue);
        }

        private TreeNode BstFromPreorder(int minValue, int maxValue)
        {
            if (this.PreStart >= this.PreOrder.Length)
                return null;

            int data = PreOrder[PreStart];

            if (data > minValue && data < maxValue)
            {
                TreeNode root = new TreeNode(data);
                ++this.PreStart;
                root.left = BstFromPreorder(minValue, data);
                root.right = BstFromPreorder(data, maxValue);
                return root;
            }

            return null;

        }
    }
}
