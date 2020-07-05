using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Easy
{
    class _107
    {
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();

            if (root == null)
                return result;
            Queue<TreeNode> q1 = new Queue<TreeNode>();
            Queue<TreeNode> q2 = new Queue<TreeNode>();
            q1.Enqueue(root);
            List<int> levelElements = new List<int>();

            while (q1.Count != 0 || q2.Count != 0)
            {
                levelElements.Clear();

                while (q1.Count != 0)
                {
                    var dequeue = q1.Dequeue();
                    //Console.Write($"{dequeue.val} ");
                    levelElements.Add(dequeue.val);
                    if (dequeue.left != null)
                        q2.Enqueue(dequeue.left);

                    if (dequeue.right != null)
                        q2.Enqueue(dequeue.right);
                }
                if (levelElements.Count > 0)
                    result.Add(new List<int>(levelElements));

                levelElements.Clear();

                while (q2.Count != 0)
                {
                    var dequeue2 = q2.Dequeue();

                    //Console.Write($"{dequeue2.val} ");
                    levelElements.Add(dequeue2.val);
                    if (dequeue2.left != null)
                        q1.Enqueue(dequeue2.left);

                    if (dequeue2.right != null)
                        q1.Enqueue(dequeue2.right);

                }
                if (levelElements.Count > 0)
                    result.Add(new List<int>(levelElements));
            }
             result.Reverse();

            return result;



        }
        //https://leetcode.com/problems/binary-tree-level-order-traversal-ii/discuss/35089/Java-Solution.-Using-Queue
        //
        public IList<IList<int>> LevelOrderBottom2(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                List<int> lst = new List<int>();
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    TreeNode dequeue = queue.Dequeue();
                    lst.Add(dequeue.val);

                    if (dequeue.left != null)
                    {
                        queue.Enqueue(dequeue.left);
                    }
                    if (dequeue.right != null)
                    {
                        queue.Enqueue(dequeue.right);
                    }
                }
                result.Insert(0, lst);
            }

            return result;
        }
    }
}
