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

        public TreeNode ConstructMaximumBinaryTree0(int[] nums)
        {
            //! we are passing nums.Length and not nums.Length-1 because in calculating Max in Construct function we are using i < end
            TreeNode root = Construct(nums, 0, nums.Length);
            return root;
        }

        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {

            TreeNode root = Helper(nums, 0, nums.Length - 1);
            return root;

        }
        /// <summary>
        /// https://leetcode.com/problems/maximum-binary-tree/discuss/106156/Java-worst-case-O(N)-solution
        /// https://leetcode.com/problems/maximum-binary-tree/discuss/106147/c-8-lines-on-log-n-map-plus-stack-with-binary-search
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
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

        private TreeNode Construct(int[] nums, int start, int end)
        {
            //base condition
            if (start == end)
            {
                return null;
            }

            int maxNumIndex = Max(nums, start, end);

            TreeNode node = new TreeNode(nums[maxNumIndex]);
            //! not passing maxNumIndex-1 because in Max function above we are using i<end 
            node.left = Helper(nums, start, maxNumIndex);

            node.right = Helper(nums, maxNumIndex + 1, end);

            return node;
        }

        private int Max(int[] nums, int start, int end)
        {
            int max_i = start;
            for (int i = start; i < end; i++)
            {
                if (nums[max_i] < nums[i])
                    max_i = i;
            }
            return max_i;
        }

        private TreeNode Helper(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return null;
            }
            if (start < 0)
                return null;

            int maxNumIndex = MaxNumberIndex(nums, start, end);

            TreeNode node = new TreeNode(nums[maxNumIndex]);

            node.left = Helper(nums, start, maxNumIndex - 1);

            node.right = Helper(nums, maxNumIndex + 1, end);

            return node;
        }

        private int MaxNumberIndex(int[] nums, int start, int end)
        {
            int max = int.MinValue;
            int maxValueIndex = -1;
            while (start <= end)
            {
                if (nums[start] > max)
                {
                    max = Math.Max(max, nums[start]);
                    maxValueIndex = start;
                }
                ++start;
            }
            return maxValueIndex;
        }
    }
}
