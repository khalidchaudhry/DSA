using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _298
    {
        public int LongestConsecutive(TreeNode root)
        {
            ResultWrapper wrapper = new ResultWrapper();

            LongestConsecutive(root, wrapper);

            return wrapper.Result;
        }

        private int LongestConsecutive(TreeNode root, ResultWrapper wrapper)
        {
            if (root == null)
                return 0;
            int left = LongestConsecutive(root.left, wrapper);
            int right = LongestConsecutive(root.right, wrapper);
            //! initializing leftMax and rightMax to 1  as question asks to return nodes count(not path count)
            int leftMax = 1;
            int rightMax = 1;
            if (root.left != null && root.val + 1 == root.left.val)
            {
                leftMax = left + 1;
            }
             if (root.right != null && root.val + 1 == root.right.val)
            {
                rightMax = right + 1;
            }
            int maxLength = Math.Max(leftMax, rightMax);
            wrapper.Result = Math.Max(wrapper.Result, maxLength);
            return maxLength;
        }
    }

    public class ResultWrapper
    {
        public int Result { get; set; }
    }
}
