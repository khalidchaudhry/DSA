using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1462
    {


        public static void _1462Main()
        {
            int n = 2;
            int[][] prerequisites = new int[][] {
                new int[2]{1,0 }
            };
            int[][] queries = new int[][] {
                new int[]{1,0 },
                new int[]{0,1 }
            };

            _1462 Pre = new _1462();

            var ans = Pre.CheckIfPrerequisite(n, prerequisites, queries);
            Console.ReadLine();

        }


        /// <summary>
        //! Based on Kahn's algorithm of topological sort 
        //! https://leetcode.com/problems/course-schedule-iv/discuss/660839/Java-Topological-Sorting
        /// </summary>
        public IList<bool> CheckIfPrerequisite(int n, int[][] prerequisites, int[][] queries)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            Dictionary<int, HashSet<int>> nodePrereqs = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < n; ++i)
            {
                graph[i] = new List<int>();
                nodePrereqs[i] = new HashSet<int>();
            }

            int[] inDegree = new int[n];
            foreach (int[] prerequisite in prerequisites)
            {
                graph[prerequisite[0]].Add(prerequisite[1]);
                ++inDegree[prerequisite[1]];
            }

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < inDegree.Length; ++i)
            {
                if (inDegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count != 0)
            {
                int curr = queue.Dequeue();
                foreach (int neighbor in graph[curr])
                {
                    //! We need to add prereq IRRESPECTIVE of indegree==0 because curr node is anyway preq 
                    //! C# does not have AddAll for hashset
                    //!adding all current node  prerequisites to its neighbor as well as current node
                    nodePrereqs[neighbor].Add(curr); 
                    //! Adding union will result in generating new hashset not modifying the original
                    nodePrereqs[neighbor].UnionWith(nodePrereqs[curr]);

                    --inDegree[neighbor];
                    if (inDegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            List<bool> result = new List<bool>();
            foreach (int[] query in queries)
            {
                int course0 = query[0];
                int course1 = query[1];
                //! We are checking course 1 and finding that course 0 is its prerequisite or not. 
                if (nodePrereqs[course1].Contains(course0))
                {
                    result.Add(true);
                }
                else
                    result.Add(false);
            }
            return result;
        }
    }
}
