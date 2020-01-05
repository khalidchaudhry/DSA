using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GraphRepresentation
{
    class GraphAM
    {
        private int count;
        private int[,] adj;
        public GraphAM(int cnt)
        {
            count = cnt;
            adj = new int[count, count];
        }
        public void AddDirectedEdge(int src, int dst, int cost)
        {
            adj[src, dst] = cost;
        }
        public void AddUnDirectedEdge(int src, int dst,int cost)
        {
            adj[src, dst] = cost;
            adj[dst, src] = cost;
        }
        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Node with index:{i} is connected with ");
                for (int j = 0; j < count; j++)
                {
                    if (adj[i, j] != 0)
                    {
                        Console.Write($" {j}");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
