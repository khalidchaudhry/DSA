using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1136
    {
        public int MinimumSemesters(int n, int[][] relations)
        {

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 1; i <= n; ++i)
            {
                graph.Add(i, new List<int>());
            }

            int[] indegree = new int[n + 1];
            foreach (int[] relation in relations)
            {
                int prevCourse = relation[0];
                int nextCourse = relation[1];
                graph[prevCourse].Add(nextCourse);
                ++indegree[nextCourse];
            }

            Queue<int> queue = new Queue<int>();
            for (int i = 1; i <= n; ++i)
            {
                if (indegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }
            int coursesCompletedCount = 0;
            int minSemesters = 0;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                while (count > 0)
                {
                    int first = queue.Dequeue();
                    ++coursesCompletedCount;
                    foreach (int neighbor in graph[first])
                    {
                        --indegree[neighbor];
                        if (indegree[neighbor] == 0)
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                    --count;
                }
                ++minSemesters;
            }

            return coursesCompletedCount == n ? minSemesters : -1;

        }


    }
}
