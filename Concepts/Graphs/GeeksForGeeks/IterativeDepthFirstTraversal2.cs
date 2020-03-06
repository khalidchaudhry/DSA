using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GeeksForGeeks
{
    public class IterativeDepthFirstTraversal2
    {
        int vertices;
        List<int>[] adjList;
        public IterativeDepthFirstTraversal2(int v)
        {
            this.vertices = v;
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
        
        public void DFS()
        {
            bool[] visited = new bool[vertices];
            // Mark all the vertices as not visited 
            for (int i = 0; i < vertices; i++)
            {
                visited[i] = false;
            }

            for (int i = 0; i < vertices; i++)
            {
                if (!visited[i])
                {
                    DFSUtil(i, visited);
                }
            }
        }

        private void DFSUtil(int start, bool[] visited)
        {
            Stack<int> stk = new Stack<int>();
            stk.Push(start);

            while (stk.Count != 0)
            {
                int pop = stk.Pop();

                // Stack may contain same vertex twice. So 
                // we need to print the popped item only 
                // if it is not visited. 
                if (!visited[pop])
                {
                    Console.Write($"{pop} ");
                    visited[pop] = true;
                }

                // Get all adjacent vertices of the popped vertex s 
                // If a adjacent has not been visited, then push it 
                // to the stack. 
                foreach (int neighbour in adjList[pop])
                {
                    if (!visited[neighbour])
                    {
                        stk.Push(neighbour);
                    }
                }
            }
        }
    }
}
