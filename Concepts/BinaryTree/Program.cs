using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        // Function to print tree 
        // nodes in InOrder fashion 
        public void inOrder(Node root)
        {
            if (root != null)
            {
                inOrder(root.left);
                Console.Write(root.data + " ");
                inOrder(root.right);
            }
        }

        // Driver code 
        public static void Main(String[] args)
        {
            //Tree t2 = new Tree();
            int[] arr = { 10, 5, 2, 7, 15, 12, 20 };
            //Tree t = Tree.CreateSimpleTree();
            //Console.WriteLine("Inorder traversal");
            //TreeTraversal.InOrderTreeTraversal(t.root);
            //Console.WriteLine("Preorder traversal");
            //TreeTraversal.PreOrderTreeTraversal(t.root);
            //Console.WriteLine("PostOrder traversal");
            //TreeTraversal.PostOrderTreeTraversal(t.root);
            //t2.root = t2.insertLevelOrder(arr, t2.root, 0);
            //t2.inOrder(t2.root);
            var node=new PreorderToTree().ConstructTree(arr);

            // Breadth First traversal
            //TreeTraversal.PrintBreadthFirst(node);

            // Depth First using Stack 
            TreeTraversal.PrintDepthFirst(node);


            //Console.WriteLine("Inorder traversal");
            //TreeTraversal.InOrderTreeTraversal(node);

            Console.ReadLine();
        }     
    }
}
