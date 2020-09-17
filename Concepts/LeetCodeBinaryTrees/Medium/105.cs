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
        /// <summary>
        /// https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/solution/
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree1(int[] preorder, int[] inorder)
        {
            this.PreOrder = preorder;
            this.InOrder = inorder;
            PreStart = 0;
            // build a hashmap value -> its index            

            for (int i = 0; i < inorder.Length; i++)
                InOrderMap.Add(inorder[i], i);
            return Helper(0, inorder.Length);
        }

        public TreeNode Helper(int in_left, int in_right)
        {
            // if there is no elements to construct subtrees
            if (in_left == in_right)
                return null;

            // pick up pre_idx element as a root
            int root_val = PreOrder[PreStart];
            TreeNode root = new TreeNode(root_val);

            // root splits inorder list
            // into left and right subtrees
            int rootIndex = InOrderMap[root_val];

            // recursion 
            PreStart++;
            // build left subtree
            root.left = Helper(in_left, rootIndex);
            // build right subtree
            root.right = Helper(rootIndex + 1, in_right);
            return root;
        }

        public TreeNode BuildTree2(int[] preorder, int[] inorder)
        {
            Queue<int> preorder_queue = new Queue<int>();
            foreach (int i in preorder)
            {
                preorder_queue.Enqueue(i);
            }

            List<int> inorder_list = new List<int>();
            foreach (int i in inorder)
                inorder_list.Add(i);

            return Sub(preorder_queue, inorder_list);
        }

        TreeNode Sub(Queue<int> preorder, List<int> inorder)
        {
            if (preorder.Count == 0 || inorder.Count == 0)
                return null;

            TreeNode root = new TreeNode(preorder.Dequeue());
            int pos_of_root_in_inorder = inorder.IndexOf(root.val);

            //Sub(preorder, inorder.GetRange(0, pos_of_root_in_inorder));
            root.left = Sub(preorder, inorder.GetRange(0, pos_of_root_in_inorder));
            //Sub(preorder, inorder.GetRange(pos_of_root_in_inorder + 1, inorder.Count));
            List<int> right = inorder.Skip(pos_of_root_in_inorder + 1).Take(inorder.Count).ToList();
            root.right = Sub(preorder, right);
            return root;
        }
    }
}
