using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _589
    {

        // recursive version
        public IList<int> Preorder2(Node root)
        {
            List<int> preOrder = new List<int>();
            if (root == null)
                return preOrder;
            preOrder.Add(root.val);
            foreach (Node child in root.children)
            {
                preOrder.Add(child.val);

                if (child.children != null)
                {
                    foreach (Node subChild in child.children)
                    {
                        preOrder.Add(subChild.val);
                    }
                }
            }

            return preOrder;
        }

        public IList<int> Preorder(Node root)
        {
            List<int> preOrder = new List<int>();
            Helper(root, preOrder);
            return preOrder;
        }

        private void Helper(Node root, List<int> preOrder)
        {
            if (root == null)
                return;
            preOrder.Add(root.val);
            if (root.children != null)
            {
                foreach (Node node in root.children)
                {
                    Helper(node, preOrder);
                }
            }
        }
    }
}
