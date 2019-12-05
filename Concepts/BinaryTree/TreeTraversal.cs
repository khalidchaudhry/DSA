using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class TreeTraversal
    {

        public static void PrintDepthFirst(Node n)
        {
            Stack<Node> nodeStack = new Stack<Node>();
            if (n != null)
            {
                nodeStack.Push(n);
            }
            while (nodeStack.Count != 0)
            {
                var poppedNode = nodeStack.Pop();
                Console.WriteLine($"Node data:{poppedNode.data}");

                if (poppedNode.right != null)
                {
                    nodeStack.Push(poppedNode.right);
                }
                if (poppedNode.left != null)
                {
                    nodeStack.Push(poppedNode.left);
                }
                

            }
        }


        //Print Breadth First Traversal
        public static void PrintBreadthFirst(Node n)
        {
            Queue<Node> nodeQueue = new Queue<Node>();
            if (n != null)
            {
                nodeQueue.Enqueue(n);
            }
            while (nodeQueue.Count != 0)
            {
                var dequeueNode = nodeQueue.Dequeue();
                Console.WriteLine($"Node data:{dequeueNode.data}");

                if (dequeueNode.left != null)
                {
                    nodeQueue.Enqueue(dequeueNode.left);
                }
                if (dequeueNode.right != null)
                {
                    nodeQueue.Enqueue(dequeueNode.right);
                }

            }
        }
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
