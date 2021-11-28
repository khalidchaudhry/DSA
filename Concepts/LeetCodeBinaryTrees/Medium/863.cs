using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeBinaryTrees.Medium
{
    public class _863
    {
        /// <summary>
        //!https://www.youtube.com/watch?v=nPtARJ2cYrg 
        //! Time complexity=O(V+3) where V is the number of nodes in the graph and 3 are the maximum edges we can have from a node 
        //! Space Complexity=O(V) 
        /// </summary>
        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {

            Dictionary<TreeNode, List<TreeNode>> graph = new Dictionary<TreeNode, List<TreeNode>>();
            //! First step is to convert the binary tree into graph
            BuildGraph(root, null, graph);

            List<int> kdistanceNodes = new List<int>();

            Queue<TreeNode> queue = new Queue<TreeNode>();
            HashSet<TreeNode> visited = new HashSet<TreeNode>();
            queue.Enqueue(target);
            visited.Add(target);
            int level = 0;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                while (count > 0)
                {
                    TreeNode curr = queue.Dequeue();
                    //! if we reaches to desired level than no point  explore the neighbors(going to next level) hence if/else 
                    if (level == k)
                    {
                        kdistanceNodes.Add(curr.val);
                    }
                    else
                    {
                        foreach (TreeNode neighbor in graph[curr])
                        {
                            if (neighbor == null || visited.Contains(neighbor))
                            {
                                continue;
                            }
                            visited.Add(neighbor);
                            queue.Enqueue(neighbor);
                        }

                    }
                    --count;
                }
                ++level;
            }
            return kdistanceNodes;
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
