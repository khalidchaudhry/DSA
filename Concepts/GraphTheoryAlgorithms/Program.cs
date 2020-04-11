using GraphTheoryAlgorithms.DFS;
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

            Console.ReadKey();
        }

        // Helper method to setup graph
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
    }
}
