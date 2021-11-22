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
        //! Minimum connections needed =total connected components-1
        //!Time: O(n+m), m is the total connections given and n is the total nodes given
        //!Space: O(n) 
        public int MakeConnected(int n, int[][] connections)
        {
            //! To represent computer in terms of edges we can say that bare min we  n-1 edges
            //! if given connections are less than bare minimum(n-1), we can't connect them. 
            if (connections.Length < n - 1)
            {
                return -1;
            }

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
            //! minimum steps needed = total connected components -1 in graph
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
        public int MakeConnected1(int n, int[][] connections)
        {
            //! To represent computer in terms of edges we can say that min there will be n-1 edges 
            if (connections.Length < n - 1)
            {
                return -1;
            }
            UF uf = new UF(n);
            foreach (int[] connection in connections)
            {
                int u = connection[0];
                int v = connection[1];

                int pu = uf.FindSet(u);
                int pv = uf.FindSet(v);
                if (pu != pv)
                {
                    uf.Union(pu, pv);
                    --n;
                }
            }
            
            //! To connect N disconnected components you will need minimum of n-1 edges ,  simply return n - 1.
            return n - 1;

        }

       
    }
}
