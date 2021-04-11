using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _886
    {
        /// <summary>
        //! Same as Leetcode 785 
        //  # <image url="https://leetcode.com/problems/is-graph-bipartite/Figures/785/color.png"  scale="0.4"/>
        /// </summary>
        public bool PossibleBipartition0(int N, int[][] dislikes)
        {

            Dictionary<int, List<int>> graph = BuildGraph(N, dislikes);

            Dictionary<int, int> nodeColor = new Dictionary<int, int>();
            for (int i = 1; i <= N; ++i)
            {
                nodeColor.Add(i, 0);
            }

            foreach (var keyValue in graph)
            {
                if (nodeColor[keyValue.Key] == 0)
                {
                    if (!IsValidColor(graph, nodeColor, 1, keyValue.Key))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool IsValidColor(Dictionary<int, List<int>> graph,
                              Dictionary<int, int> nodeColor, int color,
                              int at)
        {
            nodeColor[at] = color;
            int nextColor = -color;
            foreach (int neighbor in graph[at])
            {
                //! If we have already marked the node then its value will not be 0
                if (nodeColor[neighbor] != 0)
                {
                    //! Check if color is compatible
                    if (nodeColor[neighbor] == color)
                    {
                        return false;
                    }
                }
                else
                {
                    if (!IsValidColor(graph, nodeColor, -color, neighbor))
                    {
                        return false;
                    }
                }              
            }

            return true;
        }

        private Dictionary<int, List<int>> BuildGraph(int n, int[][] dislikes)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 1; i <= n; ++i)
            {
                graph.Add(i, new List<int>());
            }
            foreach (int[] dislike in dislikes)
            {
                graph[dislike[0]].Add(dislike[1]);
                graph[dislike[1]].Add(dislike[0]);
            }

            return graph;
        }

        public bool PossibleBipartition(int N, int[][] dislikes)
        {
            Dictionary<int, List<int>> graph = BuildGraph(N, dislikes);
            Dictionary<int, int> color = new Dictionary<int, int>();

            for (int i = 1; i <= N; ++i)
            {
                color[i] = -1;
            }

            foreach (var keyValue in graph)
            {
                if (color[keyValue.Key] == -1)
                {
                    bool result = BFS(keyValue.Key, graph, color);
                    if (!result)
                        return false;
                }
            }

            return true;
        }

        private bool BFS(int start,
                         Dictionary<int, List<int>> graph,
                         Dictionary<int, int> color
                        )
        {
            Queue<int> queue = new Queue<int>();
            color[start] = 0;
            queue.Enqueue(start);

            while (queue.Count != 0)
            {
                int curr = queue.Dequeue();
                List<int> neighbors = graph[curr];

                foreach (int neighbor in neighbors)
                {
                    if (color[neighbor] == color[curr])
                    {
                        return false;
                    }

                    if (color[neighbor] == -1)
                    {

                        color[neighbor] = 1 - color[curr];
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return true;
        }
    }
}
