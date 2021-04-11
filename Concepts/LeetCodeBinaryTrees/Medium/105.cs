using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _105
    {
        private int[] PreOrder;
        private int[] InOrder;
        private Dictionary<int, int> InOrderMap;
        private int PreStart;



        /// <summary>
        ///https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/discuss/518831/Accepted-(using-dictionary)-C-solution%3A-Easy-to-understand
        /// https://www.youtube.com/watch?v=PoBGyrIWisE
        //! Find the root from preorder array 
        //! Find the left sub tree and right subtree from in order array
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree0(int[] preorder, int[] inorder)
        {
            this.PreStart = 0;
            this.PreOrder = preorder;

            //! The reason for map is that we can lookup up root and then find left subtree and right subtree
            InOrderMap = new Dictionary<int, int>();

            for (int i = 0; i < inorder.Length; i++)
                InOrderMap.Add(inorder[i], i);

            return ConstructTree(0, inorder.Length - 1);
        }

        public TreeNode ConstructTree(int instart, int inend)
        {
            if (instart > inend)
                return null;

            if (this.PreStart >= this.PreOrder.Length)
                return null;
            int rootVal = this.PreOrder[this.PreStart];
            int rootIndex = InOrderMap[rootVal];
            TreeNode node = new TreeNode(rootVal);
            //! Recursion . Setting for next iteration
            ++this.PreStart;
            node.left = ConstructTree(instart, rootIndex - 1);
            node.right = ConstructTree(rootIndex + 1, inend);
            return node;
        }
    }
}
