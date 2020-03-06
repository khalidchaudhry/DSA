using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GraphRepresentation
{
    // Approach followed in GeeksForGeeks
    public class Graph3
    {
        // Number of nodes in graph
        public int count { get; }

        public Dictionary<int, int>[] adj { get; }
        public Graph3(int cnt)
        {
            count = cnt;
            adj = new Dictionary<int, int>[count];
            for (int i = 0; i < count; i++)
            {
                adj[i] = new Dictionary<int, int>();
            }
        }
        public void AddDirectedEdge(int src, int dst, int cst)
        {
            var dictionary = adj[src];
            dictionary.Add(dst, cst);
            adj[src] = dictionary;

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
                foreach (var key in adj[i].Keys)
                {
                    Console.Write($"{key} ");
                }

                Console.WriteLine();
            }
        }
    }
}
