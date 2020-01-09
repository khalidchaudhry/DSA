using Graphs.GraphRepresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.DFSPaths
{

    public class DepthFirstPaths
    {
        private bool[] marked;    // marked[v] = is there an s-v path?
        private int[] edgeTo;     // edgeTo[v] = last edge on s-v path
        private  int s;          // source vertex

        /**
        * Computes a path between {@code s} and every other vertex in graph {@code G}.
        * @param G the graph
        * @param s the source vertex
        * @throws IllegalArgumentException unless {@code 0 <= s < V}
        */
        public DepthFirstPaths(Graph G, int s)
        {
            this.s = s;
            edgeTo = new int[G.count];
            marked = new bool[G.count];
           
            DFS(G, s);
        }

        // depth first search from v
        private void DFS(Graph G, int v)
        {
            marked[v] = true;
            foreach(var w in G.adj[v])
            {
                if (!marked[w.dest])
                {
                    edgeTo[w.dest] = v;
                    DFS(G, w.dest);
                }
            }
        }

        /**
        * Is there a path between the source vertex {@code s} and vertex {@code v}?
        * @param v the vertex
        * @return {@code true} if there is a path, {@code false} otherwise
        * @throws IllegalArgumentException unless {@code 0 <= v < V}
        */
        public bool hasPathTo(int v)
        {
            return marked[v];
        }

        /**
        * Returns a path between the source vertex {@code s} and vertex {@code v}, or
        * {@code null} if no such path.
        * @param  v the vertex
        * @return the sequence of vertices on a path between the source vertex
        * {@code s} and vertex {@code v}, as an Iterable
        * @throws IllegalArgumentException unless {@code 0 <= v < V}
        */
        public IEnumerable<int> PathTo(int v)
        {
           
            if (!hasPathTo(v)) return null;
            Stack<int> path = new Stack<int>();
            for (int x = v; x != s; x = edgeTo[x])
                path.Push(x);
            path.Push(s);
            return path;
        }


    }
}
