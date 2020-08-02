using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _701
    {
        public static void _701Main()
        {
            _701 Insert = new _701();

            TreeNode root = new TreeNode(4);
            root.left = new TreeNode(2);
            root.right = new TreeNode(7);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(3);

            var ans=Insert.InsertIntoBST0(root,5);     
        }

        public TreeNode InsertIntoBST0(TreeNode root, int val)
        {
            if (root == null)
                return new TreeNode(val);
            if (root.val > val)
            {
                root.left = InsertIntoBST0(root.left,val);
            }
            else if (root.val < val)
            {
                root.right = InsertIntoBST0(root.right,val);
            }
            return root; 

        }


        /// <summary>
        //! Done by me
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode InsertIntoBST1(TreeNode root, int val)
        {
            if (root == null)
                return new TreeNode(val);

            return Helper(root, val);
        }

        private TreeNode Helper(TreeNode root, int val)
        {
            if (root == null)
                return root;

            if (root.val > val)
            {
                root.left = Helper(root.left,val);
                if (root.left == null)
                {
                    root.left = new TreeNode(val);
                }
            }
            else if (root.val < val)
            {
                root.right = Helper(root.right, val);
                if (root.right == null)
                {
                    root.right = new TreeNode(val);
                }
            }

            return root;
        }


    }
}
