using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _669
    {
                   /* 
                     3
                    / \
                   0   4
                    \
                     2
                    /
                    1


                    */
        /* 1-----3*/
        // Post order traversal of the tree
        public TreeNode TrimBST2(TreeNode root, int L, int R)
        {
            if (root == null)
            {
                return null;
            }
            // First fix the left subtree and right subtree  of the root
            //
            root.left = TrimBST2(root.left,L,R);
            root.right = TrimBST2(root.right, L, R);

            // then fix the root. 

            // If current node’s value is less than min, then we return the reference to its right subtree, 
            // and discard the left subtree.Because if a node’s value is less than min, then its left children are 
            // definitely less than min since this is a binary search tree
            // But its right children may or may not be less than min we can’t be sure, so we return the reference to it.
            if (root.val < L)
            {
                return root.right;
            }
            // when node’s value is greater than max, we now return the reference to its left subtree.
            // Because if a node’s value is greater than max, then its right children are definitely greater than max.
            // But its left children may or may not be greater than max. So we discard the right subtree and return the 
            // reference to the already valid left subtree.
            if (root.val > R)
            {
                return root.left;
            }

            return root;
        }

        /// <summary>
        //! PreOrder Traversal 
        /// </summary>
        public TreeNode TrimBST(TreeNode root, int low, int high)
        {
            if (root == null)
                return null;

            if (root.val >= low && root.val <= high)
            {
                root.left = TrimBST(root.left, low, high);
                root.right = TrimBST(root.right, low, high);
                return root;
            }
            else if (root.val < low)
            {
                return TrimBST(root.right, low, high);
            }
            else
            {
                return TrimBST(root.left, low, high);
            }
        }
    }
}
