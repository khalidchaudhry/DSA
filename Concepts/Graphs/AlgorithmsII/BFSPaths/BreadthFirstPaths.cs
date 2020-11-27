using Graphs.GraphRepresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.BFSPaths
{
    public class BFSRunningClass
    {
        public static  void RunningClassMain()
        {
            int s = 0;

            Graph graph = new Graph(5);
            graph.AddDirectedEdge(0, 1, 3);
            graph.AddDirectedEdge(0, 4, 2);
            graph.AddDirectedEdge(1, 2, 1);
            graph.AddDirectedEdge(2, 3, 1);
            graph.AddDirectedEdge(3, 2, 1);
            graph.AddDirectedEdge(4, 1, -2);
            graph.AddDirectedEdge(4, 3, -1);            

            BreadthFirstPaths bfs = new BreadthFirstPaths(graph, s);

            for (int v = 0; v < graph.count; v++)
            {
                if (bfs.hasPathTo(v))
                {
                    Console.Write($"{s} to {v}({bfs.DistTo(v)}) :");
                    foreach (int x in bfs.PathTo(v))
                    {
                        if (x == s)
                            Console.Write(x);
                        else
                            Console.Write("-" + x);
                    }
                    Console.WriteLine();
                }

                else
                {
                    Console.Write($"{s} to {v}:  not connected");
                }
            }
        }

    }

    public class BreadthFirstPaths
    {
        private static int INFINITY = int.MaxValue;
        private bool[] marked;  // marked[v] = is there an s-v path
        private int[] edgeTo;      // edgeTo[v] = previous edge on shortest s-v path
        private int[] distTo;      // distTo[v] = number of edges shortest s-v path

        public BreadthFirstPaths(Graph graph, int s)
        {
            marked = new bool[graph.count];
            distTo = new int[graph.count];
            edgeTo = new int[graph.count];
            BFS(graph, s);
        }

        private void BFS(Graph graph, int s)
        {
            Queue<int> q = new Queue<int>();
            for (int v = 0; v < graph.count; v++)
                distTo[v] = INFINITY;
            distTo[s] = 0;
            marked[s] = true;
            q.Enqueue(s);

            while (q.Count!=0)
            {
                int v = q.Dequeue();
                foreach (var w in graph.adj[v])
                {
                    if (!marked[w.dest])
                    {
                        edgeTo[w.dest] = v;
                        distTo[w.dest] = distTo[v] + 1;
                        marked[w.dest] = true;
                        q.Enqueue(w.dest);
                    }
                }
            }
        }
        public bool hasPathTo(int v)
        {
            return marked[v];
        }
        /**
        * Returns a shortest path between the source vertex {@code s} (or sources)
        * and {@code v}, or {@code null} if no such path.
        * @param  v the vertex
        * @return the sequence of vertices on a shortest path, as an Iterable
        * @throws IllegalArgumentException unless {@code 0 <= v < V}
     */
        public IEnumerable<int> PathTo(int v)
        {
            if (!hasPathTo(v)) return null;
            Stack<int> path = new Stack<int>();
            int x;
            for (x = v; distTo[x] != 0; x = edgeTo[x])
                path.Push(x);
            path.Push(x);
            return path;

        }

        public int DistTo(int v)
        {
           
            return distTo[v];
        }
    }
}
