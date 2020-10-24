using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1129
    {
        /// <summary>
        /// https://leetcode.com/problems/shortest-path-with-alternating-colors/discuss/340246/Java-DFS-and-BFS-two-codes-each-wo-duplication-check.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="red_edges"></param>
        /// <param name="blue_edges"></param>
        /// <returns></returns>
        public int[] ShortestAlternatingPaths0(int n, int[][] red_edges, int[][] blue_edges)
        {
            //!Number of steps needed to reach to node 0 starting from red or blue. 
            //!steps[0]  ---starting from red edge
            //!steps[1]--- startign from blue edge
            int[][] steps = new int[2][];
            steps[0] = new int[n];
            steps[1] = new int[n];
            //! Initialized with MAX values, except that 2 starting points initialized with 0.
            for (int i = 1; i < n; i++)
            {
                steps[0][i] = int.MaxValue;
                steps[1][i] = int.MaxValue;
            }

            // Build graphs for red and blue edges, respectively.
            Dictionary<int, List<int>> red = new Dictionary<int, List<int>>();
            foreach (int[] redEdge in red_edges)
            {
                if (!red.ContainsKey(redEdge[0]))
                {
                    red[redEdge[0]] = new List<int>();
                }

                red[redEdge[0]].Add(redEdge[1]);
            }

            Dictionary<int, List<int>> blue = new Dictionary<int, List<int>>();
            foreach (int[] blueEdge in blue_edges)
            {
                if (!blue.ContainsKey(blueEdge[0]))
                {
                    blue[blueEdge[0]] = new List<int>();
                }

                blue[blueEdge[0]].Add(blueEdge[1]);
            }


            Queue<(int node, int color)> queue = new Queue<(int node, int color)>();

            //! 0 =Red edge
            //! 1=Blue edge
            //! first dimension = node,  second dimension=color
            //! Not sure which color edge the first node will take hence queue both
            queue.Enqueue((0, 0));
            queue.Enqueue((0, 1));

            while (queue.Count != 0)
            {
                (int node, int color) = queue.Dequeue();
                Dictionary<int, List<int>> map = color == 0 ? red : blue;

                if (!map.ContainsKey(node)) { continue; }

                foreach (int neighbor in map[node])
                {
                    int oppositeColor = 1 - color;
                    if (steps[oppositeColor][neighbor] == int.MaxValue)
                    {    // 1 - color: the other color.
                        steps[oppositeColor][neighbor] = steps[color][node] + 1;

                        queue.Enqueue((neighbor, oppositeColor));
                    }
                }
            }

            for (int i = 1; i < n; ++i)
            {
                int shorter = Math.Min(steps[0][i], steps[1][i]);
                steps[0][i] = shorter == int.MaxValue ? -1 : shorter;
            }

            return steps[0];
        }





        /// <summary>
        //https://leetcode.com/problems/shortest-path-with-alternating-colors/discuss/340258/Java-BFS-Solution-with-Video-Explanation
        /// </summary>
        /// <param name="n"></param>
        /// <param name="red_edges"></param>
        /// <param name="blue_edges"></param>
        /// <returns></returns>
        public int[] ShortestAlternatingPaths(int n, int[][] red_edges, int[][] blue_edges)
        {
            int[][] graph = new int[n][];
            int len = 0; //! path length
            HashSet<string> visited = new HashSet<string>();
            int[] result = new int[n];

            BuildGraph(graph, n, red_edges, blue_edges);
            //! array in queue will contain two dimensions 1. node 2. Color
            Queue<int[]> queue = new Queue<int[]>();
            //! Not sure which color edge the first node will take
            queue.Enqueue(new int[] { 0, 1 });
            queue.Enqueue(new int[] { 0, -1 });

            while (queue.Count != 0)
            {
                int size = queue.Count;
                len++;
                for (int i = 0; i < size; i++)
                {
                    int[] curr = queue.Dequeue();
                    int node = curr[0];
                    int color = curr[1];
                    int oppositeColor = -color;

                    for (int j = 1; j < n; j++)
                    {
                        if (graph[node][j] == oppositeColor ||
                            graph[node][j] == 0)
                        {
                            string nodeAndColor = $"{j}{oppositeColor}";
                            //!if addition was not successful.Means node already exists.  Continue 
                            if (!visited.Add(nodeAndColor))
                            {
                                continue;
                            }

                            queue.Enqueue(new int[] { j, oppositeColor });
                            result[j] = Math.Min(result[j], len);
                        }
                    }
                }
            }

            return result;
        }


        /// <summary>
        //!Red==1
        //!Blue==-1
        //!Both==0
        //!No Edge=-n;
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="red_edges"></param>
        /// <param name="blue_edges"></param>
        private void BuildGraph(int[][] graph, int n, int[][] red_edges, int[][] blue_edges)
        {

            //! Does not work need to iniliaze array variables with -1
            for (int i = 0; i < n; ++i)
            {
                graph[i] = new int[n];
            }

            foreach (int[] red_edge in red_edges)
            {
                int from = red_edge[0];
                int to = red_edge[1];
                graph[from][to] = 1;
            }

            foreach (int[] blue_edge in blue_edges)
            {
                int from = blue_edge[0];
                int to = blue_edge[1];
                //! It means we have edges with both the colors
                if (graph[from][to] == 1)
                {
                    graph[from][to] = 0;
                }
                else
                {
                    graph[from][to] = -1;
                }
            }
        }
    }
}
