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
            //int[][] graph = new int[7][] {
            //    new int[]{1,2 },
            //    new int[]{2,3 },
            //    new int[]{5},
            //    new int[]{0},
            //    new int[]{5},
            //    new int[]{ },
            //    new int[]{ }
            //};

            int[][] graph = new int[2][] {
                new int[]{1},
                new int[]{0}
            };

            EventualSafe.EventualSafeNodes(graph);
            Console.ReadLine();
        }

        public IList<int> EventualSafeNodes(int[][] graph)
        {

            int n = graph.Length;
            Dictionary<int, int> nodeColor = new Dictionary<int, int>();
            for (int i = 0; i < n; ++i)
            {
                nodeColor.Add(i, 0);
            }

            List<int> safeNodes = new List<int>();
            for (int i = 0; i < n; ++i)
            {
                if (nodeColor[i] == 0)
                {
                    if (IsValidColor(graph, i, nodeColor, 1))
                    {
                        safeNodes.Add(i);
                    }
                }
            }
            return safeNodes;
        }

        private bool IsValidColor(int[][] graph, int start, Dictionary<int, int> nodeColor, int color)
        {
            nodeColor[start] = color;
            int nextColor = -color;

            foreach (int neighbor in graph[start])
            {
                if (nodeColor[neighbor] != 0) //neighbor already painted
                {
                    if (nodeColor[neighbor] == color)  // check if neighbor color is same as the current neighbor
                        return false;
                }
                else
                {
                    if (!IsValidColor(graph, neighbor, nodeColor, nextColor))
                    {
                        return false;
                    }
                }
            }

            return true;
        }



        /// <summary>
        //! DFS for topological sort 
        //! 0 --> white, 1--> Grey, 2---> Black 
        //!https://leetcode.com/problems/find-eventual-safe-states/discuss/119871/Straightforward-Java-solution-easy-to-understand
        //! See discussion
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public List<int> EventualSafeNodes0(int[][] graph)
        {
            List<int> res = new List<int>();
            if (graph == null || graph.Length == 0) return res;

            int nodeCount = graph.Length;
            //! initially all the nodes will be not visited. 
            //! color array holds there possible values 
            //! 0=White= Not processed
            //! 1=Grey= Currently processing
            //! 2=Black=Completely processed 
            int[] color = new int[nodeCount];

            for (int i = 0; i < nodeCount; i++)
            {
                if (!IsInCycle(graph, i, color))
                {
                    res.Add(i);
                }
            }

            return res;
        }

        private bool IsInCycle(int[][] graph, int start, int[] color)
        {
            if (color[start] == 1) return true;
            if (color[start] == 2) return false;

            color[start] = 1;//! currently being visited
            foreach (int neighbor in graph[start])
            {
                if (IsInCycle(graph, neighbor, color))
                {
                    return true;
                }
            }

            color[start] = 2;//its being visited so marking it as black
            return false;

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
            //! indegree not having count but it will have nodes because we need them in our processing. 
            Dictionary<int, List<int>> indegree = new Dictionary<int, List<int>>();
            CalculateDegree(graph, outdegree, indegree);

            List<int> result = new List<int>();
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < N; i++)
            {
                //!Queue nodes with outdegree of 0 
                if (outdegree[i] == 0)
                {
                    result.Add(i);
                    queue.Enqueue(i);
                }
            }

            while (queue.Count != 0)
            {
                int curr = queue.Dequeue();

                foreach (int neighbor in indegree[curr])
                {
                    outdegree[neighbor]--;
                    //!Queue nodes with outdegree of 0 
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

        private static void CalculateDegree(int[][] graph, int[] outdegree, Dictionary<int, List<int>> indegree)
        {
            for (int i = 0; i < graph.Length; ++i)
            {
                indegree[i] = new List<int>();
            }

            for (int i = 0; i < graph.Length; i++)
            {
                foreach (int node in graph[i])
                {
                    //!Rather than having indegree count, we are adding nodes
                    indegree[node].Add(i);
                    outdegree[i]++;
                }
            }
        }

        
    }
}
