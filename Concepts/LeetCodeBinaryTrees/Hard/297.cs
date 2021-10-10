using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Hard
{
    public class _297
    {
        public static void _297Main()
        {
            Codec codec = new Codec();
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.right.left = new TreeNode(4);
            root.right.right = new TreeNode(5);

            string serialize = codec.serialize(root);
            codec.deserialize(serialize);
            Console.ReadLine();


        }

    }

    /// <summary>
    ///!  https://www.youtube.com/watch?v=RNYNiMsHU0w
    /// </summary>
    public class Codec
    {
        public string serialize(TreeNode root)
        {
            StringBuilder serialized = new StringBuilder();
            Solve(root, serialized);
            return serialized.ToString();

        }
        private void Solve(TreeNode node, StringBuilder sb)
        {
            if (node == null)
            {
                sb.Append('x');
                return;
            }
            sb.Append(node.val);
            sb.Append(',');
            Solve(node.left, sb);
            sb.Append(',');
            Solve(node.right, sb);
        }
        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            string[] tokens = data.Split(',');

            Queue<string> queue = new Queue<string>();
            for (int i = 0; i < tokens.Length; ++i)
            {
                queue.Enqueue(tokens[i]);
            }

            return Solve(queue);

        }
        private TreeNode Solve(Queue<string> queue)
        {
            string first = queue.Dequeue();
            if (first == "x")
            {
                return null;
            }
            TreeNode root = new TreeNode(Convert.ToInt32(first));
            root.left = Solve(queue);
            root.right = Solve(queue);
            return root;
        }

    }
}
