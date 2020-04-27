using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryAlgorithms.TopSort
{
    /// <summary>
    // This Topological sort takes an adjacency matrix of an acyclic graph and returns an array with the
    // indexes of the nodes in a(non unique) topological order which tells you how to process the nodes in the graph.
    //More precisely from wiki: A topological ordering is a linear ordering of its  vertices such that for every directed edge uv 
    // from vertex u to vertex v, u comes before v in the ordering.
    //! Time Complexity: O(V^2)
    /// </summary>
    public class TopologicalSortAdjacencyMatrix
    {
        // Performs the topological sort and returns the
        // indexes of the nodes in topological order
        public int[] TopologicalSort(double[][] adj)
        {

            // Setup
            int n = adj.Length;
            bool[] visited = new bool[n];
            int[] order = new int[n];
            int index = n - 1;

            // Visit each node
            for (int u = 0; u < n; u++)
            {
                if (!visited[u])
                {
                    index = Visit(adj, visited, order, index, u);
                }
            }
            // Return topological sort
            return order;
        }

        /// A useful application of the topological sort is to find the shortest path
        // between two nodes in a Directed Acyclic Graph (DAG). Given an adjacency matrix
        // with double valued edge weights this method finds the shortest path from
        // a start node to all other nodes in the graph.
        public  double[] DagShortestPath(double[][] adj, int start)
        {
            // Set up array used to maintain minimum distances from start
            int n = adj.Length;
            double[] dist = new double[n];
            
            dist=Enumerable.Repeat(double.MaxValue, n).ToArray();
            dist[start] = 0.0;

            // Process nodes in a topologically sorted order
            foreach (int u in  TopologicalSort(adj))
                for (int v = 0; v < n; v++)
                {
                    if (adj[u][v] != double.MaxValue)
                    {
                        double newDist = dist[u] + adj[u][v];
                        if (newDist < dist[v]) dist[v] = newDist;
                    }
                }

            // Return minimum distance
            return dist;
        }
        private int Visit(double[][] adj, bool[] visited, int[] order, int index, int u)
        {

            if (visited[u])
                return index;

            visited[u] = true;

            // Visit all neighbors
            for (int v = 0; v < adj.Length; v++)
                if (adj[u][v] != double.MaxValue && !visited[v])
                {
                    index = Visit(adj, visited, order, index, v);
                }
            // Place this node at the head of the list
            order[index--] = u;

            return index;
        }


    }
}
