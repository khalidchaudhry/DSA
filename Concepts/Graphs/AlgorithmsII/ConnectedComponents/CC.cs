using Graphs.GraphRepresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.AlgorithmsII.ConnectedComponents
{
    public class CC
    {

        private bool[] marked;  // marked[v] = has vertex v been marked?
        private int[] id;       // id[v] = id of connected component containing v
        private int count;       // number of connected components
        private int[] size;         // size[id] = number of vertices in given component

        public CC(Graph graph)
        {
            marked = new bool[graph.count];
            id = new int[graph.count];
            size = new int[graph.count];

            for (int i = 0; i < graph.count; i++)
            {
                if (!marked[i])
                {
                    // run DFS from one vertext in each component. 
                    DFS(graph, i);
                    count++;
                }

            }
        }
        private void DFS(Graph G, int v)
        {
            marked[v] = true;
            // all the vertices discovered in same call of dfs have the same id
            id[v] = count;
            size[count]++;
            foreach (var w in G.adj[v])
            {
                if (!marked[w.dest])
                {
                    DFS(G, w.dest);
                }
            }
        }
        /**
     * Returns true if vertices {@code v} and {@code w} are in the same
     * connected component.
     *
     * @param  v one vertex
     * @param  w the other vertex
     * @return {@code true} if vertices {@code v} and {@code w} are in the same
     *         connected component; {@code false} otherwise
     * @throws IllegalArgumentException unless {@code 0 <= v < V}    
     */
        public bool IsConnected(int v, int w)
        {

            return id[v] == id[w];
        }

        /**
      * Returns the number of vertices in the connected component containing vertex {@code v}.
      *
      * @param  v the vertex
      * @return the number of vertices in the connected component containing vertex {@code v}
      * @throws IllegalArgumentException unless {@code 0 <= v < V}
      */
        public int CCSize(int v)
        {
            return size[id[v]];
        }

        /**
         * Returns the number of connected components in the graph {@code G}.
         *
         * @return the number of connected components in the graph {@code G}
         */
        public int CCCount()
        {
            return count;
        }

        /**
     * Returns the component id of the connected component containing vertex {@code v}.
     *
     * @param  v the vertex
     * @return the component id of the connected component containing vertex {@code v}
     * @throws IllegalArgumentException unless {@code 0 <= v < V}
     */
        public int Id(int v)
        {
            return id[v];
        }
    }
}
