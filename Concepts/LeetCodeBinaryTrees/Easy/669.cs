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
            

            if (root.val < L)
            {
                return root.right;
            }
            if (root.val > R)
            {
                return root.left;
            }

            return root;
        }

        public TreeNode TrimBST(TreeNode root, int L, int R)
        {
                if (root == null)
                return null;           

            TreeNode newNode = new TreeNode(root.val);
            newNode.left = TrimBST(root.left, L, R);
            newNode.right = TrimBST(root.right, L, R);

            if (root.val < L || root.val > R)
            {
                return null;
            }

            return newNode;
        } 


    }
}
