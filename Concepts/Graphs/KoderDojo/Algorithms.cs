using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.KoderDojo
{
    // https://www.koderdojo.com/blog/depth-first-search-algorithm-in-csharp-and-net-core
    public class Algorithms
    {
        public HashSet<T> DFSIterative<T>(Graph<T> graph, T start)
        {
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var stack = new Stack<T>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
            }

            return visited;
        }

        // my version for practicing 
        public void DFS2Iterative<T>(Graph<T> graph, T start)
        {
            HashSet<T> seen = new HashSet<T>();
            Stack<T> stk = new Stack<T>();

            stk.Push(start);
            seen.Add(start);

            while (stk.Count != 0)
            {
                T pop = stk.Pop();
                Console.WriteLine(pop);

                foreach (var neighbour in graph.AdjacencyList[pop])
                {
                    if (!(seen.Contains(neighbour)))
                    {
                        seen.Add(neighbour);
                        stk.Push(neighbour);
                    }
                }
            }
        }

        // my version for practicing 
        public void DFS2Recursive<T>(Graph<T> graph, T start, HashSet<T> seen)
        {
            seen.Add(start);
            Console.WriteLine(start);

            foreach (var neighbour in graph.AdjacencyList[start])
            {
                if (!(seen.Contains(neighbour)))
                {
                    DFS2Recursive(graph,neighbour,seen);
                }
            }
        }


        public HashSet<T> DFS<T>(Graph<T> graph, T start, Action<T> preVisit = null)
        {
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var stack = new Stack<T>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                    continue;

                if (preVisit != null)
                    preVisit(vertex);

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
            }

            return visited;
        }
    }
}
