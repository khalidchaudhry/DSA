using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryAlgorithms.BellmanFord
{

    /// <summary> 
    /// https://github.com/williamfiset/Algorithms/blob/master/src/main/java/com/williamfiset/algorithms/graphtheory/BellmanFordAdjacencyList.java 
    /// </summary>
    public class BellmanFordAdjacencyList
    {
        /**
        * An implementation of the Bellman-Ford algorithm. The algorithm finds the shortest path between
        * a starting node and all other nodes in the graph. The algorithm also detects negative cycles.
        * If a node is part of a negative cycle then the minimum cost for that node is set to
        * Double.NEGATIVE_INFINITY.
        *
        * @param graph - An adjacency list containing directed edges forming the graph
        * @param V - The number of vertices in the graph.
        * @param start - The id of the starting node
        */
        public static double[] BellmanFord(List<Edge>[] graph, int V, int start)
        {

            
            
            double[] dist = new double[V];
            //! Initialize the distance to all nodes to be infinity
            dist = Enumerable.Repeat(double.MaxValue, V).ToArray();
            // !except for the start node which is zero.
            dist[start] = 0;

            //!For each vertex, apply relaxation for all the edges
            //!Relax each edge V-1 times:
            for (int i = 0; i < V - 1; i++)
            {
                foreach (List<Edge> edges in graph)
                {
                    foreach (Edge edge in edges)
                        if (dist[edge.from] + edge.cost < dist[edge.to])
                        {
                            dist[edge.to] = dist[edge.from] + edge.cost;
                        }
                }
            }
            // Run algorithm a second time to detect which nodes are part
            // of a negative cycle. A negative cycle has occurred if we
            // can find a better path beyond the optimal solution.
            for (int i = 0; i < V - 1; i++)
            {
                foreach (List<Edge> edges in graph)
                {
                    foreach (Edge edge in edges)
                    {
                        if (dist[edge.from] + edge.cost < dist[edge.to])
                        {
                            dist[edge.to] = double.MinValue;
                        }
                    }
                }
            }
            // Return the array containing the shortest distance to every node
            return dist;
        }


        // Create a graph with V vertices
        public static List<Edge>[] CreateGraph(int V)
        {
            List<Edge>[] graph = new List<Edge>[V];

            for (int i = 0; i < V; i++)
                graph[i] = new List<Edge>();

            return graph;
        }
        // Helper function to add an edge to the graph
        public static void AddEdge(List<Edge>[] graph, int from, int to, double cost)
        {
            graph[from].Add(new Edge(from, to, cost));
        }
    }

    // A directed edge with a cost
    public class Edge
    {
        public double cost;
        public int from, to;

        public Edge(int from, int to, double cost)
        {
            this.to = to;
            this.from = from;
            this.cost = cost;
        }
    }
}
