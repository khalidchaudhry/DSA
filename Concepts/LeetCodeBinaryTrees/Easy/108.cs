using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeBinaryTrees.Easy
{
    //Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
    class _108
    {

        /// <summary>
        /// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/solution/
        /// https://www.youtube.com/watch?v=VVSnM5DGvjg
        // https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/solution/
        //! Time Complexity=0(n) where n is the number of elements in array. We have to go through all the array elements once 
        //! Space complexity=O(n) to keep output + O(logn) for recursion stack 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {

            return SortedArrayToBSTRecursive(nums, 0, nums.Length - 1);

        }



        private TreeNode SortedArrayToBSTRecursive(int[] nums, int s, int e)
        {

            if (s > e)
            {
                return null;
            }
          
            //! For very height balanced binary search tree, we have to choose as middle as possible
            int m = s + ((e - s) / 2);

            //! preorder traversal: node -> left -> right
            TreeNode node = new TreeNode(nums[m]);

           
            node.left = SortedArrayToBSTRecursive(nums, s, m - 1);

            node.right = SortedArrayToBSTRecursive(nums, m + 1, e);

            return node;
        }
    }
}
