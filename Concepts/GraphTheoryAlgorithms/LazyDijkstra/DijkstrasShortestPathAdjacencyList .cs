using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryAlgorithms.LazyDijkstra
{
    public class DijkstrasShortestPathAdjacencyList
    {
        private int n;
        private double[] dist;
        private int[] prev;
        private List<List<Edge>> graph;

        /**
         * Initialize the solver by providing the graph size and a starting node. Use the {@link #addEdge}
         * method to actually add edges to the graph.
         *
         * @param n - The number of nodes in the graph.
       */
        public DijkstrasShortestPathAdjacencyList(int n)
        {
            this.n = n;
            createEmptyGraph();
        }

        /**
        * Adds a directed edge to the graph.
        *
        * @param from - The index of the node the directed edge starts at.
        * @param to - The index of the node the directed edge end at.
        * @param cost - The cost of the edge.
        */
        public void AddEdge(int from, int to, int cost)
        {
            graph[from].Add(new Edge(from, to, cost));
        }

        // Use {@link #addEdge} method to add edges to the graph and use this method
        // to retrieve the constructed graph.
        public List<List<Edge>> GetGraph()
        {
            return graph;
        }

        /**
         * Reconstructs the shortest path (of nodes) from 'start' to 'end' inclusive.
         *
         * @return An array of nodes indexes of the shortest path from 'start' to 'end'. If 'start' and
         *     'end' are not connected then an empty array is returned.
        */
        public List<int> ReconstructPath(int start, int end)
        {
            double dist = Dijkstra(start, end);
            List<int> path = new List<int>();
            if (dist == double.MaxValue)
                return path;
            for (int at = end; at != int.MaxValue; at = prev[at])
                path.Add(at);

            path.Reverse();
            return path;
        }


        // Run Dijkstra's algorithm on a directed graph to find the shortest path
        // from a starting node to an ending node. If there is no path between the
        // starting node and the destination node the returned value is set to be
        // Double.POSITIVE_INFINITY.
        public double Dijkstra(int start, int end)
        {
            ////Maintain an array of the minimum distance to each node
            dist = new double[n];
            dist = Enumerable.Repeat(double.MaxValue, n).ToArray();
            dist[start] = 0;

            /// Keep a priority queue of the next most promising node to visit.
            PriorityQueue<Node> pq = new PriorityQueue<Node>();
            pq.Enqueue(new Node(start, 0));

            // Array used to track which nodes have already been visited.
            bool[] visited = new bool[n];
            prev = new int[n];
            prev= Enumerable.Repeat(int.MaxValue, n).ToArray();

            while (pq.Count()!=0)
            {
                Node node = pq.Dequeue();
                visited[node.id] = true;

                // We already found a better path before we got to
                // processing this node so we can ignore it.
                if (dist[node.id] < node.value)
                    continue;

                List<Edge> edges = graph[node.id];

                for (int i = 0; i < edges.Count; i++)
                {
                    Edge edge = edges[i];

                    // You cannot get a shorter path by revisiting
                    // a node you have already visited before.
                    if (visited[edge.to])
                        continue;

                    // Relax edge by updating minimum cost if applicable.
                    double newDist = dist[edge.from] + edge.cost;
                    if (newDist < dist[edge.to])
                    {
                        prev[edge.to] = edge.from;
                        dist[edge.to] = newDist;
                        pq.Enqueue(new Node(edge.to, dist[edge.to]));
                    }
                }
                // Once we've visited all the nodes spanning from the end
                // node we know we can return the minimum distance value to
                // the end node because it cannot get any better after this point.
                if (node.id == end)
                    return dist[end];
            }
            // End node is unreachable
            return double.MaxValue;
        }

        // Construct an empty graph with n nodes including the source and sink nodes.
        private void createEmptyGraph()
        {
            graph = new List<List<Edge>>();
            for (int i = 0; i < n; i++)
                graph.Add(new List<Edge>());
        }


    }
}
