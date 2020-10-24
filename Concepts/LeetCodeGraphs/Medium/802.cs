using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium._802
{
    public class _802
    {
        public static void _802Main()
        {

            _802 EventualSafe = new _802();
            //int[][] graph = new int[5][]
            //{
            //    new int[]{0},
            //    new int[]{2,3,4 },
            //    new int[]{3,4},
            //    new int[]{0,4},
            //    new int[]{}
            //};
            int[][] graph = new int[7][] {
                new int[]{1,2 },
                new int[]{2,3 },
                new int[]{5},
                new int[]{0},
                new int[]{5},
                new int[]{ },
                new int[]{ }
            };

            EventualSafe.EventualSafeNodes2(graph);
            Console.ReadLine();
        }
        public IList<int> EventualSafeNodes0(int[][] graph)
        {
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < graph.Length; ++i)
            {
                nodes.Add(new Node());
            }

            for (int i = 0; i < graph.Length; ++i)
            {
                foreach (int edge in graph[i])
                {
                    nodes[edge].InDegree.Add(i);
                }

                nodes[i].OutDegree += graph[i].Length;
            }

            Queue<Node> queue = new Queue<Node>();
            List<int> result = new List<int>();
            for (int i = 0; i < nodes.Count; ++i)
            {
                if (nodes[i].OutDegree == 0)
                {
                    result.Add(i);
                    queue.Enqueue(nodes[i]);
                }
            }

            while (queue.Count != 0)
            {
                Node curr = queue.Dequeue();
                foreach (var node in curr.InDegree)
                {
                    --nodes[node].OutDegree;
                    if (nodes[node].OutDegree == 0)
                    {
                        result.Add(node);
                        queue.Enqueue(nodes[node]);
                    }
                }
            }

            result.Sort();
            return result;

        }

        /// <summary>
        /// https://leetcode.com/problems/find-eventual-safe-states/discuss/120633/Java-Solution-(DFS-andand-Topological-Sort)
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public List<int> EventualSafeNodes1(int[][] graph)
        {
            int N = graph.Length;
            //!degree array to record the out-degree
            int[] outdegree = new int[N];

            //!nodes map to record In-neighbors
            Dictionary<int, List<int>> nodes = new Dictionary<int, List<int>>();
            for (int i = 0; i < N; ++i)
            {
                nodes[i] = new List<int>();
            }

            for (int i = 0; i < graph.Length; i++)
            {
                foreach (int node in graph[i])
                {
                    nodes[node].Add(i);
                    outdegree[i]++;
                }
            }

            List<int> result = new List<int>();
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < N; i++)
            {
                if (outdegree[i] == 0)
                {
                    result.Add(i);
                    queue.Enqueue(i);
                }
            }

            while (queue.Count != 0)
            {
                int curr = queue.Dequeue();

                foreach (int neighbor in nodes[curr])
                {
                    outdegree[neighbor]--;
                    if (outdegree[neighbor] == 0)
                    {
                        result.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            result.Sort();
            return result;
        }

        /// <summary>
        //! DFS for topological sort 
        //! 0 --> white, 1--> Grey, 2---> Black 
        //!https://leetcode.com/problems/find-eventual-safe-states/discuss/119871/Straightforward-Java-solution-easy-to-understand
        //! See discussion
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>


        public List<int> EventualSafeNodes2(int[][] graph)
        {
            List<int> res = new List<int>();
            if (graph == null || graph.Length == 0) return res;

            int nodeCount = graph.Length;
            //! initially all the nodes will be not visited. 
            //! color array holds there possible values 
            //! White= Not processed
            //! Grey= Currently processing
            //! Black=Completely processed 
            int[] color = new int[nodeCount];

            for (int i = 0; i < nodeCount; i++)
            {
                if (!DFSHasCycle(graph, i, color))
                {
                    res.Add(i);
                }
            }

            return res;
        }
        private bool DFSHasCycle(int[][] graph, int start, int[] color)
        {
            if (color[start] == 1) return true;
            if (color[start] == 2) return false;

            color[start] = 1;//! currently being visited
            foreach (int neighbor in graph[start])
            {
                if (DFSHasCycle(graph, neighbor, color))
                {
                    return true;
                }
            }

            color[start] = 2;//its being visited so marking it as black
            return false;

        }
    }

    public class Node
    {
        // Equivalent to indegree
        public List<int> InDegree { get; set; }

        // Outdegree
        public int OutDegree { get; set; }
        public Node()
        {
            OutDegree = 0;
            InDegree = new List<int>();
        }
    }
}
