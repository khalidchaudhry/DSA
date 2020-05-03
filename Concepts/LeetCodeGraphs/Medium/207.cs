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
        //!Topological sort Breadth First version  .
        //!Toplogical sort also have depth first search version . See videa here https://www.youtube.com/watch?v=u4v_kvOfumU&feature=youtu.be
        //https://github.com/Nideesh1/Algo/blob/master/leetcode/L_207.java
        //https://www.youtube.com/watch?v=rG2-_lgcZzo

        //V=numCourses
        //E =prerequisites.Length
        //! Time complexity=O(V+E)
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish0(int numCourses, int[][] prerequisites)
        {
            int n = numCourses;
            int[] indegree = new int[n];
            Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();

            //! build the graph and indegree(how many prerequisitie needed for  courses)
            BuildGraph(prerequisites, indegree, adj);

            Queue<int> q = new Queue<int>();
            int count = 0;
            //! Push courses having no depedencies i.e. indegree==0 to queue
            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                    q.Enqueue(i);
            }
            //! doing BFS Kahn algorithm 
            while (q.Count() != 0)
            {
                int cur = q.Dequeue();

                if (indegree[cur] == 0)
                    count++;
                // To avoid adj lookup failure
                if (!adj.ContainsKey(cur))
                    continue;

                foreach (int neighbour in adj[cur])
                {
                    indegree[neighbour]--;
                    if (indegree[neighbour] == 0)
                    {
                        //! Push courses having no depedencies i.e. indegree==0 to queue
                        q.Enqueue(neighbour);
                    }
                }
            }

            return count == n;
        }
        /// <summary>
        //!Topological sort Depth first search 
        //https://www.youtube.com/watch?v=0LjVxtLnNOk
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish1(int numCourses, int[][] prerequisites)
        {
            int n = numCourses;
            int[] indegree = new int[n];
            Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();

            //! build the graph and indegree(how many prerequisitie needed for  courses)
            BuildGraph(prerequisites, indegree, adj);

            Stack<int> stk = new Stack<int>();
            int count = 0;          

            //! Push courses having no depedencies i.e. indegree==0 to stack
            for (int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                    stk.Push(i);
            }

            //! doing DFS algorithm 
            while (stk.Count() != 0)
            {
                int cur = stk.Pop();

                if (indegree[cur] == 0)
                    count++;

                // To avoid adj lookup failure
                if (!adj.ContainsKey(cur))
                    continue;

                foreach (int neighbour in adj[cur])
                {
                    indegree[neighbour]--;
                    if (indegree[neighbour] == 0)
                    {
                        //! Push courses having no depedencies i.e. indegree==0 to queue
                        stk.Push(neighbour);
                    }
                }
            }

            return count == n;
        }

        private static void BuildGraph(int[][] prerequisites, int[] indegree, Dictionary<int, List<int>> adj)
        {
            foreach (int[] relation in prerequisites)
            {
                // relation[0] depends on relation[1]. It means course at index 0 depends upon course at index 1
                // In order to take course at index 0 , you must first take course at index 1.
                // index 1---> index0
                // !Course at index 1 is prerequisitie for course at index 0
                if (adj.ContainsKey(relation[1]))
                {
                    adj[relation[1]].Add(relation[0]);
                    indegree[relation[0]]++;
                }
                else
                {
                    List<int> nextCourses = new List<int>();
                    //! if course does not have any prerequisite than relation[1] element will not be there
                    if (relation.Length == 2)
                    {
                        nextCourses.Add(relation[0]);
                        indegree[relation[0]]++;
                    }
                    adj.Add(relation[1], nextCourses);
                }
            }
        }


        /// <summary>
        /// https://leetcode.com/problems/course-schedule/solution/
        //! Backtracking
        //! And the problem to determine if one could build a valid schedule of courses that satisfies all the 
        //!dependencies (i.e. constraints) would be equivalent to determine if the corresponding graph is a DAG (Directed Acyclic Graph), 
        // !i.e. there is no cycle existed in the graph.
        public bool CanFinish2(int numCourses, int[][] prerequisites)
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
