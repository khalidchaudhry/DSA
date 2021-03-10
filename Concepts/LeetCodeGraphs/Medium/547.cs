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
        //! DFS recursive
        ////https://leetcode.com/problems/friend-circles/solution/
        //! Idea is not build graph and do DFS on provided array as provided array is adjacency matrix of the graph
        //! Another approach(not preferred) is to build graph first(FindCircleNum2 function below) and then run DFS on it. 
        //! Time complexity O(n^2) The complete matrix of size n^2 is traversed.
        //! Space complexity O(n) creating visited array of size n
        /// </summary>   
        public int FindCircleNum0(int[][] M)
        {
            if (M.Length == 0) return 0;
            int totalStudents = M.Length;
            //! No need to build graph first. We can do DFS on given array itself
            //List<List<int>> graph = BuildGraph(M);

            bool[] visited = new bool[totalStudents];
            int friendCircles = 0;
            for (int i = 0; i < totalStudents; i++)
            {
                if (!visited[i])
                {
                    ++friendCircles;
                    DFS(i, M, visited);
                }
            }

            return friendCircles;
        }
        private void DFS(int i, int[][] M, bool[] visited)
        {
            for (int j = 0; j < M.Length; ++j) //! M.Length because given matrix N*N
            {
                if (M[i][j] == 1 && !visited[j])
                {
                    visited[j] = true;
                    DFS(j, M, visited);
                }
            }
        }
        /// <summary>
        //! Creating Adjacency list graph represntation based on given input. Not preferred
        /// </summary>    
        public int FindCircleNum2(int[][] M)
        {
            if (M.Length == 0) return 0;
            int totalStudents = M.Length;
            List<List<int>> graph = BuildGraph(M);

            bool[] visited = new bool[totalStudents];
            int friendCircles = 0;
            for (int i = 0; i < totalStudents; i++)
            {
                if (!visited[i])
                {
                    ++friendCircles;
                    DFS(i, graph, visited);
                }
            }

            return friendCircles;
        }
        private List<List<int>> BuildGraph(int[][] M)
        {

            int rows, columns;
            rows = columns = M.Length; //because given matrix is N*N matrix
            List<List<int>> graph = new List<List<int>>();

            for (int i = 0; i < rows; i++)
            {
                graph.Add(new List<int>());
            }

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; ++column)
                {
                    if (M[row][column] == 1)
                    {
                        graph[row].Add(column);
                    }
                }
            }

            return graph;
        }
        private void DFS(int at, List<List<int>> graph, bool[] visited)
        {
            visited[at] = true;

            List<int> neighbours = graph[at];

            foreach (int neighbor in neighbours)
            {
                if (!visited[neighbor])
                    DFS(neighbor, graph, visited);
            }
        }

        /// <summary>
        //!BFS
        /// </summary>    
        public int FindCircleNum3(int[][] M)
        {
            if (M.Length == 0) return 0;
            int totalStudents = M.Length;

            bool[] visited = new bool[totalStudents];
            int friendCircles = 0;
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < totalStudents; i++)
            {
                if (!visited[i])
                {
                    queue.Enqueue(i);
                    while (queue.Count != 0)
                    {
                        int dequeue = queue.Dequeue();
                        visited[dequeue] = true;
                        for (int j = 0; i < M[dequeue].Length; ++j)
                        {
                            if (M[dequeue][j] == 1 && !visited[j])
                            {
                                queue.Enqueue(j);
                            }
                        }
                    }
                    ++friendCircles;
                }
            }

            return friendCircles;
        }

        /// <summary>
        //!Union Find
        /// </summary>    
        public int FindCircleNum4(int[][] M)
        {
            int n = M.Length;
            int count = n;
            UF uf = new UF(n);
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (M[i][j] == 1)
                    {
                        int u = uf.FindSet(i);
                        int v = uf.FindSet(j);
                        if (u != v)
                        {
                            --count;
                            uf.Union(u, v);
                        }
                    }
                }
            }
            return count;
        }

        /// <summary>
        //! DFS iterative
        //!https://medium.com/leetcode-patterns/leetcode-pattern-1-bfs-dfs-25-of-the-problems-part-1-519450a84353
        //! This ITERATIVE version without building the graph first. so definitely saving on Memory than FindCircleNum version below
        //! Intuition is to find the total number of connected components  using DFS
        // Time Complexity=O(n^2) as where we are traversing the complete matrix of size n*n
        // Space complexity=O(n) visited array of size n is used. 
        /// </summary>
        public int FindCircleNum1(int[][] M)
        {
            int nodesCount = M.Length; //! number of rows 
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
                    while (stk.Count != 0)
                    {
                        //! 2.Pop the current node(ith student) from stack                        
                        int current = stk.Pop();
                        //! 3. Mark the current node as visited
                        visited[current] = true;
                        //retrieve it's unvisited neighbours and push them to stack
                        //! retrieve all the jth students 
                        for (int j = 0; j < M[current].Length; j++)
                        {
                            //! if jth student is not visited and jth student is friend of ith student.  
                            if (!visited[j] && M[current][j] == 1)
                            { //! 4. Push all unvisited nodes to stack. 
                                stk.Push(j);
                            }
                        }
                    }
                }
            }

            return ccCount;
        }



               
    }
}
