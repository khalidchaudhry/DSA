using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _590
    {

        public List<int> postorder(Node root)
        {
            List<int> list = new List<int>();
            if (root == null) return list;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count!=0)
            {
                root = stack.Pop();
                list.Add(root.val);
                foreach (Node node in root.children)
                    stack.Push(node);
            }
            list.Reverse();
            return list;
        }
        public IList<int> Postorder(Node root)
        {
            List<int> postOrder = new List<int>();

            PostOrderHelper(root, postOrder);

            return postOrder;
        }
        private void PostOrderHelper(Node node, List<int> postOrder)
        {
            if (node != null)
            {
                if (node.children != null)
                {
                    foreach (var child in node.children)
                    {
                        PostOrderHelper(child, postOrder);
                    }
                }
                postOrder.Add(node.val);
            }

        }

    }
}
