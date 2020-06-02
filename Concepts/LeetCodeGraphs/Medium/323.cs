using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    class _323
    {
        public int CountComponents(int n, int[][] edges)
        {
            int ccCount = 0;

            List<List<int>> graph = BuildGraph(n, edges);

            bool[] visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    ++ccCount;
                    DFS(i, graph, visited);
                }
            }

            return ccCount;
        }

        public int CountComponents2(int n, int[][] edges)
        {
            int ccCount = 0;

            List<List<int>> graph = BuildGraph(n, edges);

            bool[] visited = new bool[n];
            Stack<int> stk = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    ++ccCount;
                    //!1 Stack initialization
                    stk.Push(i);
                    DFSIterative(stk, graph, visited);
                }
            }

            return ccCount;
        }

        private void DFSIterative(Stack<int> stk, List<List<int>> graph, bool[] visited)
        {
            while (stk.Count != 0)
            {
                //!2.Pop the current node from the stack
                int curr = stk.Pop();

                //!3. Mark it as visited
                visited[curr] = true;
                
                List<int> neighbours = graph[curr];

                foreach (int neighbour in neighbours)
                {
                    //!4. Fetch all the UNVISITED neighbours 
                    if (!visited[neighbour])
                    {
                        //! 5. Push them to the stack
                        stk.Push(neighbour);
                    }
                }
            }
        }

        private List<List<int>> BuildGraph(int n, int[][] edges)
        {
            List<List<int>> graph = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                graph.Add(new List<int>());
            }

            for (int i = 0; i < edges.Length; i++)
            {
                graph[edges[i][0]].Add(edges[i][1]);

                graph[edges[i][1]].Add(edges[i][0]);
            }

            return graph;
        }

        private void DFS(int at, List<List<int>> graph, bool[] visited)
        {
            visited[at] = true;

            List<int> neighbours = graph[at];

            foreach (int neighbor in neighbours)
            {
                if (!visited[neighbor])
                {
                    DFS(neighbor, graph, visited);
                }
            }
        }
    }
}
