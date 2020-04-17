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

    }
}
