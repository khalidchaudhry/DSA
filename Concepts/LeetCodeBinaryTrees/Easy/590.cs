using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _590
    {
        public IList<int> Postorder(Node root)
        {
            List<int> postOrder = new List<int>();

            PostOrderHelper(root,postOrder);

            return postOrder;
        }
        private void PostOrderHelper(Node node,List<int> postOrder)
        {
            if (node != null)
            {
                if (node.children != null)
                {
                    foreach (var child in node.children)
                    {
                        PostOrderHelper(child,postOrder);
                    }
                }
                postOrder.Add(node.val);
            }

        }

    }
}
