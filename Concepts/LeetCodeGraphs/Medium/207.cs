using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _207
    {
        /// <summary>
        //! Backtracking
        //! And the problem to determine if one could build a valid schedule of courses that satisfies all the 
        //!dependencies (i.e. constraints) would be equivalent to determine if the corresponding graph is a DAG (Directed Acyclic Graph), 
        // !i.e. there is no cycle existed in the graph.


        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // course -> list of next courses
            Dictionary<int, List<int>> courseDict = new Dictionary<int, List<int>>();

            // build the graph first
            foreach (int[] relation in prerequisites)
            {
                // relation[0] depends on relation[1]
                if (courseDict.ContainsKey(relation[0]))
                {
                    courseDict[relation[0]].Add(relation[1]);
                }
                else
                {
                    List<int> nextCourses = new List<int>();
                    nextCourses.Add(relation[1]);
                    courseDict.Add(relation[0], nextCourses);
                }
            }

            bool[] path = new bool[numCourses];

            for (int currCourse = 0; currCourse < numCourses; ++currCourse)
            {
                if (IsCyclic(currCourse, courseDict, path))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        //!Topological sort
        //https://github.com/Nideesh1/Algo/blob/master/leetcode/L_207.java
        //https://www.youtube.com/watch?v=rG2-_lgcZzo
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish2(int numCourses, int[][] prerequisites)
        {
            int n = numCourses;
            int[] indegree = new int[n];
            Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();

            // build the graph first
            foreach (int[] relation in prerequisites)
            {

                if (adj.ContainsKey(relation[0]))
                {
                    adj[relation[0]].Add(relation[1]);
                    indegree[relation[1]]++;
                }
                else
                {
                    List<int> nextCourses = new List<int>();
                    //! if course does not have any prerequisite than relation[1] element will not be there
                    if (relation.Length == 2)
                    {
                        nextCourses.Add(relation[1]);
                        indegree[relation[1]]++;
                    }
                    adj.Add(relation[0], nextCourses);

                }
            }

            Queue<int> q = new Queue<int>();
            int count = 0;
            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                    q.Enqueue(i);
            }
            while (q.Count() != 0)
            {
                int cur = q.Dequeue();

                if (indegree[cur] == 0)
                    count++;

                if (!adj.ContainsKey(cur))
                    continue;

                foreach (int neighbour in adj[cur])
                {
                    indegree[neighbour]--;
                    if (indegree[neighbour] == 0)
                        q.Enqueue(neighbour);
                }
            }

            return count == n;
        }

        /*
   * backtracking method to check that no cycle would be formed starting from currCourse
   */
        private bool IsCyclic(
            int currCourse,
           Dictionary<int, List<int>> courseDict,
            bool[] path)
        {

            if (path[currCourse])
            {
                // come across a previously visited node, i.e. detect the cycle
                return true;
            }

            // no following courses, no loop.
            if (!courseDict.ContainsKey(currCourse))
                return false;

            // before backtracking, mark the node in the path
            path[currCourse] = true;

            // backtracking
            bool ret = false;
            foreach (int nextCourse in courseDict[currCourse])
            {
                ret = IsCyclic(nextCourse, courseDict, path);
                if (ret)
                    break;
            }
            // after backtracking, remove the node from the path
            path[currCourse] = false;
            return ret;
        }
    }
}
