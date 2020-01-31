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
            Stack<Node> stk = new Stack<Node>();

            if (root != null)
                stk.Push(root);

            while (stk.Count != 0)
            {
                var node = stk.Pop();
                preOrder.Add(node.val);
                if (node.children != null)
                {
                    for (int i=node.children.Count-1;i>=0;i--)
                    {
                        stk.Push(node.children[i]);
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
