using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _261
    {
        private List<List<int>> _graph;
        private int[] _parent;

        /// <summary>
        // https://leetcode.com/articles/graph-valid-tree/
        //!For a graph tobe valid tree , it must have exactly n-1 edges and all nodes must be connected 
        //! Two steps in algorithm
        //! 1. Number of Edges=Number of Nodes/Vertices -1
        //! 2. Graph fully connected
        /// </summary>

        public bool ValidTree0(int n, int[][] edges)
        {
            //! 1. Number of Edges=Number of Nodes/Vertices -1
            if (edges.Length != n - 1)
                return false;

            HashSet<int> seen = new HashSet<int>();
            Stack<int> stk = new Stack<int>();

            BuildGraph(n, edges);

            stk.Push(0);
            
            while (stk.Count != 0)
            {   
                //! DFS magic spell 

                //! 1. Pop current element
                int curr=stk.Pop();
                //!2. Mark it as visited.  
                seen.Add(curr);

                List<int> neighbours =_graph[curr];

                foreach (int neighbour in neighbours)
                {
                    //!3. Fetch its all univisited neighbours 
                    if (seen.Contains(neighbour))
                        continue;
                    //!4. Push them to the stack
                    stk.Push(neighbour);
                    
                }
            }

            return seen.Count == n;
        }

        //!Union find without path and rank compression
        //!Graph is valid tree only if there is no cycle and all the nodes are connected. 
        public bool ValidTree1(int n, int[][] edges)
        {
            _parent = Enumerable.Repeat(-1, n).ToArray();

            BuildGraph(n, edges);
            foreach (int[] edge in edges)
            {
                int x = Find(edge[0]);
                int y = Find(edge[1]);

                if (x == y)
                {
                    return false;
                }

                Union(x, y);
            }
            int parentCount = 0;
            //! if all the nodes are not connected then there are multiple parents and its not valid tree. 
            for (int i = 0; i < _parent.Length; i++)
            {
                if (_parent[i] == -1)
                {
                    ++parentCount;
                }

                if (parentCount > 1)
                {
                    return false;
                }
            }

            return true;
        }
        private void Union(int x, int y)
        {
            //!Parent of x node is y
            _parent[x] = y;
        }

        private int Find(int v)
        {
            if (_parent[v] == -1)
                return v;
            return Find(_parent[v]);

        }

        private void BuildGraph(int n, int[][] edges)
        {
            _graph = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                _graph.Add(new List<int>());

            }

            foreach (int[] edge in edges)
            {
                _graph[edge[0]].Add(edge[1]);
                _graph[edge[1]].Add(edge[0]);
            }
        }
    }
}
