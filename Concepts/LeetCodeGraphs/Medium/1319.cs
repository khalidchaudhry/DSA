using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1319
    {
        /// <summary>
        //! Based on idea from Kai's class
        // ! Count connected components in the graph.
        //! Minimum connections needed equal to total connected components-1
        //!Time: O(n+m), m is the total connections given and n is the total nodes given
        //!Space: O(n)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="connections"></param>
        /// <returns></returns>
        public int MakeConnected(int n, int[][] connections)
        {
            //! If given computers are greater then 1+ connections , then its not possible to connect them 
            if (n > connections.Length + 1)
                return -1;

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            BuildGraph(graph, connections, n);

            bool[] visited = new bool[n];
            int result = 0;
            foreach (var keyValue in graph)
            {
                if (!visited[keyValue.Key])
                {
                    DFS(keyValue.Key, graph, visited);
                    ++result;
                }
            }
            //! minimum steps needed equal to total connected components -1 in graph
            return result - 1;
        }


        private void DFS(int node, Dictionary<int, List<int>> graph, bool[] visited)
        {
            visited[node] = true;
            List<int> neighbours = graph[node];

            foreach (int neighbour in neighbours)
            {
                if (!visited[neighbour])
                {
                    DFS(neighbour, graph, visited);
                }
            }
        }
        private void BuildGraph(Dictionary<int, List<int>> graph, int[][] connections, int n)
        {
            for (int i = 0; i < n; ++i)
            {
                graph.Add(i, new List<int>());
            }

            foreach (int[] connection in connections)
            {
                graph[connection[0]].Add(connection[1]);
                graph[connection[1]].Add(connection[0]);
            }
        }
    }
}
