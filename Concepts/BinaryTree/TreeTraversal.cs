using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class TreeTraversal
    {

        // Inorder tree traversal
        public  static void InOrderTreeTraversal(Node n)
        {
            if (n == null)
                return;
            InOrderTreeTraversal(n.left);
            Console.WriteLine($"Data at node:{n.data}");
            InOrderTreeTraversal(n.right);
        }

        public static void PreOrderTreeTraversal(Node n)
        {
            if (n == null)
                return;
            Console.WriteLine($"Data at node:{n.data}");
            PreOrderTreeTraversal(n.left);
            PreOrderTreeTraversal(n.right);
        }
        public static void PostOrderTreeTraversal(Node n)
        {
            if (n == null)
                return;

            PostOrderTreeTraversal(n.left);
            PostOrderTreeTraversal(n.right);
            Console.WriteLine($"Data at node:{n.data}");
        }
    }
}
