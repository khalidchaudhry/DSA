using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryAlgorithms.DFS
{
    /// <summary>
    //!An implementation of a recursive approach to DFS Time Complexity: O(V + E)
    /// </summary>
    public class DepthFirstSearchAdjacencyListRecursive
    {

        public static void DepthFirstSearchAdjacencyListRecursiveMain()
        {

            /*****************************************************************************/
            //Depth First Search
            /*****************************************************************************/
            //Create a fully connected graph
            //           (0)
            //           / \
            //        5 /   \ 4
            //         /     \
            //        10   <-2 >
            //   +->(2) < ---(1)   (4)
            //   + --- \     /
            //         \    /
            //        1 \  / 6
            //          > <
            //          (3)

            int numNodes = 5;
            Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();
            AddDirectedEdge(graph, 0, 1, 4);
            AddDirectedEdge(graph, 0, 2, 5);
            AddDirectedEdge(graph, 1, 2, -2);
            AddDirectedEdge(graph, 1, 3, 6);
            AddDirectedEdge(graph, 2, 3, 1);
            AddDirectedEdge(graph, 2, 2, 10); // Self loop

            DepthFirstSearchAdjacencyListRecursive dfs = new DepthFirstSearchAdjacencyListRecursive();

            var nodeCount = dfs.DFS(0, new bool[numNodes], graph);
            Console.WriteLine($"DFS node count starting at node 0:{nodeCount}");
            if (nodeCount != 4)
            {
                Console.WriteLine("Error with DFS");
            }

            nodeCount = dfs.DFS(4, new bool[numNodes], graph);
            Console.WriteLine($"DFS node count starting at node 4:{nodeCount} ");

            if (nodeCount != 1)
            {
                Console.WriteLine("Error with DFS");
            }
        }

        /// <summary>
        // Perform a depth first search on the graph counting
        // the number of nodes traversed starting at some position
        /// </summary>
        /// <param name="at">
        // Starting node position 
        /// </param>
        /// <param name="visited">
        // Keep for tracking that we don't revisit the same node again
        /// </param>
        /// <param name="graph">
        //
        /// </param>
        /// <returns>
        // Count the nodes in graph
        /// </returns>
        public long DFS(int at, bool[] visited, Dictionary<int, List<Edge>> graph)
        {
            if (visited[at])
                return 0;
            visited[at] = true;

            long count = 1;
            // Visit all edges adjacent to where we're at
            graph.TryGetValue(at, out List<Edge> neighbours);

            if (neighbours != null)
            {
                foreach (Edge neighbour in neighbours)
                {
                    count += DFS(neighbour.to, visited, graph);
                }
            }

            return count;
        }

        private static void AddDirectedEdge(Dictionary<int, List<Edge>> graph, int from, int to, int cost)
        {
            graph.TryGetValue(from, out List<Edge> list);
            if (list == null)
            {
                list = new List<Edge>();
                //! we can add to dictionary using dict[0]=1 or dict.Add(0,1);
                graph[from] = list;
            }
            list.Add(new Edge(from, to, cost));
        }
    }
}
