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
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {

            return SortedArrayToBSTRecursive(nums, 0, nums.Length - 1);

        }



        private TreeNode SortedArrayToBSTRecursive(int[] nums, int startIndex, int endIndex)
        {

            if (startIndex > endIndex)
            {
                return null;
            }
          
            //! For very height balanced binary search tree, we have to choose as middle as possible
            int middleIndex = startIndex + ((endIndex - startIndex) / 2);

            //! preorder traversal: node -> left -> right
            TreeNode node = new TreeNode(nums[middleIndex]);

           
            node.left = SortedArrayToBSTRecursive(nums, startIndex, middleIndex - 1);

            node.right = SortedArrayToBSTRecursive(nums, middleIndex + 1, endIndex);

            return node;
        }
    }
}
