using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _802
    {
        /// <summary>
        /// https://leetcode.com/problems/find-eventual-safe-states/discuss/120633/Java-Solution-(DFS-andand-Topological-Sort)
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public List<int> EventualSafeNodes0(int[][] graph)
        {
            int N = graph.Length;
            //!degree array to record the out-degree
            int[] outdegree = new int[N];
            //!neighbors map to record In-neighbors
            Dictionary<int, HashSet<int>> neighbors = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < graph.Length; i++)
            {
                foreach (int neighbor in graph[i])
                {
                    if (!neighbors.ContainsKey(neighbor))
                    {
                        neighbors.Add(neighbor, new HashSet<int>());
                    }

                    neighbors[neighbor].Add(i);
                    outdegree[i]++;
                }
            }

            HashSet<int> res = new HashSet<int>();
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < N; i++)
            {
                if (outdegree[i] == 0)
                {
                    res.Add(i);
                    queue.Enqueue(i);
                }
            }

            while (queue.Count != 0)
            {
                int v = queue.Dequeue();
                res.Add(v);
                if (neighbors.ContainsKey(v))
                {
                    foreach (int neighbor in neighbors[v])
                    {
                        outdegree[neighbor]--;
                        if (outdegree[neighbor] == 0)
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            List<int> list = new List<int>(res);
            list.Sort();
            return list;
        }

        /// <summary>
        /// https://leetcode.com/problems/find-eventual-safe-states/discuss/119871/Straightforward-Java-solution-easy-to-understand!
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        //!0:have not been visited
        //!1:safe
        //!2:unsafe
        //For DFS, we need to do some optimization.When we travel a path, we mark the node with 2 which represents having been visited, 
        //and when we encounter a node which results in a cycle, we return false, all node in the path stays 2 and it represents unsafe.
        //And in the following traveling,whenever we encounter a node which points to a node marked with 2, we know it will results in a cycle, 
        //so we can stop traveling.On the contrary, when a node is safe, we can mark it with 1 and whenever we encounter a safe node, 
        //we know it will not results in a cycle.
        public List<int> EventualSafeNodes1(int[][] graph)
        {
            List<int> res = new List<int>();
            if (graph == null || graph.Length == 0) return res;

            int nodeCount = graph.Length;
            //! initially all the nodes will be not visited. 
            int[] color = new int[nodeCount];

            for (int i = 0; i < nodeCount; i++)
            {
                if (DFS(graph, i, color))
                {
                    res.Add(i);
                }
            }

            return res;
        }
        private bool DFS(int[][] graph, int start, int[] color)
        {
            if (color[start] != 0)
            {
                return color[start] == 1;
            }

            color[start] = 2;
            foreach (int newNode in graph[start])
            {
                if (!DFS(graph, newNode, color))
                    return false;
            }
            color[start] = 1;

            return true;
        }

        //!Not giving correct result
        public IList<int> EventualSafeNodes(int[][] graph)
        {
            Degree[] degree = new Degree[graph.Length];
            List<int> result = new List<int>();
            for (int i = 0; i < graph.Length; i++)
            {

                degree[i] = new Degree();
            }

            for (int i = 0; i < graph.Length; i++)
            {
                if (graph[i].Length == 0)
                {
                    continue;
                }
                for (int j = 0; j < graph[i].Length; j++)
                {

                    int index = graph[i][j];
                    degree[index].InDegree++;
                    degree[i].Outdegree++;
                }
            }

            for (int i = 0; i < degree.Length; i++)
            {
                if (degree[i].Outdegree == 0 || degree[i].InDegree == 0)
                {
                    result.Add(i);
                }
            }

            for (int i = 0; i < graph.Length; i++)
            {
                bool exists = true;

                for (int j = 0; j < graph[i].Length; j++)
                {
                    if (!result.Contains(graph[i][j]))
                    {
                        exists = false;
                        break;
                    }
                }
                if (exists)
                {
                    if (!result.Contains(i))
                    {
                        result.Add(i);
                        i = 0;
                    }
                }
            }

            result.Sort();

            return result;

        }
    }

    public class Degree
    {
        public int InDegree;

        public int Outdegree;
    }
}
