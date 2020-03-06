using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Practice
{
    public class BFS
    {
        private bool[] visited;
        public  BFS(Graph g,int v)
        {
            visited = new bool[g.NodesCount];
            for (int i =0; i < g.NodesCount; i++)
            {
                visited[i] = false;
            }
            BFSTraversal( g, v);
        }
        private void BFSTraversal(Graph g, int v)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(v);
            visited[v] = true;
            
            while (queue.Count != 0)
            {
                int node = queue.Dequeue();
                Console.Write($"{node} ");
                foreach (int neighbour in g.Nodes[node])
                {
                    if (!visited[neighbour])
                    {
                        visited[neighbour] = true;
                        queue.Enqueue(neighbour);
                    }
                }
            }
        }
    }
}
