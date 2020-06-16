using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _547
    {

        /// <summary>
        //! This ITERATIVE version without building the graph first. so definitely saving on Memory than FindCircleNum version below
        //! Intuition is to find the total number of connected components  using DFS
        // Time Complexity=O(n^2) as where we are traversing the complete matrix of size n*n
        // Space complexity=O(n) visited array of size n is used. 
        /// </summary>
        /// <param name="M"></param>
        /// <returns></returns>
        public int FindCircleNum0(int[][] M)
        {
            int nodesCount = M.Length;
            int ccCount = 0;
            bool[] visited = new bool[nodesCount];
            Stack<int> stk = new Stack<int>();

            for (int i = 0; i < nodesCount; i++)
            {
                if (!visited[i])
                {
                    ++ccCount;
                    //! 1.Initialize stack
                    stk.Push(i);
                    DFS2(M, visited, stk);
                }
            }

            return ccCount;
        }

        private static void DFS2(int[][] M, bool[] visited, Stack<int> stk)
        {
            while (stk.Count != 0)
            {
                //! 2.Pop the current node from stack
                int poppedItem = stk.Pop();
                //! 3. Mark the current node as visited
                visited[poppedItem] = true;

                for (int y = 0; y < M[poppedItem].Length; y++)
                {
                    if (!visited[y] && M[poppedItem][y] == 1)
                    { //! 4. Push all unvisited nodes to stack. 
                        stk.Push(y);
                    }
                }
            }
        }

        public int FindCircleNum(int[][] M)
        {
            List<List<int>> graph = BuildGraph(M);

            int nodesCount = graph.Count;
            int ccCount = 0;
            bool[] visited = new bool[nodesCount];
            Stack<int> stk = new Stack<int>();

            for (int i = 0; i < nodesCount; i++)
            {
                if (!visited[i])
                {
                    ++ccCount;
                    //! 1.Initialize stack
                    stk.Push(i);
                    DFS(graph, visited, stk);
                }
            }

            return ccCount;
        }

        private static void DFS(List<List<int>> graph, bool[] visited, Stack<int> stk)
        {
            while (stk.Count != 0)
            {
                //! 2.Pop the current node from stack
                int poppedItem = stk.Pop();
                //! 3. Mark the current node as visited
                visited[poppedItem] = true;
                foreach (int neighbour in graph[poppedItem])
                {
                    if (!visited[neighbour])
                        //! 3. Push all unvisited nodes to the stack. 
                        stk.Push(neighbour);
                }
            }
        }

        private List<List<int>> BuildGraph(int[][] M)
        {
            List<List<int>> graph = new List<List<int>>();
            int n = M.Length;
            for (int i = 0; i < n; i++)
            {
                graph.Add(new List<int>());
            }

            for (int x = 0; x < n; x++)
            {
                //! The reason for below loop is that we don't know  exact columns at design time
                for (int y = 0; y < n; y++)
                {
                    //! if node is connected to itself than no need to add it to the neighbours list
                    if (x == y)
                    {
                        continue;
                    }
                    //! Nodes are only connected if entry is 1
                    if (M[x][y] == 1)
                    {
                        graph[x].Add(y);
                    }
                }
            }

            return graph;
        }
    }
}
