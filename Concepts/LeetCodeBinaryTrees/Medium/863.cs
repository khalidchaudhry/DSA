using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _863
    {
        /// <summary>
        //!https://www.youtube.com/watch?v=nPtARJ2cYrg 
        /// </summary>
        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
           
            Dictionary<TreeNode, List<TreeNode>> graph = new Dictionary<TreeNode, List<TreeNode>>();
            //! First step is to convert the binary tree into graph
            BuildGraph(root, null, graph);

            Queue<(TreeNode node, int level)> queue = new Queue<(TreeNode node, int level)>();
            HashSet<TreeNode> visited = new HashSet<TreeNode>();
            foreach (var keyValue in graph)
            {
                if (keyValue.Key == target)
                {
                    queue.Enqueue((keyValue.Key, 0));
                    visited.Add(keyValue.Key);
                    break;
                }
            }

            List<int> distanceK = new List<int>();
            while (queue.Count != 0)
            {
                (TreeNode currNode, int currLevel) = queue.Dequeue();
                if (currLevel == k)
                {
                    distanceK.Add(currNode.val);
                }
                foreach (TreeNode children in graph[currNode])
                {
                    //! || currLevel + 1 > k is an optimization. So if currentLevel+1 >k there is no point going forward
                    if (children == null || visited.Contains(children) || currLevel + 1 > k)
                    {
                        continue;
                    }
                    visited.Add(children);
                    queue.Enqueue((children, currLevel + 1));
                }
            }
            return distanceK;
        }

        private void BuildGraph(TreeNode node, TreeNode parent, Dictionary<TreeNode, List<TreeNode>> graph)
        {
            if (node == null)
            {
                return;
            }
            if (!graph.ContainsKey(node))
            {
                graph.Add(node, new List<TreeNode>());
            }
            graph[node].Add(parent);
            if (node.left != null)
            {
                graph[node].Add(node.left);
            }
            if (node.right != null)
            {
                graph[node].Add(node.right);
            }

            BuildGraph(node.left, node, graph);
            BuildGraph(node.right, node, graph);
        }


    }
}
