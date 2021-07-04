using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeGraphs.Medium
{
    public class _785
    {

        /// <summary>
        //! DFS recursive . Similar to pattern used in question 207,802 except here we are using 2 colors and alternating them
        //! Same as 886
        //  # <image url="https://leetcode.com/problems/is-graph-bipartite/Figures/785/color.png"  scale="0.4"/>
        /// </summary>       
        public bool IsBipartite2(int[][] graph)
        {

            Dictionary<int, int> colors = new Dictionary<int, int>();
            for (int i = 0; i < graph.Length; ++i)
            {
                colors.Add(i, 0);
            }
            //! The reason for below loop is because as per the question 
            //! The graph may not be connected, meaning there may be two nodes u and v such that there is no path between them.
            for (int i = 0; i < graph.Length; ++i)
            {
                //! If color already defined for the node , there is no point of coloring it 
                if (colors[i] == 0)
                {
                    if (!IsValidColor(graph, colors, 1, i))
                        return false;
                }
            }
            return true;

        }

        private bool IsValidColor(int[][] graph, Dictionary<int, int> colors, int color, int at)
        {
        
            colors[at] = color;
            int nextColor = -color;

            foreach (int neighbor in graph[at])
            {
                //! If we have already marked the node then its value will not be 0
                if (colors[neighbor] != 0)
                {
                    //! Check if color is compatible
                    if (colors[neighbor] == color)
                        return false;
                }
                else
                {
                    if (!IsValidColor(graph, colors, nextColor, neighbor))
                        return false;
                }
            }

            return true;
        }
        
        /// <summary>
        ///https://www.youtube.com/watch?v=FofydiwP5YQ 
        /// </summary>
        public bool IsBipartite(int[][] graph)
        {
            //! there is no need to build graph first as input is already in the form to use it for graph
            List<List<int>> g = BuildGraph(graph);
            Dictionary<int, int> color = new Dictionary<int, int>();

            for (int i = 0; i < graph.Length; i++)
            {
                //! -1 represents that color not set for the graph
                color.Add(i, -1);
            }

            for (int i = 0; i < graph.Length; i++)
            {
                if (color[i] == -1)
                {
                    bool result = IsValidColor(i, g, color);
                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool IsValidColor(int i, List<List<int>> g, Dictionary<int, int> color)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(i);
            //! 0 ---> blue   1----> green
            color[i] = 0; //! similar to marking it as visited
            while (queue.Count != 0)
            {
                int curr = queue.Dequeue();
                foreach (int neighbor in g[curr])
                {
                    //! if color of node is same as its neighbor than it means we can't sperate them into seperate groups 
                    if (color[neighbor] == color[curr])
                    {
                        return false;
                    }
                    //!if neighbor not colored yet than lets color it.
                    //! We are also using color map here to check if node is visited or not 
                    if (color[neighbor] == -1)  //! -1 similar to checking that node is not visited
                    {
                        queue.Enqueue(neighbor);
                        //! 1 - color[curr] means we are flipping the color from 0 to 1 or 1 to 0
                        //! e.g. if curr node color 0 then 1-0=1 hence we will give color 1 to our neighbor 
                        color[neighbor] = 1 - color[curr];
                    }
                }
            }
            return true;
        }

        /// <summary>
        //! Same as above BFS except we are using input as is rather than first creating graph
        /// </summary>       
        private bool BFS2(int i, int[][] g, Dictionary<int, int> color)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(i);
            //! 0 ---> blue   1----> green
            color[i] = 0;//! equivalent of marking it as visited
            while (queue.Count != 0)
            {
                int curr = queue.Dequeue();
                foreach (int neighbor in g[curr])
                {
                    //! if color of node is same as its neighbor than it means we can't sperate them into seperate groups 
                    if (color[neighbor] == color[curr])
                    {
                        return false;
                    }
                    //!if neighbor not colored yet than lets color it.
                    //! We are also using color map here to check if node is visited or not 
                    if (color[neighbor] == -1) //! -1 equivalent of not visited
                    {
                        queue.Enqueue(neighbor);
                        //! 1 - color[curr] means we are flipping the color from 0 to 1 or 1 to 0
                        //! e.g. if curr node color 0 then 1-0=1 hence we will give color 1 to our neighbor 
                        color[neighbor] = 1 - color[curr];
                    }
                }
            }
            return true;
        }



        private List<List<int>> BuildGraph(int[][] graph)
        {
            List<List<int>> g = new List<List<int>>();

            for (int i = 0; i < graph.Length; i++)
            {
                g.Add(new List<int>());
            }

            for (int i = 0; i < graph.Length; i++)
            {

                g[i].AddRange(graph[i]);
            }

            return g;

        }
    }
}
