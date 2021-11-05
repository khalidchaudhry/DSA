using LeetCodeHeap;
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

            //int cheapestPrice = int.MaxValue;

            Queue<QueueData> queue = new Queue<QueueData>();
            queue.Enqueue(new QueueData(src, 0, 0));
            while (queue.Count > 0)
            {
                QueueData curr = queue.Dequeue();
                //! we don't need below code becuase minPrices[] will contain cheapest price to all the nodes
                //if (curr.NodeLabel == dst)
                //{
                //    cheapestPrice = Math.Min(cheapestPrice, curr.Price);
                //}
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
        public int FindCheapestPrice1(int n, int[][] flights, int src, int dst, int K)
        {

            Dictionary<int, List<CityNode>> graph = new Dictionary<int, List<CityNode>>();
            for (int i = 0; i < n; ++i)
            {
                graph.Add(i, new List<CityNode>());
            }

            foreach (int[] flight in flights)
            {
                int from = flight[0];
                int to = flight[1];
                int cost = flight[2];
                graph[from].Add(new CityNode(to, cost, 0));
            }

            int[] distance = new int[n];
            for (int i = 0; i < n; ++i)
            {
                distance[i] = int.MaxValue;
            }
            distance[src] = 0;
            int[] stops = new int[n];
            for (int i = 0; i < n; ++i)
            {
                stops[i] = int.MaxValue;
            }
            stops[src] = 0;

            var comparer = Comparer<CityNode>.Create((x, y) => {
                //! In priority queue avaiable in java its not needed . However here we need it becauase in case of duplicate, data will not be added in pq
                if (x.Cost == y.Cost)
                {
                    return x.Stops.CompareTo(y.Stops);
                }
                return x.Cost.CompareTo(y.Cost);
            });

            PQ<CityNode> pq = new PQ<CityNode>(comparer);
            pq.Add(new CityNode(src, 0, 0));

            while (pq.Size > 0)
            {
                CityNode curr = pq.Poll();
                if (curr.Label == dst)
                {
                    return curr.Cost;
                }
                // If there are no more steps left, continue 
                if (curr.Stops == K + 1)
                {
                    continue;
                }

                foreach (CityNode neighbor in graph[curr.Label])
                {
                    int newCost = curr.Cost + neighbor.Cost;
                    if (newCost < distance[neighbor.Label])
                    {
                        distance[neighbor.Label] = newCost;
                        pq.Add(new CityNode(neighbor.Label, newCost, curr.Stops + 1));
                    }
                    else if (curr.Stops < stops[neighbor.Label])
                    {
                        pq.Add(new CityNode(neighbor.Label, newCost, curr.Stops + 1));
                    }
                    stops[neighbor.Label] = curr.Stops;
                }
            }

            return distance[dst] == int.MaxValue ? -1 : distance[dst];


        }

        public class CityNode
        {
            public int Label;
            public int Cost;
            public int Stops;
            public CityNode(int label, int cost, int stops)
            {
                Label = label;
                Cost = cost;
                Stops = stops;
            }
        }

    }
}
