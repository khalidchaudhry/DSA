using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _210
    {

        /// <summary>
        //! DFS using cycle detection template. Same as in Leet code quesitions 207,802
        // https://leetcode.com/problems/course-schedule-ii/discuss/797609/Short-BFS-and-DFS
        /// </summary>
        public int[] FindOrder0(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < numCourses; ++i)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < prerequisites.Length; ++i)
            {
                graph[prerequisites[i][1]].Add(prerequisites[i][0]);
            }
            //! color array holds there possible values 
            //! White= Not processed
            //! Grey= Currently processing
            //! Black=Completely processed 
            int[] color = new int[numCourses];
            List<int> ans = new List<int>();
            for (int i = 0; i < numCourses; ++i)
            {
                if (IsDFSContainsCycle(graph, i, color, ans))
                {
                    return new int[] { };
                }
            }
            ans.Reverse();
            return ans.ToArray();
        }

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            List<int> result = new List<int>();
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            int[] indegree = new int[numCourses];
            // Build Graph
            BuildGraph(prerequisites, adjList, indegree);
            Queue<int> queue = new Queue<int>();

            // Queue courses that don't have prerequisite 
            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            // BFS 
            int cleared = 0;
            while (queue.Count != 0)
            {
                int curr = queue.Dequeue();

                if (indegree[curr] == 0)
                {
                    result.Add(curr);
                    ++cleared;
                }

                if (!adjList.ContainsKey(curr))
                {
                    continue;
                }

                foreach (int neighbour in adjList[curr])
                {
                    --indegree[neighbour];
                    if (indegree[neighbour] == 0)
                    {
                        queue.Enqueue(neighbour);
                    }
                }
            }

            if (cleared != numCourses)
            {
                result.Clear();
            }

            return result.ToArray();

        }

        private void BuildGraph(int[][] prerequisites, Dictionary<int, List<int>> adjList, int[] indegree)
        {
            for (int i = 0; i < prerequisites.Length; i++)
            {
                if (!adjList.ContainsKey(prerequisites[i][1]))
                {
                    adjList.Add(prerequisites[i][1], new List<int>());
                }

                adjList[prerequisites[i][1]].Add(prerequisites[i][0]);
                ++indegree[prerequisites[i][0]];
            }
        }

        public bool IsDFSContainsCycle(Dictionary<int, List<int>> graph, int at, int[] color, List<int> ans)
        {
            if (color[at] == 1) return true;
            if (color[at] == 2) return false;

            color[at] = 1;
            foreach (int neighbor in graph[at])
            {
                if (IsDFSContainsCycle(graph, neighbor, color, ans))
                {
                    return true;
                }
            }

            color[at] = 2;
            ans.Add(at); //Add in reverse order, when all neighbors are added, add the prerequiste.
            return false;
        }

    }
}
