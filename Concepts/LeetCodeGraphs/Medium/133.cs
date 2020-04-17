using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _133
    {
        public Node CloneGraph(Node node)
        {

            if (node == null)
            {
                return node;
            }

            // Hash map to save the visited node and it's respective clone
            // as key and value respectively. This helps to avoid cycles.
            Dictionary<Node, Node> visited = new Dictionary<Node, Node>();

            // BFS 
            Queue<Node> queue = new Queue<Node>();
            // Put the first node in the queue
            queue.Enqueue(node);
            // Clone the node and put it in the visited dictionary.
            visited.Add(node, new Node(node.val));
            // Start BFS traversal
            while (queue.Count != 0)
            {
                // Pop a node say "n" from the from the front of the queue.
                Node n = queue.Dequeue();
                IList<Node> neighbours = n.neighbors;
                // Iterate through all the neighbors of the node "n"
                foreach (var neighbour in neighbours)
                {
                    if (!visited.ContainsKey(neighbour))
                    {  
                        // Add the clone of the neighbor to the neighbors of the clone node "n".
                        visited.Add(neighbour, new Node(neighbour.val));
                        // Add the newly encountered node to the queue.
                        queue.Enqueue(neighbour);
                    }
                    // Add the clone of the neighbor to the neighbors of the clone node "n".
                    visited[n].neighbors.Add(visited[neighbour]);
                }
            }
            // Return the clone of the node from visited.
            return visited[node];
        }
    }

    // Definition for a Node.
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}
