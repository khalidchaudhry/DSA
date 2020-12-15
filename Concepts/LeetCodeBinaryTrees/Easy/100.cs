using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    public class _100
    {

        /// <summary>
        //! Same as question 101 
        /// </summary>
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if (p == null && q != null)
                return false;
            if (p != null && q == null)
                return false;

            if (p.val != q.val)
                return false;

            bool left = IsSameTree(p.left, q.left);
            bool right = IsSameTree(p.right, q.right);

            return left && right;
        }

        //! using an explicit space       
        public bool IsSameTree0(TreeNode p, TreeNode q)
        {
            List<int> pList = new List<int>();
            List<int> qList = new List<int>();
            Helper(p, pList);
            Helper(q, qList);
            if (pList.Count != qList.Count)
                return false;
            for (int i = 0; i < pList.Count; ++i)
            {
                if (pList[i] != qList[i])
                    return false;
            }
            return true;
        }

        private void Helper(TreeNode node, List<int> list)
        {
            if (node == null)
            {
                list.Add(0);
                return;
            }
            Helper(node.left, list);
            Helper(node.right, list);
            list.Add(node.val);
        }
    }
}
