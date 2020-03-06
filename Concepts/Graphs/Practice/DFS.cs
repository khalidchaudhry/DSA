using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Practice
{
    public class DFS
    {
        private bool[] visited;
        public DFS(Graph g, int startVertex)
        {
            visited = new bool[g.NodesCount];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }
            //DFSTravsersalIterative(g, startVertex);
            DFSTravsersalIterative2(g, startVertex);

            //Console.Write("Nodes visited in DFS(Recursive): ");
            //DFSTravsersalRecursive(g, startVertex);

        }
        public void DFSTravsersalIterative(Graph g, int v)
        {
            Console.Write("Nodes visited in DFS(Iterative): ");

            Stack<int> stk = new Stack<int>();

            visited[v] = true;
            stk.Push(v);

            while (stk.Count != 0)
            {
                int pop = stk.Pop();
                Console.Write($"{pop} ");
                foreach (var vertex in g.Nodes[pop])
                {
                    if (!visited[vertex])
                    {
                        visited[vertex] = true;
                        stk.Push(vertex);
                    }
                }
            }
        }
        /*
         procedure DFS-iterative(G, v) :
         let S be a stack
         S.push(v)
         while S is not empty
         v = S.pop() 
           if v is not labeled as discovered:
               label v as discovered
               for all edges from v to w in G.adjacentEdges(v) do
                   S.push(w)
      */

        public void DFSTravsersalIterative2(Graph g, int v)
        {
            Console.Write("Nodes visited in DFS(Iterative2): ");

            Stack<int> stk = new Stack<int>();
            stk.Push(v);
            while (stk.Count != 0)
            {
                int pop = stk.Pop();
                if (!visited[pop])
                {
                    visited[pop] = true;
                    Console.Write($"{pop} ");
                    foreach (var vertex in g.Nodes[pop])
                    {
                        stk.Push(vertex);
                    }
                }
            }
        }

        public void DFSTravsersalRecursive(Graph g, int v)
        {
            Console.Write($"{v} ");
            visited[v] = true;
            foreach (var vertex in g.Nodes[v])
            {
                if (!visited[vertex])
                {
                    DFSTravsersalRecursive(g, vertex);
                }
            }
        }
    }
}
