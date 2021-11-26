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
        //! Space=O(V+E)
        /// </summary>

        public bool CanFinish0(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < numCourses; ++i)
            {
                graph.Add(i, new List<int>());
            }

            int[] indegree = new int[numCourses];
            foreach (int[] prerequisite in prerequisites)
            {
                int a = prerequisite[0];
                int b = prerequisite[1];
                ++indegree[a];
                graph[b].Add(a);
            }

            int coursesCompleted = 0;
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < indegree.Length; ++i)
            {
                if (indegree[i] == 0)
                {
                    queue.Enqueue(i);
                    ++coursesCompleted;
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
                        ++coursesCompleted;
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return coursesCompleted == numCourses;
        }

        //! DFS recursive solution
        //! using basic cycle detection pattern. Used in question 802 as well
        public bool CanFinish1(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < numCourses; ++i)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < prerequisites.Length; ++i)
            {
                int from = prerequisites[i][1];
                int to = prerequisites[i][0];
                graph[from].Add(to);
            }
            //! color array holds there possible values 
            //! White= Not processed
            //! Grey= Currently processing
            //! Black=Completely processed 
            int[] color = new int[numCourses];

            for (int i = 0; i < numCourses; ++i)
            {
                if (IsDFSContainsCycle(graph, i, color))
                {
                    return false;
                }
            }

            return true;

        }
        public bool IsDFSContainsCycle(Dictionary<int, List<int>> graph, int at, int[] color)
        {
            if (color[at] == 1) return true;
            if (color[at] == 2) return false;

            color[at] = 1; //! painting the node with grey color
            foreach (int neighbor in graph[at])
            {
                if (IsDFSContainsCycle(graph, neighbor, color))
                {
                    return true;
                }
            }
            color[at] = 2; //! painting the node with black color(completed)
            return false;
        }

        /// <summary>
        //!Topological sort Depth first search iterative
        //https://www.youtube.com/watch?v=0LjVxtLnNOk
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish3(int numCourses, int[][] prerequisites)
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
                        //! Push courses having no depedencies i.e. indegree==0 to stack
                        stk.Push(neighbour);
                    }
                }
            }

            return count == n;
        }

       

        private void BuildGraph(int[][] prerequisites, int[] indegree, Dictionary<int, List<int>> adj)
        {
            foreach (int[] relation in prerequisites)
            {
                // !index 1---> index0
                int from = relation[1];
                int to = relation[0];

                // relation[0] depends on relation[1]. It means course at index 0 depends upon course at index 1
                // In order to take course at index 0 , you must first take course at index 1.
                // index 1---> index0
                // !Course at index 1 is prerequisitie for course at index 0
                if (adj.ContainsKey(from))
                {
                    adj[from].Add(to);
                    indegree[from]++;
                }
                else
                {
                    List<int> nextCourses = new List<int>();
                    //! if course does not have any prerequisite than relation[1] element will not be there
                    if (relation.Length == 2)
                    {
                        nextCourses.Add(to);
                        indegree[to]++;
                        adj.Add(from, nextCourses);
                    }
                    else
                    {
                        adj.Add(to, nextCourses);
                    }

                }
            }
        }

        private void InitializeQueue(Queue<int> queue, int[] indegree)
        {
            for (int i = 0; i < indegree.Length; ++i)
            {
                if (indegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

        }

    }
}
