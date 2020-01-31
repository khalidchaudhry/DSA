using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _671
    {
        // You first declare first,second as int . One of the test case failed 
        // because it was expecting int.MaxVal as second minimum. 
        long first, second;
        public int FindSecondMinimumValue(TreeNode root)
        {
            first = long.MaxValue;
            second = long.MaxValue;
            Helper(root);
            if (second == long.MaxValue)
                return -1;
            else
                return (int)second;
        }

        private void Helper(TreeNode node)
        {
            if (node == null)
                return;
            // to find the second smallest element 
            //https://www.geeksforgeeks.org/to-find-smallest-and-second-smallest-element-in-an-array/

            if (node.val < first)
            {
                second = first;
                first = node.val;
            }
            // Not sure why node.val != first. I think it should be node.val>first
            else if (node.val < second && node.val != first)
            {
                second = node.val;
            }

            Helper(node.left);
            Helper(node.right);
        }


    }
}
