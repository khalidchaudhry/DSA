using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1514
    {
        /// <summary>
        // TODO:Not sure about complexity analysis
        // Time=O(E*E) as we are running BFS till exhaustion. where E is  the number of edges 
        // Space=O(E*E)
        /// </summary>
        public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
        {

            Dictionary<int, List<(int n, double p)>> graph = new Dictionary<int, List<(int n, double p)>>();
            for (int i = 0; i < n; ++i)
            {
                graph.Add(i, new List<(int, double)>());
            }

            for (int i = 0; i < edges.Length; ++i)
            {
                int[] edge = edges[i];
                int from = edge[0];
                int to = edge[1];
                graph[from].Add((to, succProb[i]));
                graph[to].Add((from, succProb[i]));
            }

            double[] prob = new double[n];
            for (int i = 0; i < n; ++i)
            {
                prob[i] = double.MinValue;
            }

            prob[start] = 1;
            Queue<(int node, double prob)> queue = new Queue<(int node, double prob)>();
            queue.Enqueue((start, 1));
            while (queue.Count > 0)
            {
                (int firstNode, double firstNodeProb) = queue.Dequeue();
                foreach ((int neigh, double neighProb) in graph[firstNode])
                {
                    double newProb = (firstNodeProb * neighProb);
                    if (newProb > prob[neigh])
                    {
                        prob[neigh] = newProb;
                        queue.Enqueue((neigh, newProb));
                    }
                }
            }
            return prob[end] == double.MinValue ? 0 : prob[end];
        }

    }
}
