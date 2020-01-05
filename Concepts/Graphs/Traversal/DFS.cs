using Graphs.GraphRepresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Traversal
{
    public class DFS
    {
        // Approach followed in Hermant Jain book
        public static void DFSTraversalStack(Graph graph, int start)
        {
            int count = graph.count;
            bool[] visited = new bool[count];
            Stack<int> stk = new Stack<int>();

            visited[start] = true;
            stk.Push(start);
            while (stk.Count != 0)
            {
                var pop = stk.Pop();
                Console.WriteLine($"{pop}");
                List<Edge> neighbours = graph.adj[pop];
                foreach (var neighbour in neighbours)
                {
                    if (visited[neighbour.dest] == false)
                    {
                        visited[neighbour.dest] = true;
                        stk.Push(neighbour.dest);
                    }
                }
            }
        }

        // Approach followed in Hermant Jain book
        public static void DFSTraversalRecursive(Graph graph, int index, bool[] visited)
        {
            visited[index] = true;

            Console.WriteLine($"{index}");
            List<Edge> neighbours = graph.adj[index];
            foreach (var neighbour in neighbours)
            {
                if (visited[neighbour.dest] == false)
                {
                    DFSTraversalRecursive(graph, neighbour.dest, visited);
                }
            }
        }

        // https://simpledevcode.wordpress.com/2015/12/22/graphs-depth-first-traversal-c/
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

        public static void DFSTraversalStack2(Graph graph, int start)
        {
            int count = graph.count;
            bool[] visited = new bool[count];
            Stack<int> stk = new Stack<int>();

            stk.Push(start);
            while (stk.Count != 0)
            {
                var pop = stk.Pop();
                if (visited[pop] == false)
                {
                    Console.WriteLine(pop);
                    visited[pop] = true;

                    List<Edge> neighbours = graph.adj[pop];
                    foreach (var neighbour in neighbours)
                    {
                        stk.Push(neighbour.dest);
                    }
                }

            }
        }
    }
}

