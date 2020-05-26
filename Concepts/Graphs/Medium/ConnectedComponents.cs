using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Medium
{
    /// <summary>
    /// https://medium.com/leetcode-patterns/leetcode-pattern-1-bfs-dfs-25-of-the-problems-part-1-519450a84353
    /// </summary>
    public class ConnectedComponents
    {
        private int _ccCount;
        private bool[] _visited;
        private List<List<int>> _graph;

        public int[] _cc { get; }


        //!Iterative   
        //https://medium.com/leetcode-patterns/leetcode-pattern-1-bfs-dfs-25-of-the-problems-part-1-519450a84353  
        public int CountComponentsIterative(int n, int[][] edges)
        {

            
            //!building the graph's adjacency list
            List<List<int>> Graph = BuildGraph(n,edges);
            //!initialize visited array
            _visited = new bool[n];

            Stack<int> stk = new Stack<int>();
            _ccCount = 0;
            for (int i = 0; i < n; i++)
            {
                if (!_visited[i])
                {
                    ++_ccCount;
                    //! DFS magic spell 
                    //!1.initialize stack
                    stk.Push(i);
                }

                while (stk.Count != 0)
                {
                   

                    //! 2. Pop current element
                    int curr = stk.Pop();
                    //! 3. Mark it as visited
                    _visited[curr] = true;

                    List<int> neighbours = Graph[curr];

                    foreach(int neighbour in neighbours)
                    {
                        //!4. Fetch its all univisited neighbours 
                        if (!_visited[neighbour])
                        {
                            //!5. Push them to the stack
                            stk.Push(neighbour);
                        }
                    }
                }
            }
            return _ccCount;         

        }

        //!Recursive
        // https://www.udemy.com/course/graph-theory-algorithms/learn/lecture/10794122#overview
        public int CountComponentsRecursive(int n, int[][] edges)
        {
            _ccCount = 0;
            _visited = new bool[n];
            _graph = BuildGraph(n, edges);
            for (int i = 0; i < n; i++)
            {
                if (!_visited[i])
                {
                    DFS(i);
                    ++_ccCount;
                }

            }
            return _ccCount;
        }

        private List<List<int>> BuildGraph(int n, int[][] edges)
        {
            List<List<int>> graph = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                graph.Add(new List<int>());
            }

            for (int i = 0; i < edges.Length; i++)
            {
                //!Adding neighbours 
                graph[edges[i][0]].Add(edges[i][1]);
                graph[edges[i][1]].Add(edges[i][0]);
            }
            return graph;

        }

        private void DFS(int i)
        {
            _visited[i] = true;
            List<int> neighbours = _graph[i];

            foreach (int neighbour in neighbours)
            {
                if (!_visited[neighbour])
                {
                    DFS(neighbour);
                }
            }
        }
    }
}
