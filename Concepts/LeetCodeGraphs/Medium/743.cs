using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _743
    {
        public void SortedSetTest()
        {
            var priorityQueue = new SortedSet<(int weight, int node)>();

            priorityQueue.Add((0, 9));
            priorityQueue.Add((0, 2));
            priorityQueue.Add((1, 0));
        }
        /// <summary>
        /// https://leetcode.com/problems/network-delay-time/discuss/390399/C-Readable-Clean-Named-Tuple-SortedSet-%2B-BFS
        /// </summary>
        /// <param name="times"></param>
        /// <param name="N"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int NetworkDelayTime(int[][] times, int N, int K)
        {
            var nodeMap = new Dictionary<int, GraphNode>();
            foreach (var time in times)
            {
                (int start, int end, int weight) connection = (time[0], time[1], time[2]);
                if (!nodeMap.ContainsKey(connection.start))
                    nodeMap[connection.start] = new GraphNode(connection.start);
                if (!nodeMap.ContainsKey(connection.end))
                    nodeMap[connection.end] = new GraphNode(connection.end);

                nodeMap[connection.start].AdjacentNodes.Add((connection.end, connection.weight));
            }

            // BFS
            var priorityQueue = new SortedSet<(int weight, int node)>();
            priorityQueue.Add((0, K));

            var visited = new HashSet<int>(); // node id
            var maxWeight = 0;
            while (priorityQueue.Count > 0)
            {
                var state = priorityQueue.First();
                priorityQueue.Remove(state);

                if (visited.Contains(state.node))
                    continue;

                visited.Add(state.node);
                maxWeight = Math.Max(maxWeight, state.weight);

                var graphNode = nodeMap[state.node];
                foreach (var node in graphNode.AdjacentNodes)
                {
                    if (visited.Contains(node.id))
                        continue;
                    priorityQueue.Add((node.weight + state.weight, node.id));
                }
            }

            return visited.Count == N ? maxWeight : -1;
        }
        public int NetworkDelayTime2(int[][] times, int N, int K)
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            int[,] map = new int[N + 1, N + 1];

            foreach (int[] time in times)
            {
                if (!dict.ContainsKey(time[0]))
                {
                    dict[time[0]] = new List<int>();
                }
                dict[time[0]].Add(time[1]);
                map[time[0], time[1]] = time[2];
            }
            //int[] target = new int[N + 1];
            //Array.Fill(target, 20001);
            int[] target = Enumerable.Repeat(20001, N + 1).ToArray();
            target[0] = 0;
            target[K] = 0;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(K);
            while (queue.Count != 0)
            {
                int top = queue.Dequeue();
                if (!dict.ContainsKey(top))
                {
                    continue;
                }
                foreach (int sub in dict[top])
                {
                    int next = target[top] + map[top, sub];
                    if (target[sub] > next)
                    {
                        target[sub] = next;
                        queue.Enqueue(sub);
                    }
                }
            }
            int max = target.Max();
            if (max == 20001) return -1;
            return max;

        }


    }

    public class GraphNode
    {
        public int NodeId { get; }
        public List<(int id, int weight)> AdjacentNodes { get; }

        public GraphNode(int id)
        {
            NodeId = id;
            AdjacentNodes = new List<(int, int)>();
        }
    }


}
