using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _210
    {
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
    }
}
