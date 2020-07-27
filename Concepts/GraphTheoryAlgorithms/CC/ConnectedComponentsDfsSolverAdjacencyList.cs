using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryAlgorithms.CC
{
    public class ConnectedComponentsDfsSolverAdjacencyList
    {
        private int n; // number of nodes in the graph
        private int componentCount; // number of connected components 
        private int[] components;  //empty integer array # size n representing node belongs to which component
        private bool solved;
        private bool[] visited; // size n
        private List<List<int>> graph;


        public static void ConnectedComponentsDfsSolverAdjacencyListMain()
        {
            /*****************************************************************************/
            // ConnectedComponents Dfs Solver using Adjacency List
            /*****************************************************************************/

            int n = 11;
            List<List<int>> graph = CreateGraph(n);

            // Setup a graph with five connected components:
            // {0,1,7}, {2,5}, {4,8}, {3,6,9}, {10}
            AddUnDirectedEdge(graph, 0, 1);
            AddUnDirectedEdge(graph, 1, 7);
            AddUnDirectedEdge(graph, 7, 0);
            AddUnDirectedEdge(graph, 2, 5);
            AddUnDirectedEdge(graph, 4, 8);
            AddUnDirectedEdge(graph, 3, 6);
            AddUnDirectedEdge(graph, 6, 9);

            ConnectedComponentsDfsSolverAdjacencyList solver;
            solver = new ConnectedComponentsDfsSolverAdjacencyList(graph);
            int count = solver.CountComponents();
            Console.WriteLine($"Number of components: {count}");

            int[] components = solver.GetComponents();
            for (int i = 0; i < n; i++)
                Console.WriteLine($"Node {i} is part of component {components[i]}");

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
        }



        public ConnectedComponentsDfsSolverAdjacencyList(List<List<int>> graph)
        {
            if (graph == null) throw new ArgumentNullException();
            this.n = graph.Capacity;
            this.graph = graph;
        }
        public int[] GetComponents()
        {
            Solve();
            return components;
        }

        public int CountComponents()
        {
            Solve();
            return componentCount;
        }

        private void Solve()
        {
            if (solved) return;

            visited = new bool[n];
            components = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    componentCount++;
                    DFS(i);
                }
            }

            solved = true;
        }

        private void DFS(int at)
        {
            visited[at] = true;
            components[at] = componentCount;
            foreach (int to in graph[at])
                if (!visited[to])
                    DFS(to);
        }

        public static void AddUnDirectedEdge(List<List<int>> graph, int from, int to)
        {
            graph[from].Add(to);
            graph[to].Add(from);
        }

        // Initialize an empty adjacency list that can hold up to n nodes.
        private static List<List<int>> CreateGraph(int n)
        {
            List<List<int>> graph = new List<List<int>>(n);
            for (int i = 0; i < n; i++)
                graph.Add(new List<int>());
            return graph;
        }
    }
}
