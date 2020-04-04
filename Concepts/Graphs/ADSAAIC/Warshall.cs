using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.ADSAAIC
{
    // https://www.youtube.com/watch?v=oNI0rf2P9gE
    // Floyd-warshall algorithm solves the shortest path between pair of vertices 
    // Floyd-warshall algorithm  is similar to Dijkstra(single source shortest path algorithm) but Dijkstra
    // will find path from one of the source vertices. 
    
    public class Warshall
    {
        private int vertices;
        bool[,] adj;

        public Warshall(int v)
        {
            vertices = v;
            adj = new bool[vertices, vertices];
        }

        public void AddEdge(int src, int dest)
        {
            adj[src, dest] = true;
        }

        public void WarshallAlgorithm()
        {
            bool[,] p = new bool[vertices, vertices];
            // initializing our path matrix with what the provided input
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    p[i, j] = adj[i, j];
                }
            }

            for (int k = 0; k < vertices; k++)
            {
                for (int i = 0; i < vertices; i++)
                {
                    for (int j = 0; j < vertices; j++)
                    {
                        p[i, j] = (p[i, j] || (p[i, k] && p[k, j]));
                    }
                }
            }
            PrintPaths(p);
        }

        private void PrintPaths(bool[,] p)
        {
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    if (p[i, j])
                    {
                        Console.Write("1 ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
