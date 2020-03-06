using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GeeksForGeeks
{
    public class IterativeDepthFirstTraversal
    {
        int vertices;
        List<int>[] adjList;
        bool[] visited;
        public IterativeDepthFirstTraversal(int v)
        {
            this.vertices = v;
            visited = new bool[vertices];
            adjList = new List<int>[vertices];

            for (int i = 0; i < vertices; i++)
            {
                adjList[i] = new List<int>();
            }
            for (int i = 0; i < vertices; i++)
            {
                visited[i] = false;
            }
        }
        public void AddEdge(int src, int dest)
        {
            adjList[src].Add(dest);
        }
        public void DFSIterative(int start)
        {
            Stack<int> stk = new Stack<int>();
            visited[start] = true;
            stk.Push(start);

            while (stk.Count != 0)
            {
                int pop = stk.Pop();
                Console.Write($"{pop} ");
                foreach (int neighbour in adjList[pop])
                {
                    if (!visited[neighbour])
                    {
                        visited[neighbour] = true;
                        stk.Push(neighbour);
                    }
                }
            }
        }
    }
}
