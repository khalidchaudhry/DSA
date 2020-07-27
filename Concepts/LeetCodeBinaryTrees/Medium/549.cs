using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _549
    {
        public static void _549Main(TreeNode root)
        {


        }
        public int LongestConsecutive(TreeNode root)
        {
            ResultWrapper wrapper = new ResultWrapper();

            LongestConsecutive(root, wrapper);

            return wrapper.LongestLength;


        }

        private int[] LongestConsecutive(TreeNode node, ResultWrapper wrapper)
        {
            if (node == null)
                return new int[] { 0, 0 };
            // [0]: longest increasing (parent-child)
            // [1]: longest decreasing ((parent-child))

            int[] left = LongestConsecutive(node.left, wrapper);
            int[] right = LongestConsecutive(node.right, wrapper);

            int inc = 1;
            int dec = 1;
            if (node.left != null)
            {
                if (node.val - node.left.val == 1)// increasing path from left side to root
                {
                    inc = left[0] + 1;
                }
                else if (node.left.val - node.val == 1)   // decreasing path  from left side to parent
                {
                    dec = left[1] + 1;
                }
            }

            if (node.right != null)
            {
                if (node.val - node.right.val == 1) //increasing path from parent to right side
                {
                    inc = Math.Max(inc, right[0] + 1);
                }
                else if (node.right.val - node.val == 1) // decreasing path from right to parent
                {
                    dec = Math.Max(dec, right[1] + 1);
                }
            }
            //! -1 because we included the root twice
            wrapper.LongestLength = Math.Max(wrapper.LongestLength,inc+dec-1);
            return new int[] { inc, dec };

        }

        public class ResultWrapper
        {
            public int LongestLength { get; set; }
        }
    }
}
