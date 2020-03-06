using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.ADSAAIC
{
    public class ShortestPath
    {
        int vertex;
        List<int>[] adjList;
        bool[] visited;
        int[] distance;
        int[] predecessor;

        public ShortestPath(int v)
        {
            vertex = v;
            visited = new bool[vertex];

            adjList = new List<int>[vertex];
            for (int i = 0; i < vertex; i++)
            {
                adjList[i] = new List<int>();
            }
            distance = new int[vertex];
            for (int i = 0; i < vertex; i++)
            {
                distance[i] = int.MaxValue;
            }
            predecessor = new int[vertex];
            for (int i = 0; i < vertex; i++)
            {
                predecessor[i] = -1;
            }
        }
        public void AddEdge(int src, int dest)
        {
            adjList[src].Add(dest);
        }
        public void FindShortestPath(int start)
        {
            BFSUtil(start);
            PrintPaths(start);
        }
        private void PrintPaths(int start)
        {
            for (int v = 0; v < vertex; v++)
            {
                if (distance[v] == int.MaxValue)
                {
                    Console.WriteLine($"No path from vertex {start} to vertex {v}");
                }

                else
                {
                    Console.WriteLine($"Shortest distance  from vertex {start} to vertex {v} is {distance[v]}");
                    // store the full path in array path
                    int[] path = new int[vertex];
                    int count = 0;
                    int y = v;
                    while (y != -1)
                    {
                        count++;
                        path[count] = y;
                        //x = predecessor[y];
                        y = predecessor[y];
                        //y =x;
                    }
                    Console.WriteLine("Shortest path is :");
                    int i;
                    for (i = count; i > 1; i--)
                    {
                        Console.Write($"{path[i]}->");
                    }

                    Console.WriteLine($"{path[i]}");
                }

            }

        }
        private void BFSUtil(int start)
        {
            Queue<int> q = new Queue<int>();

            visited[start] = true;
            distance[start] = 0;

            q.Enqueue(start);

            while (q.Count != 0)
            {
                int node = q.Dequeue();
                foreach (int neighbour in adjList[node])
                {
                    if (!visited[neighbour])
                    {
                        visited[neighbour] = true;
                        predecessor[neighbour] = node;
                        distance[neighbour] = distance[node] + 1;

                        q.Enqueue(neighbour);
                    }
                }
            }
        }
    }
}
