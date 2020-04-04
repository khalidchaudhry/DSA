using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GeeksForGeeks
{
    //https://www.geeksforgeeks.org/implementation-of-bfs-using-adjacency-matrix/
    public class BFSUsingAdjacencyMatrix
    {
        bool[,] adjMatrix;

        int vertices;
        public BFSUsingAdjacencyMatrix(int v)
        {
            this.vertices = v;
            adjMatrix = new bool[vertices, vertices];
        }

        public void AddEdge(int src, int dest)
        {
            adjMatrix[src, dest] = true;
        }

        public void BFS(int start)
        {
            Queue<int> queue = new Queue<int>();

            // Visited vector to so that a vertex is not visited more than once 
            // Initializing the vector to false as no vertex is visited at the beginning 
            bool[] visited = new bool[vertices];

            queue.Enqueue(start);

            // Set source as visited 
            visited[start] = true;

            while (queue.Count != 0)
            {
                int dequeue = queue.Dequeue();
                // Print the current node
                Console.Write(dequeue);

                // For every adjacent vertex to the current vertex 
                for (int i = 0; i < vertices; i++)
                {
                    if (adjMatrix[dequeue, i] == true && (!visited[i]))
                    {
                        // Push the adjacent node to the queue 
                        queue.Enqueue(i);
                        // Set 
                        visited[i] = true;
                    }
                }
            }
        }
    }
}
