using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _310
    {
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            IList<int> result = new List<int>();
            //!requires for input 
            // 1 []

            if (edges.Length == 0)
            {
                result.Add(0);
                return result;
            }
            List<List<int>> graph = BuildGraph(n, edges);

            result = TreeCenters(n, graph);
            return result;
        }

        private IList<int> TreeCenters(int n, List<List<int>> graph)
        {
            int[] degree = new int[n];
            List<int> leafNodes = new List<int>();
            //! Calculating the degree
            for (int i = 0; i < n; i++)
            {
                if (graph[i].Count <= 1)
                {
                    leafNodes.Add(i);
                    degree[i] = 0;
                }
                else
                {
                    degree[i] = graph[i].Count;
                }
            }

            int proccessedleavesCount = leafNodes.Count;
            //!Peeling of the onion
            while (proccessedleavesCount < n)
            {
                List<int> newLeaves = new List<int>();

                foreach (int node in leafNodes)
                {
                    foreach (int neighbour in graph[node])
                    {
                        if (--degree[neighbour] == 1)
                        {
                            newLeaves.Add(neighbour);
                        }
                    }
                    degree[node] = 0;
                }

                proccessedleavesCount += newLeaves.Count;
                leafNodes = newLeaves;
            }

            return leafNodes;
        }

        private List<List<int>> BuildGraph(int nodesCount, int[][] edges)
        {
            List<List<int>> graph = new List<List<int>>();

            for (int i = 0; i < nodesCount; i++)
            {
                graph.Add(new List<int>());
            }

            for (int row = 0; row < edges.Length; row++)
            {
                int from = edges[row][0];
                int to = edges[row][1];
                //! As graph is undirected adding both to and from edges 
                graph[from].Add(to);
                graph[to].Add(from);
            }
            return graph;
        }
    }
}
