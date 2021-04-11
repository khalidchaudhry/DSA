using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _787
    {
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {

            Dictionary<int, List<(int dst, int cost)>> graph = new Dictionary<int, List<(int dst, int cost)>>();
            for (int i = 0; i < n; ++i)
            {
                graph.Add(i, new List<(int dst, int cost)>());
            }

            foreach (int[] flight in flights)
            {
                int from = flight[0];
                int to = flight[1];
                int cost = flight[2];

                graph[from].Add((to, cost));
            }

            int cheapestPrice = int.MaxValue;
            Queue<(int src, int cost, int stops)> queue = new Queue<(int src, int cost, int stops)>();
            queue.Enqueue((src, 0, 0));


            while (queue.Count != 0)
            {
                if (queue.Peek().stops > K + 1)
                    break;

                int count = queue.Count;
                while (count != 0)
                {
                    (int source, int cost, int stops) = queue.Dequeue();

                    if (source == dst)
                    {
                        cheapestPrice = Math.Min(cheapestPrice, cost);
                    }
                    foreach ((int neighbor, int nc) in graph[source])
                    {
                        int newCost = nc + cost;
                        if (newCost < cheapestPrice)
                        {
                            queue.Enqueue((neighbor, newCost, stops + 1));
                        }
                    }
                    --count;
                }
            }
            return cheapestPrice == int.MaxValue ? -1 : cheapestPrice;
        }

        /// <summary>
        ///https://www.youtube.com/watch?v=o6dUXOk-GWQ 
        //!Level order traversal of the graph
        //Time Complexity Anayalsis: https://leetcode.com/problems/cheapest-flights-within-k-stops/solution/
        //! Let E represent the number of flights and V represent the number of cities.
        //! Time complexity: O(E*K) since each edge canbe visited multiple times but it can't be more than K
        //! Space Complexity: O(E) Space is accupied by the queue holding nodes. At given time we can have all our nodes in queue
        /// </summary>
        public int FindCheapestPrice0(int n, int[][] flights, int src, int dst, int K)
        {
            Dictionary<int, List<(int to, int cost)>> graph = new Dictionary<int, List<(int to, int cost)>>();

            foreach (int[] flight in flights)
            {
                int from = flight[0];
                int to = flight[1];
                int cost = flight[2];

                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new List<(int to, int cost)>());
                }
                if (!graph.ContainsKey(to))
                {
                    graph.Add(to, new List<(int to, int cost)>());
                }

                graph[from].Add((to, cost));
            }


            int cheapestPrice = int.MaxValue;
            int stops = 0;

            Queue<(int node, int cost)> queue = new Queue<(int node, int cost)>();
            queue.Enqueue((src, 0));

            while (queue.Count != 0)
            {
                int count = queue.Count;
                while (count != 0)
                {
                    (int node, int cost) = queue.Dequeue();

                    if (node == dst)
                    {
                        cheapestPrice = Math.Min(cheapestPrice, cost);
                    }

                    foreach ((int neighbor, int neighborCost) in graph[node])
                    {
                        //! Controlling the size of the queue. Otherwise , it will grow exponentially 
                        if (neighborCost + cost < cheapestPrice)
                            queue.Enqueue((neighbor, neighborCost + cost));
                    }

                    --count;
                }

                if (stops++ > K)
                {
                    break;
                }
            }

            return cheapestPrice == int.MaxValue ? -1 : cheapestPrice;
        }
    }
}
