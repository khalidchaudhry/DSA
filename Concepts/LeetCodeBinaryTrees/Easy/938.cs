using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _938
    {

        int sum = 0;
        /// <summary>
        //! Below method uses BST property to get the results  
        /// </summary>
        public int RangeSumBST0(TreeNode root, int low, int high)
        {
            Helper(root, low, high);
            return sum;
        }
        private void Helper(TreeNode node, int low, int high)
        {
            if (node == null)
                return;
            if (node.val >= low && node.val <= high)
                sum += node.val;

            //! if node value greater then low it means there may be more nodes on the left side, that falls in the range 
            if (node.val > low)
                Helper(node.left, low, high);
            //! if node value less then high it means there may be more nodes on the right side, that falls in the range 
            if (node.val < high)
                Helper(node.right, low, high);
        }
        /// <summary>
        //! Below method does not consider that its BST and searches for all the nodes  
        /// </summary>
        public int RangeSumBST(TreeNode root, int L, int R)
        {
            int[] sum = new int[1];
            RangeSumSBSTHelper(root, L, R, sum);
            return sum[0];
        }

        public void RangeSumSBSTHelper(TreeNode node, int L, int R, int[] sum)
        {
            if (node == null)
                return;
            if (node.val >= L && node.val <= R)
            {
                sum[0] += node.val;
            }
            RangeSumSBSTHelper(node.left, L, R, sum);
            RangeSumSBSTHelper(node.right, L, R, sum);
        }

    }
}
