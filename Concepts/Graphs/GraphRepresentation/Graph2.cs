using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GraphRepresentation
{
    // Approach followed in GeeksForGeeks
    public class Graph2
    {
        // Number of nodes in graph
        public int count { get; }

        public List<Edge>[] adj { get; }
        public Graph2(int cnt)
        {
            count = cnt;
            adj = new List<Edge>[count];
            for (int i = 0; i < count; i++)
            {
                adj[i]=new List<Edge>();
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
}
