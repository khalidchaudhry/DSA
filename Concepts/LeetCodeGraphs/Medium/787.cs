using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _787
    {
        /// <summary>
        /// https://leetcode.com/problems/cheapest-flights-within-k-stops/discuss/623375/JAVA-DFSBFSBFS%2BPriorityQueue
      
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            Dictionary<int, List<(int to, int cost)>> graph = new Dictionary<int, List<(int to, int cost)>>();

            foreach (int[] flight in flights)
            {
                int from = flight[0];
                int to = flight[1];
                int cost = flight[2];
                if (!graph.ContainsKey(from))
                {
                    graph[from] = new List<(int to, int cost)>();
                }

                graph[from].Add((to, cost));
            }

            Queue<(int node, int cost, int stops)> queue = new Queue<(int node, int cost, int stops)>();
            queue.Enqueue((src,0,0));
            int minCost = int.MaxValue;

            while (queue.Count != 0)
            {
                (int node, int cost, int stops) = queue.Dequeue();

                if (node == dst)
                {
                    minCost = Math.Min(cost,minCost);
                    continue;
                }
                //Imp check --- checking currentCost is not greater than what we already achieved 
                //when we reached //destination + if we already pass K stop , there is no point movin forward
                if (cost > minCost || stops > K)
                    continue;
                if (graph.ContainsKey(node))
                {
                    foreach (var neighbor in graph[node])
                    {
                        queue.Enqueue((neighbor.to,cost+neighbor.cost,stops+1));
                    }
                }
            }

            if (minCost != int.MaxValue)
            {
                return minCost;
            }
            else
            {
                return -1;
            }
        }
    }
}
