using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GeeksForGeeks
{
    public class TransitiveClosure2
    {
        // to store vertices
        private int vertices;
        // to store adjacency list
        private List<int>[] adjList;

        // to store transitive closure 
        private int[,] tc;

        public TransitiveClosure2(int count)
        {
            vertices = count;
            tc = new int[vertices, vertices];

            adjList = new List<int>[vertices];

            for (int i = 0; i < vertices; i++)
            {
                adjList[i] = new List<int>();
            }
        }
        public void AddEdge(int src, int dest)
        {
            adjList[src].Add(dest);
        }
        public void GetTransitiveClosure()
        {
            // Call the recursive helper 
            // function to print DFS 
            // traversal starting from all 
            // vertices one by one
            for (int i = 0; i < vertices; i++)
            {
                DFSUtil(i, i);
            }

            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    Console.Write($"{tc[i,j]}");
                }
                Console.WriteLine();
            }
        }
        private void DFSUtil(int s, int v)
        {
            // Mark reachability from s to v as true.
            tc[s, v] = 1;
            // Find all the vertices reachable  through v 
            foreach (int neighbour in adjList[v])
            {
                if (tc[s,neighbour] == 0)
                {
                    DFSUtil(s, neighbour);
                }
            }

        }
    }
}
