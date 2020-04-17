using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryAlgorithms.BFS
{

    /**
 * An implementation of BFS with an adjacency list.
 *
 * <p>Time Complexity: O(V + E) 
 */
    class BreadthFirstSearchAdjacencyListIterative
    {
        private int n;
        private int[] prev;
        private List<List<Edge>> graph;

        public BreadthFirstSearchAdjacencyListIterative(List<List<Edge>> graph)
        {
            if (graph == null) throw new ArgumentNullException("Graph cannot be null");
            n = graph.Capacity;
            this.graph = graph;
        }
        /**
        * Reconstructs the path (of nodes) from 'start' to 'end' inclusive. If the edges are unweighted
        * then this method returns the shortest path from 'start' to 'end'
        *
        * @return An array of nodes indexes of the shortest path from 'start' to 'end'. If 'start' and
        *     'end' are not connected then an empty array is returned.
        */
        public List<int> ReconstructPath(int start, int end)
        {
            BFS(start);
            List<int> path = new List<int>();
            for (int at = end; at != -1; at = prev[at])
                path.Add(at);
            
            path.Reverse();
            if (path[0] == start)
                return path;
            path.Clear();
            return path;
        }

        // Perform a breadth first search on a graph a starting node 'start'.
        private void BFS(int start)
        {
            prev= Enumerable.Repeat(-1, n).ToArray();

            bool[] visited = new bool[n];
            

            Queue<int> queue = new Queue<int>();
                       
            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count != 0)
            {
                int dequeue = queue.Dequeue();

                List<Edge> edges = graph[dequeue];

                // Loop through all edges attached to this node. Mark nodes as visited once they're
                // in the queue. This will prevent having duplicate nodes in the queue and speedup the BFS.
                foreach (Edge edge in edges)
                {
                    if (!visited[edge.to])
                    {
                        queue.Enqueue(edge.to);
                        visited[edge.to] = true;
                        prev[edge.to] = dequeue;
                    }
                }
            }
        }
    }
}
