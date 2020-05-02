using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _105
    {
        private int[] preorder;
        private int[] inorder;
        private Dictionary<int, int> inordermap;
        private int prestart;

        public TreeNode BuildTree0(int[] preorder, int[] inorder)
        {
            this.preorder = preorder;
            this.inorder = inorder;
            inordermap = new Dictionary<int, int>();
            prestart = -1;
            for (int i = 0; i < inorder.Length; i++)
                inordermap.Add(inorder[i], i);

            return ConstructTree(0, inorder.Length - 1);
        }

        public TreeNode ConstructTree(int instart, int inend)
        {
            if (instart > inend)
                return null;

            ++prestart;

            if (prestart >= preorder.Length)
                return null;

            int parentval = preorder[prestart];
            int parentindex = inordermap[parentval];
            TreeNode node = new TreeNode(parentval);
            node.left = ConstructTree(instart, parentindex - 1);
            node.right = ConstructTree(parentindex + 1, inend);
            return node;
        }


        public TreeNode BuildTree(int[] preorder, int[] inorder)
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
            if (preorder.Count==0 || inorder.Count==0)
                return null;

            TreeNode root = new TreeNode(preorder.Dequeue());
            int pos_of_root_in_inorder = inorder.IndexOf(root.val);

            //Sub(preorder, inorder.GetRange(0, pos_of_root_in_inorder));
            root.left = Sub(preorder, inorder.GetRange(0, pos_of_root_in_inorder));
            //Sub(preorder, inorder.GetRange(pos_of_root_in_inorder + 1, inorder.Count));
            List<int> right = inorder.Skip(pos_of_root_in_inorder + 1).Take(inorder.Count).ToList();
            root.right = Sub(preorder,right);
            return root;
        }
    }
}
