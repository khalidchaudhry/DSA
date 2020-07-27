using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryAlgorithms.CC
{
    class ConnectedComponents
    {
        int n;// number of nodes in the graph
        Dictionary<int, List<Edge>> graph; // adjacency list represnting graph
        int count = 0;  // number of connected components 
        int[] components; //empty integer array # size n representing node belongs to which component
        bool[] visited; // size n

        public static void ConnectedComponentsMain()
        {
            /*****************************************************************************/
            // Connected components using Depth First Search
            /*****************************************************************************/

            int n = 11;
            Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();

            // Setup a graph with five connected components:
            // {0,1,7}, {2,5}, {4,8}, {3,6,9}, {10}
            AddUnDirectedEdge(graph, 0, 1, 0);
            AddUnDirectedEdge(graph, 1, 7, 0);
            AddUnDirectedEdge(graph, 7, 0, 0);
            AddUnDirectedEdge(graph, 2, 5, 0);
            AddUnDirectedEdge(graph, 4, 8, 0);
            AddUnDirectedEdge(graph, 3, 6, 0);
            AddUnDirectedEdge(graph, 6, 9, 0);

            ConnectedComponents cc = new ConnectedComponents(n, graph);

            var result = cc.FindComponents();
            Console.WriteLine($"Number of components:{result.Item1}");

            int[] components = result.Item2;
            for (int i = 0; i < n; i++)
                Console.WriteLine($"Node {i} is part of component { components[i]}");
        }
        public ConnectedComponents(int n, Dictionary<int, List<Edge>> graph)
        {
            this.n = n;
            components = new int[n];
            visited = new bool[n];
            this.graph = graph;
        }
        public Tuple<int,int[]> FindComponents()
        {
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    ++count;
                    DFS(i);
                }
            }

            return new Tuple<int,int[]>(count, components);
        }

        private void DFS(int at)
        {
            if (visited[at])
                return;

            visited[at] = true;
            components[at] =count;
            // Visit all edges adjacent to where we're at
            graph.TryGetValue(at, out List<Edge> neighbours);

            if (neighbours != null)
            {
                foreach (Edge neighbour in neighbours)
                {
                    DFS(neighbour.to);
                }
            }            
        }

        private static void AddUnDirectedEdge(Dictionary<int, List<Edge>> graph, int from, int to, int cost)
        {
            AddDirectedEdge(graph, from, to, cost);
            AddDirectedEdge(graph, to, from, cost);
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

    }
}
