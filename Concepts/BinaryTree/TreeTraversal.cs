using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class TreeTraversal
    {
        public static void PrintAllLeafPathsInBinaryTree(Node n,Stack<int> stk)
        {
            if (n == null)
                return;
            
            stk.Push(n.data);
            PrintAllLeafPathsInBinaryTree(n.left,stk);
            if (n.left == null && n.right == null)
            {
                foreach (var data in stk)
                {
                    Console.Write($"{data}-->");
                }
            }
            PrintAllLeafPathsInBinaryTree(n.right,stk);
            Console.WriteLine();
            stk.Pop();
        }

        public static void PrintNthPreOrderElement(Node n, int index, int[] count)
        {
            if (n != null)
            {
                count[0]++;
                if (index == count[0])
                {
                    Console.WriteLine($"{index} node Data:{n.data}");                
                }
                PrintNthPreOrderElement(n.left,index,count);
                PrintNthPreOrderElement(n.right, index, count);
            }       
        }

        public static void PrintNthInOrderElement(Node n, int index, int[] count)
        {
            if (n != null)
            {
                PrintNthPreOrderElement(n.left, index, count);
                count[0]++;
                if (index == count[0])
                {
                    Console.WriteLine($"{index} node Data:{n.data}");
                }
              
                PrintNthPreOrderElement(n.right, index, count);
            }
        }

        public static void PrintNthPostOrderElement(Node n, int index, int[] count)
        {
            if (n != null)
            {
                PrintNthPreOrderElement(n.left, index, count);     
                PrintNthPreOrderElement(n.right, index, count);
                count[0]++;
                if (index == count[0])
                {
                    Console.WriteLine($"{index} node Data:{n.data}");
                }
            }
        }

        public static void PrintInSpiralOrder(Node n)
        {
            var stk1 = new Stack<Node>();
            var stk2 = new Stack<Node>();
            if (n != null)
                stk1.Push(n);
            while (stk1.Count != 0 || stk2.Count != 0)
            {
                while (stk1.Count != 0)
                {
                    var poppedNode = stk1.Pop();
                    Console.Write($" {poppedNode.data}");

                    if (poppedNode.right != null)
                    {
                        stk2.Push(poppedNode.right);
                    }
                    if (poppedNode.left != null)
                    {
                        stk2.Push(poppedNode.left);
                    }
                }
                Console.WriteLine();
                while (stk2.Count != 0)
                {
                    var poppedNode = stk2.Pop();
                    Console.Write($" {poppedNode.data}");

                    if (poppedNode.left != null)
                    {
                        stk1.Push(poppedNode.left);
                    }
                    if (poppedNode.right != null)
                    {
                        stk1.Push(poppedNode.right);
                    }
                }
                Console.WriteLine();
            }
        }

        public static void PrintLevelOrderLineByLine(Node n)
        {
            var q1 = new Queue<Node>();
            var q2 = new Queue<Node>();
            if (n != null)
                q1.Enqueue(n);
            while (q1.Count != 0 || q2.Count != 0)
            {


                while (q1.Count != 0)
                {
                    var dequeue = q1.Dequeue();
                    Console.Write($" {dequeue.data}");
                    if (dequeue.left != null)
                    {
                        q2.Enqueue(dequeue.left);
                    }
                    if (dequeue.right != null)
                    {
                        q2.Enqueue(dequeue.right);
                    }
                }
                Console.WriteLine();

                while (q2.Count != 0)
                {
                    var dequeue = q2.Dequeue();
                    Console.Write($" {dequeue.data}");
                    if (dequeue.left != null)
                    {
                        q1.Enqueue(dequeue.left);
                    }
                    if (dequeue.right != null)
                    {
                        q1.Enqueue(dequeue.right);
                    }
                }
                Console.WriteLine();
            }
        }

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
        public static void InOrderTreeTraversal(Node n)
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
