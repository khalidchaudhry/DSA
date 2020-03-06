using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GeeksForGeeks
{
    public class CountNodesAtLevel
    {
        int vertices;
        List<int>[] adjList;
        bool[] visited;
        public CountNodesAtLevel(int v)
        {
            vertices = v;
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

        public int BFS(int level)
        {
            visited = new bool[vertices];
            int levelCount = 0;
            for (int i = 0; i < vertices; i++)
            {
                visited[i] = false;
            }

            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();

            visited[0] = true;
            // assumed that vertex 0 is root of the tree.
            // In tuple , item 1 is node id and item 2 is level 
            queue.Enqueue(new Tuple<int, int>(0, 0));

            while (queue.Count != 0)
            {
                Tuple<int, int> dequeue = queue.Dequeue();
                if (dequeue.Item2 == level)
                {
                    ++levelCount;
                }
                foreach (int neighbour in adjList[dequeue.Item1])
                {
                    if (!visited[neighbour])
                    {
                        visited[neighbour] = true;
                        // while enqueuing item get level information from the parent and add 1 to it
                        queue.Enqueue(new Tuple<int, int>(neighbour, dequeue.Item2+1));
                    }
                }
            }

            return levelCount;
        }
    }
}
