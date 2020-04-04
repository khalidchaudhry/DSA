using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GeeksForGeeks.UnionFind
{
    public class Graph
    {
        int V, E;
        public Edge[] Edges;
        public Graph(int v, int e)
        {
            this.V = v;
            this.E = e;
            Edges = new Edge[E];
            for (int i = 0; i < V; i++)
            {
                Edges[i] = new Edge();
            }
        }
        public int IsCycle(Graph graph)
        {
            // Allocate memory for creating V subsets
            int[] parent = new int[graph.V];

            for (int i = 0; i < graph.V; i++)
            {
                parent[i] = -1;
            }
            // Iterate through all edges of graph, find subset of both 
            // vertices of every edge, if both subsets are same, then 
            // there is cycle in graph. 

            for (int i = 0; i < graph.E; i++)
            {
                int x = Find(parent, graph.Edges[i].src);
                int y = Find(parent, graph.Edges[i].dest);
                if (x == y)
                {
                    return 1;
                }

                graph.Union(parent, x, y);
            }

            return 0;
        }
        // A utility function to find the subset of an element i 
        private int Find(int[] parent, int i)
        {
            if (parent[i] == -1)
                return i;
            return Find(parent, parent[i]);
        }

        // A utility function to do union of two subsets 
        private void Union(int[] parent, int x, int y)
        {
            int xset = Find(parent, x);
            int yset = Find(parent, y);
            // Making yset parent of xset.
            parent[xset] = yset;
        }
    }

    public class Edge
    {
        public int src;
        public int dest;
    }
}
