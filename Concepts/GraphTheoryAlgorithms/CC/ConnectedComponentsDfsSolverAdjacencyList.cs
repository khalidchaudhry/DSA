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
    }
}
