using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _106
    {
        int PostStart;
        Dictionary<int, int> InOrderMap = new Dictionary<int, int>();
        int[] PostOrder;

        public static void _106Main()
        {
            int[] inorder = inorder = new int[] { 9, 3, 15, 20, 7 };
            int[] postorder = new int[] { 9, 15, 7, 20, 3 };

            _106 BinaryTree = new _106();

            var ans = BinaryTree.BuildTree(inorder, postorder);

            Console.ReadLine();
        }
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            this.PostOrder = postorder;
            this.PostStart = this.PostOrder.Length - 1;
            //! The reason for map is that we can lookup up root and then find left subtree and right subtree
            InOrderMap = new Dictionary<int, int>();

            for (int i = 0; i < inorder.Length; i++)
                InOrderMap.Add(inorder[i], i);

            return ConstructTree(0, inorder.Length - 1);

        }

        private TreeNode ConstructTree(int inStart, int inEnd)
        {

            if (inStart > inEnd)
                return null;

            if (PostStart < 0)
                return null;

            int rootVal = PostOrder[PostStart];
            int rootIndex = InOrderMap[rootVal];
            TreeNode node = new TreeNode(rootVal);
            --this.PostStart;
            //! we are going first on the right then on the left ? WHY?
            node.right = ConstructTree(rootIndex + 1, inEnd);
            node.left = ConstructTree(inStart, rootIndex - 1);
            return node;

        }
    }
}
