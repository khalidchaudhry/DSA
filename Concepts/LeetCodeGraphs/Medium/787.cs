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
        //! https://leetcode.com/problems/cheapest-flights-within-k-stops/discuss/1504019/c-BFS-solution-100ms
        /// </summary>
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {

            Dictionary<int, List<Node>> graph = new Dictionary<int, List<Node>>();
            for (int i = 0; i < n; ++i)
            {
                graph.Add(i, new List<Node>());
            }
            foreach (int[] flight in flights)
            {
                int from = flight[0];
                int to = flight[1];
                int cost = flight[2];
                graph[from].Add(new Node(to, cost));
            }

            int[] price = new int[n];
            for (int i = 0; i < n; ++i)
            {
                price[i] = int.MaxValue;
            }

            price[src] = 0;

            int cheapestPrice = int.MaxValue;

            Queue<QueueData> queue = new Queue<QueueData>();
            queue.Enqueue(new QueueData(src, 0, 0));
            while (queue.Count > 0)
            {
                QueueData curr = queue.Dequeue();
                if (curr.NodeLabel == dst)
                {
                    cheapestPrice = Math.Min(cheapestPrice, curr.Price);
                }
                foreach (Node neighbor in graph[curr.NodeLabel])
                {
                    int newPrice = neighbor.Price + curr.Price;
                    //! This is the key, need to avoid adding current flightNode to Queue if:: 
                    //! - the hop of the current node + 1 is greater than k
                    //! - the price of current node's priceTillNow + current flight's weight not more than minPrice calculated till now
                    //! - the price of flight's destination is not yet calculated or it is greater than current node's priceTillNow + current flight's weight
                    if (curr.Hopes <= K && newPrice < price[neighbor.NodeLabel])
                    {
                        price[neighbor.NodeLabel] = newPrice;
                        queue.Enqueue(new QueueData(neighbor.NodeLabel, newPrice, curr.Hopes + 1));
                    }
                }
            }

            return price[dst] == int.MaxValue ? -1 : price[dst];
        }
        public class Node
        {
            public int NodeLabel;
            public int Price;
            public Node(int nodeLabel, int price)
            {
                NodeLabel = nodeLabel;
                Price = price;
            }
        }

        public class QueueData
        {
            public int NodeLabel;
            public int Price;
            public int Hopes;
            public QueueData(int nodeLabel, int price, int hopes)
            {
                NodeLabel = nodeLabel;
                Price = price;
                Hopes = hopes;
            }
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
