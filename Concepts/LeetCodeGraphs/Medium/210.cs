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
        private bool IsDFSContainsCycle(Dictionary<int, List<int>> graph, int at, int[] color, List<int> ans)
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

        /// <summary>
        //! Top Sort
        //! Time complexity=O(V+E) where V are the number of courses and E are the relationship of that course with other courses
        //! Space Complexity=O(V+E)
        /// </summary>
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < numCourses; ++i)
            {
                graph.Add(i, new List<int>());
            }
            int[] indegree = new int[numCourses];
            foreach (int[] prereq in prerequisites)
            {
                int a = prereq[0];
                int b = prereq[1];
                graph[b].Add(a);
                ++indegree[a];
            }

            List<int> result = new List<int>();
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < numCourses; ++i)
            {
                if (indegree[i] == 0)
                {
                    queue.Enqueue(i);
                    result.Add(i);
                }
            }

            while (queue.Count > 0)
            {
                int curr = queue.Dequeue();
                foreach (int neighbor in graph[curr])
                {
                    --indegree[neighbor];
                    if (indegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                        result.Add(neighbor);
                    }
                }
            }
            return result.Count == numCourses ? result.ToArray() : new int[] { };
        }
    }
}
