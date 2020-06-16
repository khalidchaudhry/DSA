using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _687
    {
        int ans;
        //! Does not work for below input
        /*
                  1
                 / \
                2   2
               / \   
              2  2    
          
          
         */
        public int LongestUnivaluePath(TreeNode root)
        {
            List<int> lst = new List<int>();
            InOrderTraversal(root, lst);
            int len = 0;
            int maxLen = 0;
            for (int i = 1; i < lst.Count; i++)
            {
                if (lst[i - 1] == lst[i])
                {
                    ++len;
                    if (len > maxLen)
                    {
                        maxLen = len;
                    }
                }
                else
                {
                    len = 0;
                }
            }
            //foreach (int item in lst)
            //{
            //    if (dict.ContainsKey(item))
            //    {
            //        dict[item]++;
            //    }
            //    else
            //    {
            //        dict.Add(item, 1);
            //    }
            //}
            //foreach (var item in dict)
            //{
            //    if (item.Value > longestPathLength)
            //    {
            //        longestPathLength = item.Value;
            //    }
            //}
            //if (longestPathLength != 0)
            //    longestPathLength = longestPathLength - 1;

            return maxLen;

        }
        public void InOrderTraversal(TreeNode node, List<int> lst)
        {
            if (node == null)
                return;
            InOrderTraversal(node.left, lst);
            lst.Add(node.val);
            InOrderTraversal(node.right, lst);
        }

        /// <summary>
        //!Post Order Traversal
        //https://medium.com/@rebeccahezhang/leetcode-687-longest-univalue-path-c7791a03c4a0
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int LongestUnivaluePath2(TreeNode root)
        {
            ans = 0;
            Length(root);
            return ans;

        }

        public int Length(TreeNode root)
        {
            if (root == null)
                return 0;

            int left = Length(root.left);

            int right = Length(root.right);
            // Variables to store maximum lengths 
            // in two directions 
            int leftMax = 0, rightMax = 0;
            // Compare parent node with child node
            // If they are the same, extend the max length by one
            if (root.left != null && root.left.val == root.val)
            {
                leftMax += left + 1;
            }
            if (root.right != null && root.right.val == root.val)
            {
                rightMax += right + 1;
            }
            // Adding because same node value can be on left side and right side
            // if not same then leftMax or rightMax will be 0 
            // hence no effect when adding number with zero

            // Update the max with the sum of left and right length
            ans = Math.Max(ans, leftMax + rightMax);
            
            // Return the max from left and right to upper node
            // since only one side path is valid
            return Math.Max(leftMax, rightMax);
        }


    }
}
