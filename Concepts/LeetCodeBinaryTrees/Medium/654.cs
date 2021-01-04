using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _654
    {
        //!Time complexity : O(n^2)
        //! The function Construct is called n times. 
        //! At each level of the recursive tree, we traverse over all the n elements to find the maximum element.
        //!  Average case: there will be nlogn levels leading to a complexity of O(nlogn)
        //! Worst Case: The depth of the recursive tree can grow upto n, 
        //!which happens in the case of a sorted nums array, giving a complexity of O(n^2) 

        //!Space Complexity: O(n)
        //! Worst case:O(n) The size of the set can grow upto n in the worst case
        //! Average case: nlog(n) The size will be nlogn for n elements in nums       

        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return Helper(nums, 0, nums.Length - 1);
        }
        /// <summary>
        //! Using explicit stack . Without recursion. 
        /// https://leetcode.com/problems/maximum-binary-tree/discuss/106156/Java-worst-case-O(N)-solution
        /// https://leetcode.com/problems/maximum-binary-tree/discuss/106147/c-8-lines-on-log-n-map-plus-stack-with-binary-search
        /// </summary>
        public TreeNode ConstructMaximumBinaryTree2(int[] nums)
        {
            var stack = new Stack<TreeNode>();
            for (var i = 0; i < nums.Length; i++)
            {
                var current = new TreeNode(nums[i]);
                while (stack.Count > 0 && stack.Peek().val < nums[i])
                {
                    current.left = stack.Pop();
                }
                if (stack.Count > 0)
                {
                    stack.Peek().right = current;
                }
                stack.Push(current);
            }

            TreeNode result = null;
            while (stack.Count > 0)
            {
                result = stack.Pop();
            }

            return result;
        }

        private TreeNode Helper(int[] nums, int s, int e)
        {
            if (s > e)
                return null;
            if (s == e)
                return new TreeNode(nums[s]);

            int maxValueIndex = MaxNumberIndex(nums, s, e);

            TreeNode toReturn = new TreeNode(nums[maxValueIndex]);
            toReturn.left = Helper(nums, s, maxValueIndex - 1);
            toReturn.right = Helper(nums, maxValueIndex + 1, e);
            return toReturn;
        }
        private int MaxNumberIndex(int[] nums, int s, int e)
        {
            int maxIndex = s;
            int maxValue = nums[s];
            for (int i = s; i <= e; ++i)
            {
                if (nums[i] > maxValue)
                {
                    maxValue = nums[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
    }
}
