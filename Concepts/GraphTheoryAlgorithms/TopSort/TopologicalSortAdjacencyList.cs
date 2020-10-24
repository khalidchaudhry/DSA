using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryAlgorithms.TopSort
{
    public class TopologicalSortAdjacencyList
    {



        public static void TopologicalSortAdjacencyListMain()
        {

            //Graph setup
            int N = 7;
            Dictionary<int, List<TopSort.Edge>> graph = new Dictionary<int, List<TopSort.Edge>>();
            for (int i = 0; i < N; i++)
                graph.Add(i, new List<TopSort.Edge>());


            graph[0].Add(new TopSort.Edge(0, 1, 3));
            graph[0].Add(new TopSort.Edge(0, 2, 2));
            graph[0].Add(new TopSort.Edge(0, 5, 3));
            graph[1].Add(new TopSort.Edge(1, 3, 1));
            graph[1].Add(new TopSort.Edge(1, 2, 6));
            graph[2].Add(new TopSort.Edge(2, 3, 1));
            graph[2].Add(new TopSort.Edge(2, 4, 10));
            graph[3].Add(new TopSort.Edge(3, 4, 5));
            graph[5].Add(new TopSort.Edge(5, 4, 7));

            TopologicalSortAdjacencyList topSort = new TopologicalSortAdjacencyList();


            int[] ordering = topSort.TopologicalSort(graph, N);

            // // Prints: [6, 0, 5, 1, 2, 3, 4]
            Console.WriteLine(string.Join(",", ordering));

            // Finds all the shortest paths starting at node 0
            int[] dists = topSort.DagShortestPath(graph, 0, N);

            // Find the shortest path from 0 to 4 which is 8.0
            Console.WriteLine(dists[4]);

            // Find the shortest path from 0 to 6 which
            // is null since 6 is not reachable!
            Console.WriteLine(dists[6]);




        }

        // Finds a topological ordering of the nodes in a Directed Acyclic Graph (DAG)
        // The input to this function is an adjacency list for a graph and the number
        // of nodes in the graph.
        //
        // NOTE: 'numNodes' is not necessarily the number of nodes currently present
        // in the adjacency list since you can have singleton nodes with no edges which
        // wouldn't be present in the adjacency list but are still part of the graph!
        public int[] TopologicalSort(Dictionary<int, List<Edge>> graph, int numNodes)
        {

            // result we will be returning fron this function 
            int[] ordering = new int[numNodes];
            // Array below tracks wheather the node has been visited or not. 
            bool[] visited = new bool[numNodes];
            //! Associated with ordering array. We insert elements backwords that is why i starts at numNodes-1
            int i = numNodes - 1;
            // !variable "at" below  tracks the node we are currently processing. 
            for (int at = 0; at < numNodes; at++)
                // Pickup an unvisited node. 
                if (!visited[at])
                {
                    // Beginning with the selected node, do a DFS exploring only univisted nodes 
                    //! DFS returns the next valid insertion poistion in the ordering array
                    i = DFS(i, at, visited, ordering, graph);
                }
            return ordering;
        }
        /// <summary>
        //For a general weighted graph, we can calculate single source shortest distances in O(VE) time using Bellman–Ford Algorithm. 
        //For no negative weights graph, we can do better and calculate single source shortest distances in O(E + VLogV) time using Dijkstra’s algorithm.
        //Can we do even better for Directed Acyclic Graph (DAG)? We can calculate single source shortest distances in O(V+E) time for DAGs. 
        //The idea is to use Topological Sorting.
        //A useful application of the topological sort is to find the shortest path
        //between two nodes in a Directed Acyclic Graph (DAG). Given an adjacency list
        //this method finds the shortest path to all nodes starting at 'start'

        //We initialize distances to all vertices as -1  and distance to source as 0, then we find a topological sorting of the graph.
        //Once we have topological order (or linear representation), we one by one process all vertices in topological order. 
        //For every vertex being processed, we update distances of its adjacent using distance of current vertex.

        /// </summary>
        /// <param name="graph">
        /// As adjacency list
        /// </param>
        /// <param name="start"></param>
        /// <param name="numNodes"></param>
        /// <returns></returns>

        public int[] DagShortestPath(Dictionary<int, List<Edge>> graph, int start, int numNodes)
        {

            //! Find toplogical ordering for the graph
            int[] topsort = TopologicalSort(graph, numNodes);
            int[] dist = new int[numNodes];
            // Inialize all the elements with infinity
            dist = Enumerable.Repeat(int.MaxValue, numNodes).ToArray();
            //! distance of node to itself is 0
            dist[start] = 0;

            for (int i = 0; i < numNodes; i++)
            {
                int nodeIndex = topsort[i];
                // get all the edges of the node from graph
                List<Edge> adjacentEdges = graph[nodeIndex];
                if (adjacentEdges.Count != 0)
                {
                    foreach (Edge edge in adjacentEdges)
                    {
                        //dist[nodeIndex] =node distance we are currently at
                        int newDist = dist[nodeIndex] + edge.weight;
                        // !relaxation step                        
                        if (dist[edge.to] == int.MaxValue) //! has ever been distance set for this node. if no then set it  
                        {
                            dist[edge.to] = newDist;
                        }
                        else //! if distance has already been set for this node than take min of existing distance and our new distance 
                        {
                            //! Take minimum distance of where we want to go or newDistance
                            dist[edge.to] = Math.Min(dist[edge.to], newDist);
                        }
                    }
                }
            }

            return dist;
        }


        /// <summary>
        //Helper method that performs a depth first search on the graph to give
        // us the topological ordering we want. Instead of maintaining a stack
        // of the nodes we see we simply place them inside the ordering array
        // in reverse order for simplicity.
        /// </summary>
        /// <param name="i">
        //!Index for ordering array
        /// </param>
        /// <param name="at">
        //
        /// </param>
        /// <param name="visited">
        //
        /// </param>
        /// <param name="ordering">
        //
        /// </param>
        /// <param name="graph">
        //
        /// </param>
        /// <returns>
        //!next valid insertion position in the ordering array. 
        /// </returns>

        private int DFS(
            int i,
            int at,
            bool[] visited,
            int[] ordering,
            Dictionary<int, List<Edge>> graph)
        {
            //! mark the node that we are currently at tobe visited. 
            visited[at] = true;
            //For each edge going outward the node we are at 
            List<Edge> edges = graph[at];

            if (edges.Count != 0)
            {
                foreach (Edge edge in edges)
                {
                    //! make sure that destination node is unvisited
                    if (!visited[edge.to])
                    {
                        // !Call the DFS but this time on destination node
                        i = DFS(i, edge.to, visited, ordering, graph);
                    }
                }
            }
            // !Inserting the node index directly inside the ordering array
            //! On the callback when the method returns this is the When we stuck in DFS and we need to backtrack. 
            //!The is where we store the current node in ordering array at index i               
            ordering[i] = at;
            // !index of the current insertion position is no longer index i as we already set index i in above line so it will be i-1
            return i - 1;
        }

    }

    // Helper Edge class to describe edges in the graph
    public class Edge
    {
        public int from, to, weight;

        public Edge(int f, int t, int w)
        {
            from = f;
            to = t;
            weight = w;
        }
    }
}
