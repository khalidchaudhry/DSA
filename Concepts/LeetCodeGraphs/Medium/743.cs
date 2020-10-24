using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _743
    {


        public  static void _743Main()
        {

        }
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
                        //! not adding of neighbor to visited set
                        priorityQueue.Add((neighborWeight + curr.weight, neighbor));
                    }
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


}
