using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _743
    {


        public static void _743Main()
        {

        }


        /// <summary>
        //! Using  Dijkstra alrgorithm
        //https://www.youtube.com/watch?v=YHx6r9pM5e0
        ///
        /// </summary>

        public int NetworkDelayTime0(int[][] times, int N, int K)
        {

            Dictionary<int, List<(int neighbor, int weight)>> graph = new Dictionary<int, List<(int neighbor, int weight)>>();

            for (int i = 0; i < times.Length; ++i)
            {
                int from = times[i][0];
                int to = times[i][1];
                int weight = times[i][2];

                if (!graph.ContainsKey(from))
                {
                    graph[from] = new List<(int neighbor, int weight)>();
                }
                if (!graph.ContainsKey(to))
                {
                    graph[to] = new List<(int neighbor, int weight)>();
                }

                graph[from].Add((to, weight));
            }
            //N+1 as given nodes are from 1 to N
            int[] distance = Enumerable.Repeat(int.MaxValue, N + 1).ToArray();

            Queue<(int node, int weight)> queue = new Queue<(int node, int weight)>();
            //! setting distance of K(starting node to 0)
            distance[K] = 0;
            //! Queue starting node
            queue.Enqueue((K, 0));

            while (queue.Count != 0)
            {
                (int currNode, int currNodeWeight) = queue.Dequeue();

                foreach ((int neighborNode, int neighborWeight) in graph[currNode])
                {
                    //! if the new weight is less than previous weight , update the weight and push to queue
                    int newWeight = currNodeWeight + neighborWeight;
                    if (newWeight < distance[neighborNode])
                    {
                        distance[neighborNode] = newWeight;
                        queue.Enqueue((neighborNode,newWeight));
                    }
                }
            }

            int maxWeight = 0;
            for (int i = 1; i < distance.Length; ++i)
            {
                if (distance[i] == int.MaxValue)
                    return -1;
                maxWeight = Math.Max(maxWeight, distance[i]);
            }
            return maxWeight;
        }

        /// <summary>
        //! Using sorted set 
        /// https://leetcode.com/problems/network-delay-time/discuss/390399/C-Readable-Clean-Named-Tuple-SortedSet-%2B-BFS
        /// </summary>
        /// <param name="times"></param>
        /// <param name="N"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int NetworkDelayTime(int[][] times, int N, int K)
        {
            var graph = new Dictionary<int, List<(int to, int weight)>>();
            foreach (var time in times)
            {
                (int from, int to, int weight) = (time[0], time[1], time[2]);
                if (!graph.ContainsKey(from))
                    graph[from] = new List<(int to, int weight)>();
                if (!graph.ContainsKey(to))
                    graph[to] = new List<(int to, int weight)>();

                graph[from].Add((to, weight));
            }

            //! Not typical BFS pattern.
            //! Here we are not marking neighbors visited when adding them queue rather then 
            //! we are marking them after dequeue. Reason is if we do it then it will make 
            //! mark node as visited which might have  weighted length and we will not be able
            //! to proces them later

            var priorityQueue = new SortedSet<(int weight, int node)>();


            var visited = new HashSet<int>();
            //! First weight then node 
            priorityQueue.Add((0, K));

            var maxWeight = 0;
            while (priorityQueue.Count > 0)
            {
                (int weight, int node) curr = priorityQueue.First();
                priorityQueue.Remove(curr);
                //! Checking if node visited 
                if (visited.Contains(curr.node))
                {
                    continue;
                }
                //! Adding to visited set here 
                visited.Add(curr.node);

                maxWeight = Math.Max(maxWeight, curr.weight);

                foreach ((int neighbor, int neighborWeight) in graph[curr.node])
                {
                    if (!visited.Contains(neighbor))
                    {
                        //! not adding neighbor to visited set here 
                        priorityQueue.Add((neighborWeight + curr.weight, neighbor));
                    }
                }
            }
            //! in case we are not able to send signal to all nodes , return -1
            return visited.Count == N ? maxWeight : -1;
        }
    }


}
