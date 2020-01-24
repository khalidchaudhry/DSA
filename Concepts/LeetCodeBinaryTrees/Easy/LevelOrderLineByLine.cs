using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class LevelOrderLineByLine
    {

        public void PrintLevelOrderLineByLine(TreeNode treeNode)
        {
            if (treeNode == null)
                return;
            Queue<TreeNode> q1 = new Queue<TreeNode>();
            Queue<TreeNode> q2 = new Queue<TreeNode>();
            q1.Enqueue(treeNode);

            while (q1.Count != 0 || q2.Count != 0)
            {
                while (q1.Count != 0)
                {
                    var dequeue = q1.Dequeue();
                    Console.Write($"{dequeue.val} ");
                    if (dequeue.left != null)
                        q2.Enqueue(dequeue.left);

                    if (dequeue.right != null)
                        q2.Enqueue(dequeue.right);
                }

                Console.WriteLine("");

                while (q2.Count != 0)
                {
                    var dequeue2 = q2.Dequeue();

                    Console.Write($"{dequeue2.val} ");
                    if (dequeue2.left != null)
                        q1.Enqueue(dequeue2.left);

                    if (dequeue2.right != null)
                        q1.Enqueue(dequeue2.right);

                }
                Console.WriteLine();
            }          
        }
    }
}

