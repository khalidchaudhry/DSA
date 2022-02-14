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
            if (root == null)
                return 0;
            //! if node value greater then low it means there may be more nodes on the left side, that falls in the range 
            if (root.val > high)
                return RangeSumBST0(root.left, low, high);
            //! if node value less then high it means there may be more nodes on the right side, that falls in the range 
            else if (root.val < low)
                return RangeSumBST0(root.right, low, high);
            else
            {
                int sum = root.val+RangeSumBST0(root.left,low,high)+ RangeSumBST0(root.right, low, high);
                return sum;
            }
        }

        public int RangeSumBST(TreeNode root, int low, int high)
        {
            sum = 0;
            Helper(root, low, high);
            return sum;
        }
        private void Helper(TreeNode node, int low, int high)
        {
            if (node == null)
                return;
           
            //!if node value is greater then high it will be greater than low too so no point going to right as value will be more
            if (node.val > high)
            {
                Helper(node.left, low, high);
            }

            //!if node value is less then low it will be lower then high  too so no point going to left  as value will be less 
            else if (node.val < low)
            {
                Helper(node.right, low, high);
            }
            else
            {
                sum += node.val;
                Helper(node.left, low, high);
                Helper(node.right, low, high);
            }
        }
        /// <summary>
        //! Below method does not consider that its BST and searches for all the nodes  
        /// </summary>
        public int RangeSumBST2(TreeNode root, int L, int R)
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
