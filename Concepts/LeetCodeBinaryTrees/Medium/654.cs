using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _654
    {

        public TreeNode ConstructMaximumBinaryTree0(int[] nums)
        {

            TreeNode root = Construct(nums, 0, nums.Length);
            return root;
        }


        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {

            TreeNode root = Helper(nums,0,nums.Length-1);
            return root;

        }

        private TreeNode Helper(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return null;
            }
            if (start < 0)
                return null;

            int maxNumIndex = MaxNumberIndex(nums,start,end);

            TreeNode node = new TreeNode(nums[maxNumIndex]);

            node.left = Helper(nums,start,maxNumIndex-1);

            node.right = Helper(nums, maxNumIndex + 1,end);

            return node;
        }

        private int MaxNumberIndex(int[] nums, int start, int end)
        {
            int max = int.MinValue;
            int maxValueIndex = -1;
            while (start <= end)
            {
                if (nums[start] >max)
                {
                    max = Math.Max(max,nums[start]);
                    maxValueIndex = start;
                }
                ++start;
            }
            return maxValueIndex;
        }
    }
}
