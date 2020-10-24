using GraphTheoryAlgorithms.BellmanFord;
using GraphTheoryAlgorithms.BFS;
using GraphTheoryAlgorithms.BridgesArticulationPoints;
using GraphTheoryAlgorithms.CC;
using GraphTheoryAlgorithms.DFS;
using GraphTheoryAlgorithms.FloydWarshall;
using GraphTheoryAlgorithms.LazyDijkstra;
using GraphTheoryAlgorithms.RootingTree;
using GraphTheoryAlgorithms.TopSort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            DepthFirstSearchAdjacencyListRecursive.DepthFirstSearchAdjacencyListRecursiveMain();

            //ConnectedComponents.ConnectedComponentsMain();
            //ConnectedComponentsDfsSolverAdjacencyList.ConnectedComponentsDfsSolverAdjacencyListMain();
            //ConnectedComponentsDfsSolverAdjacencyList.ConnectedComponentsDfsSolverAdjacencyListMain();


            //BreadthFirstSearchAdjacencyListIterative.BreadthFirstSearchAdjacencyListIterativeMain();



            /*****************************************************************/
            // Rooting tree
            /*****************************************************************/

            //List<List<int>> graph = CreateGraph(9);
            //AddUnDirectedEdge(graph, 0, 1);
            //AddUnDirectedEdge(graph, 2, 1);
            //AddUnDirectedEdge(graph, 2, 3);
            //AddUnDirectedEdge(graph, 3, 4);
            //AddUnDirectedEdge(graph, 5, 3);
            //AddUnDirectedEdge(graph, 2, 6);
            //AddUnDirectedEdge(graph, 6, 7);
            //AddUnDirectedEdge(graph, 6, 8);

            //// Rooted at 6 the tree should look like:
            ////           6
            ////      2    7     8
            ////    1   3
            ////  0    4 5
            //TreeNode root = RootingTree.RootingTree.RootTree(graph, 6);

            //// Layer 0: [6]
            //Console.WriteLine($"[{root}]");

            //// Layer 1: [2, 7, 8]
            //Console.WriteLine($"[{string.Join(",", root.Children)}]");

            //// Layer 2: [1, 3]
            ////root.Children[0].Children
            //Console.WriteLine($"[{string.Join(",", root.Children[0].Children)}]");

            //// Layer 3: [0], [4, 5]
            //Console.WriteLine(
            //    $"[{string.Join(",", root.Children[0].Children[0].Children)}]" +
            //    $"[{string.Join(",", root.Children[0].Children[1].Children)}]");

            /*****************************************************************/
            // Finding tree center
            /*****************************************************************/

            //List<List<int>> graph = CreateEmptyTree(9);
            //AddUnDirectedEdge(graph, 0, 1);
            //AddUnDirectedEdge(graph, 2, 1);
            //AddUnDirectedEdge(graph, 2, 3);
            //AddUnDirectedEdge(graph, 3, 4);
            //AddUnDirectedEdge(graph, 5, 3);
            //AddUnDirectedEdge(graph, 2, 6);
            //AddUnDirectedEdge(graph, 6, 7);
            //AddUnDirectedEdge(graph, 6, 8);

            //// Centers are 2
            //var treeCenter=TreeCenter.TreeCenter.FindTreeCenters(graph);
            //Console.WriteLine(string.Join(",", $"[{string.Join(",", treeCenter)}]"));

            TopologicalSortAdjacencyList.TopologicalSortAdjacencyListMain();
            TopologicalSortAdjacencyMatrix.TopologicalSortAdjacencyMatrixMain();

            /*****************************************************************************/
            // Dijstra's algorithm
            /*****************************************************************************/
            // Create a fully connected graph
            //           (0)
            //           / \
            //        5 /   \ 4
            //         /     \
            //        < ---2  >
            //     (2)<------(1)      (4)
            //        \       /
            //         \     /
            //        1 \   / 6
            //           > <
            //           (3)

            //DijkstrasShortestPathAdjacencyList2 dijkstra = new DijkstrasShortestPathAdjacencyList2(5);

            //dijkstra.AddEdge(0, 1, 4);
            //dijkstra.AddEdge(0, 2, 5);
            //dijkstra.AddEdge(1, 2, 2);
            //dijkstra.AddEdge(1, 3, 6);
            //dijkstra.AddEdge(2, 3, 1);     


            //var result = dijkstra.ReconstructPath(0, 3);

            // 0->2-3
            //Console.WriteLine(string.Join("->",result));


            /*****************************************************************************/
            // Bellman ford Adjacency matrix algorithm
            ///*****************************************************************************/
            //int n = 9;
            //double[][] graph = new double[n][];

            //// Setup completely disconnected graph with the distance
            //// from a node to itself to be zero.
            //for (int i = 0; i < n; i++)
            //{
            //    graph[i] = new double[n];
            //    graph[i] = Enumerable.Repeat(double.PositiveInfinity, n).ToArray();
            //    graph[i][i] = 0;
            //}


            //graph[0][1] = 1;
            //graph[1][2] = 1;
            //graph[2][4] = 1;
            //graph[4][3] = -3;
            //graph[3][2] = 1;
            //graph[1][5] = 4;
            //graph[1][6] = 4;
            //graph[5][6] = 5;
            //graph[6][7] = 4;
            //graph[5][7] = 3;

            //int start = 0;

            //BellmanFordAdjacencyMatrix solver;
            //solver = new BellmanFordAdjacencyMatrix(start, graph);
            //double[] d = solver.GetShortestPaths();

            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine($"The cost to get from node {start} to {i} is {d[i]}");
            //}

            // Output:
            // The cost to get from node 0 to 0 is 0.00
            // The cost to get from node 0 to 1 is 1.00
            // The cost to get from node 0 to 2 is -Infinity
            // The cost to get from node 0 to 3 is -Infinity
            // The cost to get from node 0 to 4 is -Infinity
            // The cost to get from node 0 to 5 is 5.00
            // The cost to get from node 0 to 6 is 5.00
            // The cost to get from node 0 to 7 is 8.00
            // The cost to get from node 0 to 8 is Infinity


            /*****************************************************************************/
            // Bellman ford Adjacency List algorithm
            /*****************************************************************************/

            //int E = 10, V = 9, start = 0;

            //List<BellmanFord.Edge>[] graph = BellmanFordAdjacencyList.CreateGraph(V);

            //BellmanFordAdjacencyList.AddEdge(graph, 0, 1, 1);
            //BellmanFordAdjacencyList.AddEdge(graph, 1, 2, 1);
            //BellmanFordAdjacencyList.AddEdge(graph, 2, 4, 1);
            //BellmanFordAdjacencyList.AddEdge(graph, 4, 3, -3);
            //BellmanFordAdjacencyList.AddEdge(graph, 3, 2, 1);
            //BellmanFordAdjacencyList.AddEdge(graph, 1, 5, 4);
            //BellmanFordAdjacencyList.AddEdge(graph, 1, 6, 4);
            //BellmanFordAdjacencyList.AddEdge(graph, 5, 6, 5);
            //BellmanFordAdjacencyList.AddEdge(graph, 6, 7, 4);
            //BellmanFordAdjacencyList.AddEdge(graph, 5, 7, 3);

            //double[] d = BellmanFordAdjacencyList.BellmanFord(graph, V, start);

            //for (int i = 0; i < V; i++)
            //{
            //    Console.WriteLine($"The cost to get from node {start} to {i} is {d[i]}");
            //}

            /*****************************************************************************/
            // Floyd Warshall algorithm
            /*****************************************************************************/
            // Construct graph.
            //int n = 7;
            //double[][] m = FloyadWarshalAlgorithm.createGraph(n);

            //// Add some edge values.
            //m[0][1] = 2;
            //m[0][2] = 5;
            //m[0][6] = 10;
            //m[1][2] = 2;
            //m[1][4] = 11;
            //m[2][6] = 2;
            //m[6][5] = 11;
            //m[4][5] = 1;
            //m[5][4] = -2;

            //FloyadWarshalAlgorithm solver = new FloyadWarshalAlgorithm(m);
            //double[][] dist = solver.GetApspMatrix();

            //for (int i = 0; i < n; i++)
            //    for (int j = 0; j < n; j++)
            //        Console.WriteLine($"This shortest path from node {i} to node {j} is {dist[i][j]}");
            //// Prints:
            //// This shortest path from node 0 to node 0 is 0.000
            //// This shortest path from node 0 to node 1 is 2.000
            //// This shortest path from node 0 to node 2 is 4.000
            //// This shortest path from node 0 to node 3 is Infinity
            //// This shortest path from node 0 to node 4 is -Infinity
            //// This shortest path from node 0 to node 5 is -Infinity
            //// This shortest path from node 0 to node 6 is 6.000
            //// This shortest path from node 1 to node 0 is Infinity
            //// This shortest path from node 1 to node 1 is 0.000
            //// This shortest path from node 1 to node 2 is 2.000
            //// This shortest path from node 1 to node 3 is Infinity
            //// ...
            //Console.WriteLine();

            //// Reconstructs the shortest paths from all nodes to every other nodes.
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < n; j++)
            //    {
            //        List<int> path = solver.ReconstructShortestPath(i, j);
            //        String str;
            //        if (path == null)
            //        {
            //            str = "HAS AN infinity NUMBER OF SOLUTIONS! (negative cycle case)";
            //        }
            //        else if (path.Capacity == 0)
            //        {
            //            str = $"DOES NOT EXIST (node {i} doesn't reach node {j})";
            //        }
            //        else
            //        {
            //            str = string.Join("->",path);

            //            str = "is: [" + str + "]";
            //        }

            //        Console.WriteLine($"The shortest path from node {i} to node {j} is {str}");
            //    }
            //}
            // Prints:
            // The shortest path from node 0 to node 0 is: [0]
            // The shortest path from node 0 to node 1 is: [0 -> 1]
            // The shortest path from node 0 to node 2 is: [0 -> 1 -> 2]
            // The shortest path from node 0 to node 3 DOES NOT EXIST (node 0 doesn't reach node 3)
            // The shortest path from node 0 to node 4 HAS AN infinity NUMBER OF SOLUTIONS! (negative cycle case)
            // The shortest path from node 0 to node 5 HAS AN infinity NUMBER OF SOLUTIONS! (negative cycle case)
            // The shortest path from node 0 to node 6 is: [0 -> 1 -> 2 -> 6]
            // The shortest path from node 1 to node 0 DOES NOT EXIST (node 1 doesn't reach node 0)
            // The shortest path from node 1 to node 1 is: [1]
            // The shortest path from node 1 to node 2 is: [1 -> 2]
            // The shortest path from node 1 to node 3 DOES NOT EXIST (node 1 doesn't reach node 3)
            // The shortest path from node 1 to node 4 HAS AN infinity NUMBER OF SOLUTIONS! (negative cycle case)
            // The shortest path from node 1 to node 5 HAS AN infinity NUMBER OF SOLUTIONS! (negative cycle case)
            // The shortest path from node 1 to node 6 is: [1 -> 2 -> 6]
            // The shortest path from node 2 to node 0 DOES NOT EXIST (node 2 doesn't reach node 0)
            //..

            /*****************************************************************************/
            // Find Bridges in graph
            /*****************************************************************************/

            //int n = 4;
            //List<List<int>> graph = CreateGraph(n);

            //AddUnDirectedEdge(graph, 0, 1);
            //AddUnDirectedEdge(graph, 0, 2);
            //AddUnDirectedEdge(graph, 1, 2);
            //AddUnDirectedEdge(graph, 2, 3);
            ////AddUnDirectedEdge(graph, 3, 4);
            ////AddUnDirectedEdge(graph, 2, 5);
            ////AddUnDirectedEdge(graph, 5, 6);
            ////AddUnDirectedEdge(graph, 6, 7);
            ////AddUnDirectedEdge(graph, 7, 8);
            ////AddUnDirectedEdge(graph, 8, 5);

            //BridgesAdjacencyList solver = new BridgesAdjacencyList(graph, n);
            //List<int> bridges = solver.FindBridges();

            //// Prints:
            //// Bridge between nodes: 3 and 4
            //// Bridge between nodes: 2 and 3
            //// Bridge between nodes: 2 and 5
            //for (int i = 0; i < (bridges.Count / 2); i++)
            //{
            //    int node1 = bridges[2 * i];
            //    int node2 = bridges[2 * i + 1];

            //    Console.WriteLine($"Bridge between nodes: {node1} and {node2}");
            //}





            //Console.ReadKey();
        }


        // Create an empty tree as a adjacency list.
        public static List<List<int>> CreateEmptyTree(int n)
        {
            List<List<int>> tree = new List<List<int>>(n);
            for (int i = 0; i < n; i++)
                tree.Add(new List<int>());

            return tree;
        }

        private static string FormatPath(List<int> path)
        {
            return string.Join(" -> ", path);
        }
        // Helper methods to setup graph

        // Initialize an empty adjacency list that can hold up to n nodes.
        private static List<List<int>> CreateGraph(int n)
        {
            List<List<int>> graph = new List<List<int>>(n);
            for (int i = 0; i < n; i++)
                graph.Add(new List<int>());
            return graph;
        }

        // Initialize an empty adjacency list that can hold up to n nodes.
        public static List<List<Edge>> CreateEmptyGraph(int n)
        {
            List<List<Edge>> graph = new List<List<Edge>>(n);
            for (int i = 0; i < n; i++)
                graph.Add(new List<Edge>());

            return graph;
        }

        // Add a directed edge from node 'u' to node 'v' with cost 'cost'.
        private static void AddDirectedEdge(List<List<Edge>> graph, int u, int v, int cost)
        {
            graph[u].Add(new Edge(u, v, cost));
        }

        private static void AddDirectedEdge(Dictionary<int, List<Edge>> graph, int from, int to, int cost)
        {
            graph.TryGetValue(from, out List<Edge> list);
            if (list == null)
            {
                list = new List<Edge>();
                graph[from] = list;
            }
            list.Add(new Edge(from, to, cost));
        }

        // Add an undirected unweighted edge between nodes 'u' and 'v'. The edge added
        // will have a weight of 1 since its intended to be unweighted.
        public static void AddUnWeightedUnDirectedEdge(List<List<Edge>> graph, int u, int v)
        {
            AddUnDirectedEdge(graph, u, v, 1);
        }

        // Add an undirected edge between nodes 'u' and 'v'.
        private static void AddUnDirectedEdge(List<List<Edge>> graph, int u, int v, int cost)
        {
            AddDirectedEdge(graph, u, v, cost);
            AddDirectedEdge(graph, v, u, cost);
        }

        public static void AddUnDirectedEdge(List<List<int>> graph, int from, int to)
        {
            graph[from].Add(to);
            graph[to].Add(from);
        }
        private static void AddUnDirectedEdge(Dictionary<int, List<Edge>> graph, int from, int to, int cost)
        {
            AddDirectedEdge(graph, from, to, cost);
            AddDirectedEdge(graph, to, from, cost);
        }
    }
}
