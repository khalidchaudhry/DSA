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

        public static void BreadthFirstSearchAdjacencyListIterativeMain()
        {
            /*****************************************************************************/
            //Breadth First Search Adjacency List Iterative 
            /*****************************************************************************/
            // BFS example #1 from slides.
            int n = 13;
            List<List<Edge>> graph = CreateEmptyGraph(n);

            AddUnWeightedUnDirectedEdge(graph, 0, 7);
            AddUnWeightedUnDirectedEdge(graph, 0, 9);
            AddUnWeightedUnDirectedEdge(graph, 0, 11);
            AddUnWeightedUnDirectedEdge(graph, 7, 11);
            AddUnWeightedUnDirectedEdge(graph, 7, 6);
            AddUnWeightedUnDirectedEdge(graph, 7, 3);
            AddUnWeightedUnDirectedEdge(graph, 6, 5);
            AddUnWeightedUnDirectedEdge(graph, 3, 4);
            AddUnWeightedUnDirectedEdge(graph, 2, 3);
            AddUnWeightedUnDirectedEdge(graph, 2, 12);
            AddUnWeightedUnDirectedEdge(graph, 12, 8);
            AddUnWeightedUnDirectedEdge(graph, 8, 1);
            AddUnWeightedUnDirectedEdge(graph, 1, 10);
            AddUnWeightedUnDirectedEdge(graph, 10, 9);
            AddUnWeightedUnDirectedEdge(graph, 9, 8);

            BreadthFirstSearchAdjacencyListIterative solver;
            solver = new BreadthFirstSearchAdjacencyListIterative(graph);

            int start = 10, end = 5;
            List<int> path = solver.ReconstructPath(start, end);
            Console.WriteLine($"The shortest path from {start} to {end} is: {FormatPath(path)}");
            // Prints:
            // The shortest path from 10 to 5 is: [10 -> 9 -> 0 -> 7 -> 6 -> 5]

        }
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
            //! incase path does not exist between nodes return empty path. 
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
        public static List<List<Edge>> CreateEmptyGraph(int n)
        {
            List<List<Edge>> graph = new List<List<Edge>>(n);
            for (int i = 0; i < n; i++)
                graph.Add(new List<Edge>());

            return graph;
        }
        private static void AddUnWeightedUnDirectedEdge(List<List<Edge>> graph, int u, int v)
        {
            AddUnDirectedEdge(graph, u, v, 1);
        }

        // Add an undirected edge between nodes 'u' and 'v'.
        private static void AddUnDirectedEdge(List<List<Edge>> graph, int u, int v, int cost)
        {
            AddDirectedEdge(graph, u, v, cost);
            AddDirectedEdge(graph, v, u, cost);
        }
        // Add a directed edge from node 'u' to node 'v' with cost 'cost'.
        private static void AddDirectedEdge(List<List<Edge>> graph, int u, int v, int cost)
        {
            graph[u].Add(new Edge(u, v, cost));
        }
        private static string FormatPath(List<int> path)
        {
            return string.Join(" -> ", path);
        }
    }
}
