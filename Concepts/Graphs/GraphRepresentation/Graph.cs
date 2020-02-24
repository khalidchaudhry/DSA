using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GraphRepresentation
{
    public class Graph
    {
        // Number of nodes in graph
        public int count { get; }

        public List<List<Edge>> adj { get; }
        public Graph(int cnt)
        {
            count = cnt;
            adj = new List<List<Edge>>();
            for (int i = 0; i < count; i++)
            {
                adj.Add(new List<Edge>());
            }
        }
        public void AddDirectedEdge(int src, int dst, int cst)
        {
            Edge edge = new Edge(dst, cst);
            adj[src].Add(edge);

        }
        public void AddDirectedEdge(int src, int dst)
        {
            AddDirectedEdge(src, dst, 1);

        }
        public void AddUnDirectedEdge(int src, int dst, int cst)
        {
            AddDirectedEdge(src, dst, cst);
            AddDirectedEdge(dst, src, cst);
        }
        public void AddUnDirectedEdge(int src, int dst)
        {
            AddDirectedEdge(src, dst, 1);
            AddDirectedEdge(dst, src, 1);
        }
        public void Print()
        {

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Vertex:{i} is connected with ");
                for (int j = 0; j < adj[i].Count; j++)
                {
                    Console.Write($" {adj[i][j]}");
                }

                Console.WriteLine();
            }

         }
    }

    public class Edge
    {
        public int dest { get; }
        public int cost { get; }
        public Edge(int dst, int cst)
        {
            dest = dst;
            cost = cst;
        }
        public override string ToString()
        {
            return dest.ToString();
        }
    }



}
