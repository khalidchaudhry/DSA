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

        public static void TopologicalSortAdjacencyMatrixMain()
        {

            int N = 7;

            double[][] adjMatrix = new double[N][];
            // initiliaze every jagged array with an array and all its values as MaxValue
            for (int i = 0; i < N; i++)
            {
                adjMatrix[i] = new double[N];
                adjMatrix[i] = Enumerable.Repeat(double.MaxValue, N).ToArray();
            }

            adjMatrix[0][1] = 3.0;
            adjMatrix[0][2] = 2.0;
            adjMatrix[0][5] = 3.0;

            adjMatrix[1][3] = 1.0;
            adjMatrix[1][2] = 6.0;

            adjMatrix[2][3] = 1.0;
            adjMatrix[2][4] = 10.0;

            adjMatrix[3][4] = 5.0;

            adjMatrix[5][4] = 7.0;

            adjMatrix[1][3] = 1.0;


            int[] ordering = new TopologicalSortAdjacencyMatrix().TopologicalSort(adjMatrix);

            // Prints: [6, 0, 5, 1, 2, 3, 4]
            Console.WriteLine(string.Join(",", ordering));

            // Find the shortest path from 0 to all other nodes
            double[] dists = new TopologicalSortAdjacencyMatrix().DagShortestPath(adjMatrix, 0);

            // Find the distance from 0 to 4 which is 8.0
            Console.WriteLine(dists[4]);

            // Finds the shortest path from 0 to 6
            // prints Infinity (6 is not reachable!)
            Console.WriteLine(dists[6]);

        }



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
