using GraphTheoryAlgorithms.BFS;
using GraphTheoryAlgorithms.CC;
using GraphTheoryAlgorithms.DFS;
using GraphTheoryAlgorithms.RootingTree;
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

            /*****************************************************************************/
            // Depth First Search
            /*****************************************************************************/
            // Create a fully connected graph
            //           (0)
            //           / \
            //        5 /   \ 4
            //         /     \
            // 10     <   -2  >
            //   +->(2)<------(1)      (4)
            //   +--- \       /
            //         \     /
            //        1 \   / 6
            //           > <
            //           (3)

            //int numNodes = 5;
            //Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();
            //AddDirectedEdge(graph, 0, 1, 4);
            //AddDirectedEdge(graph, 0, 2, 5);
            //AddDirectedEdge(graph, 1, 2, -2);
            //AddDirectedEdge(graph, 1, 3, 6);
            //AddDirectedEdge(graph, 2, 3, 1);
            //AddDirectedEdge(graph, 2, 2, 10); // Self loop

            //DepthFirstSearchAdjacencyListRecursive dfs = new DepthFirstSearchAdjacencyListRecursive();

            //var nodeCount = dfs.DFS(0, new bool[numNodes], graph);
            //Console.WriteLine($"DFS node count starting at node 0:{nodeCount}");
            //if (nodeCount != 4)
            //{
            //    Console.WriteLine("Error with DFS");
            //}

            //nodeCount = dfs.DFS(4, new bool[numNodes], graph);
            //Console.WriteLine($"DFS node count starting at node 4:{nodeCount} ");

            //if (nodeCount != 1)
            //{
            //    Console.WriteLine("Error with DFS");
            //}

            /*****************************************************************************/
            // Connected components using Depth First Search
            /*****************************************************************************/

            //int n = 11;
            //Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();

            //// Setup a graph with five connected components:
            //// {0,1,7}, {2,5}, {4,8}, {3,6,9}, {10}
            //AddUnDirectedEdge(graph, 0, 1, 0);
            //AddUnDirectedEdge(graph, 1, 7, 0);
            //AddUnDirectedEdge(graph, 7, 0, 0);
            //AddUnDirectedEdge(graph, 2, 5, 0);
            //AddUnDirectedEdge(graph, 4, 8, 0);
            //AddUnDirectedEdge(graph, 3, 6, 0);
            //AddUnDirectedEdge(graph, 6, 9, 0);

            //ConnectedComponents cc = new ConnectedComponents(n, graph);

            //var result = cc.FindComponents();
            //Console.WriteLine($"Number of components:{result.Item1}");

            //int[] components = result.Item2;
            //for (int i = 0; i < n; i++)
            //    Console.WriteLine($"Node {i} is part of component { components[i]}");


            /*****************************************************************************/
            // ConnectedComponents Dfs Solver using Adjacency List
            /*****************************************************************************/

            //int n = 11;
            //List<List<int>> graph = CreateGraph(n);

            //// Setup a graph with five connected components:
            //// {0,1,7}, {2,5}, {4,8}, {3,6,9}, {10}
            //AddUnDirectedEdge(graph, 0, 1);
            //AddUnDirectedEdge(graph, 1, 7);
            //AddUnDirectedEdge(graph, 7, 0);
            //AddUnDirectedEdge(graph, 2, 5);
            //AddUnDirectedEdge(graph, 4, 8);
            //AddUnDirectedEdge(graph, 3, 6);
            //AddUnDirectedEdge(graph, 6, 9);

            //ConnectedComponentsDfsSolverAdjacencyList solver;
            //solver = new ConnectedComponentsDfsSolverAdjacencyList(graph);
            //int count = solver.CountComponents();
            //Console.WriteLine($"Number of components: {count}");

            //int[] components = solver.GetComponents();
            //for (int i = 0; i < n; i++)
            //    Console.WriteLine($"Node {i} is part of component {components[i]}");

            // Prints:
            // Number of components: 5
            // Node 0 is part of component 1
            // Node 1 is part of component 1
            // Node 2 is part of component 2
            // Node 3 is part of component 3
            // Node 4 is part of component 4
            // Node 5 is part of component 2
            // Node 6 is part of component 3
            // Node 7 is part of component 1
            // Node 8 is part of component 4
            // Node 9 is part of component 3
            // Node 10 is part of component 5

            /*****************************************************************************/
            //Breadth First Search Adjacency List Iterative 
            /*****************************************************************************/
            // BFS example #1 from slides.
            //int n = 13;
            //List<List<Edge>> graph = CreateEmptyGraph(n);

            //AddUnWeightedUnDirectedEdge(graph, 0, 7);
            //AddUnWeightedUnDirectedEdge(graph, 0, 9);
            //AddUnWeightedUnDirectedEdge(graph, 0, 11);
            //AddUnWeightedUnDirectedEdge(graph, 7, 11);
            //AddUnWeightedUnDirectedEdge(graph, 7, 6);
            //AddUnWeightedUnDirectedEdge(graph, 7, 3);
            //AddUnWeightedUnDirectedEdge(graph, 6, 5);
            //AddUnWeightedUnDirectedEdge(graph, 3, 4);
            //AddUnWeightedUnDirectedEdge(graph, 2, 3);
            //AddUnWeightedUnDirectedEdge(graph, 2, 12);
            //AddUnWeightedUnDirectedEdge(graph, 12, 8);
            //AddUnWeightedUnDirectedEdge(graph, 8, 1);
            //AddUnWeightedUnDirectedEdge(graph, 1, 10);
            //AddUnWeightedUnDirectedEdge(graph, 10, 9);
            //AddUnWeightedUnDirectedEdge(graph, 9, 8);

            //BreadthFirstSearchAdjacencyListIterative solver;
            //solver = new BreadthFirstSearchAdjacencyListIterative(graph);

            //int start = 10, end = 5;
            //List<int> path = solver.ReconstructPath(start, end);
            //Console.WriteLine($"The shortest path from {start} to {end} is: {FormatPath(path)}");
            // Prints:
            // The shortest path from 10 to 5 is: [10 -> 9 -> 0 -> 7 -> 6 -> 5]

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

            List<List<int>> graph = CreateEmptyTree(9);
            AddUnDirectedEdge(graph, 0, 1);
            AddUnDirectedEdge(graph, 2, 1);
            AddUnDirectedEdge(graph, 2, 3);
            AddUnDirectedEdge(graph, 3, 4);
            AddUnDirectedEdge(graph, 5, 3);
            AddUnDirectedEdge(graph, 2, 6);
            AddUnDirectedEdge(graph, 6, 7);
            AddUnDirectedEdge(graph, 6, 8);

            // Centers are 2
            var treeCenter=TreeCenter.TreeCenter.FindTreeCenters(graph);
            Console.WriteLine(string.Join(",", $"[{string.Join(",", treeCenter)}]"));
            
            Console.ReadKey();
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
