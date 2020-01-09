using Graphs.GraphRepresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Traversal
{
    public class BFS
    {
        // Approach followed in Hermant Jain book
        public static void BFSTraversalQueue(Graph graph, int start)
        {
            int count = graph.count;
            bool[] visited = new bool[count];
            Queue<int> queue = new Queue<int>();

            visited[start] = true;
            queue.Enqueue(start);
            while (queue.Count != 0)
            {
                var deQueue = queue.Dequeue();
                Console.WriteLine($"{deQueue}");
                List<Edge> neighbours = graph.adj[deQueue];
                foreach (var neighbour in neighbours)
                {
                    if (visited[neighbour.dest] == false)
                    {
                        visited[neighbour.dest] = true;
                        queue.Enqueue(neighbour.dest);
                    }
                }
            }
        }

    }
}
