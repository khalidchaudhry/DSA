using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInterviewQuestions.Easy
{
    class _108
    {
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

            int middleIndex = (startIndex + endIndex) / 2;

            TreeNode node = new TreeNode(nums[middleIndex]);

            node.left = SortedArrayToBSTRecursive(nums, startIndex, middleIndex - 1);

            node.right = SortedArrayToBSTRecursive(nums, middleIndex + 1, endIndex);

            return node;
        }
    }
}
