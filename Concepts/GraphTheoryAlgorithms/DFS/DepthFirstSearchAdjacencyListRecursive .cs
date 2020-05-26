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
    }
}
