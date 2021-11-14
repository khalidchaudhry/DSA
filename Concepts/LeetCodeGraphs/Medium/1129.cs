using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _1129
    {

        
        public int[] ShortestAlternatingPaths0(int n, int[][] red_edges, int[][] blue_edges)
        {

            Dictionary<int, Dictionary<int, List<int>>> graph = new Dictionary<int, Dictionary<int, List<int>>>();

            for (int i = 0; i < n; ++i)
            {
                Dictionary<int, List<int>> neighbors = new Dictionary<int, List<int>>();
                //! 0 represents red color
                //! 1 represents blue color
                neighbors.Add(0, new List<int>());
                neighbors.Add(1, new List<int>());
                graph.Add(i, neighbors);
            }
            foreach (int[] red_edge in red_edges)
            {
                int from = red_edge[0];
                int to = red_edge[1];

                graph[from][0].Add(to);
            }
            foreach (int[] blue_edge in blue_edges)
            {
                int from = blue_edge[0];
                int to = blue_edge[1];

                graph[from][1].Add(to);
            }
            int[] answer = new int[n];
            for (int i = 0; i < n; ++i)
            {
                answer[i] = int.MaxValue;
            }
            //0 Red
            //1 Blue  

            BFS(graph, 0, answer);
            BFS(graph, 1, answer);
            for (int i = 0; i < n; ++i)
            {
                if (answer[i] == int.MaxValue)
                {
                    answer[i] = -1;
                }
            }
            return answer;

        }
        private void BFS(Dictionary<int, Dictionary<int, List<int>>> graph, int color, int[] answer)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            //! We need to add edgeColor in visited set
            //! since we can have edge with different color that give us path.
            //! see below picture 
            //  # <image url="$(SolutionDir)\Images\1129.jpg"  scale="0.1"/>
            HashSet<(int node, int color)> visited = new HashSet<(int node, int color)>();
            visited.Add((0, color));

            int level = 0;

            while (queue.Count > 0)
            {
                color = color % 2;

                int count = queue.Count;
                while (count > 0)
                {
                    int first = queue.Dequeue();
                    answer[first] = Math.Min(answer[first], level);
                    foreach (int neighbor in graph[first][color])
                    {
                        if (visited.Contains((neighbor, color)))
                        {
                            continue;
                        }
                        visited.Add((neighbor, color));
                        queue.Enqueue(neighbor);
                    }
                    --count;
                }
                ++level;
                ++color;
            }
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
