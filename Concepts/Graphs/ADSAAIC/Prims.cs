using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.ADSAAIC
{

    public class Prims
    {
        private const int NIL = -1;
        int vertex;
        // adj matrix representation 
        private int[,] adj;
        // To get the path 
        int[] predecessor;
        // To find the length of shortest path
        int[] pathLength;
        // 0 for temporary and 1 for permanent
        Status2[] status2;

        public Prims(int v)
        {
            vertex = v;
            status2 = new Status2[vertex];
            adj = new int[vertex, vertex];
            predecessor = new int[vertex];
            pathLength = new int[vertex];
            for (int i = 0; i < vertex; i++)
            {
                predecessor[i] = NIL;
                pathLength[i] = int.MaxValue;
                status2[i] = Status2.Temporary;
            }
        }

        public void AddEdge(int src, int dest, int weight)
        {
            adj[src, dest] = weight;
        }

        /// <summary>
        // Prim's algorithm to find minimum spanning tree
        // Spanning tree: subgraph that contains all the nodes and some(or all) the edges
        // Minimum Spanning Tree: A spanning tree whose sum of the weight is minimum 
        /// </summary>
        /// <param name="start"></param>

        public void PrimsAlgorithim(int start)
        {

            // Store the number of edges that are included in minimum spanning tree. 
            int edgeInTree = 0;
            // stores the weight of the minimum spanning tree
            int wtTree = 0;

            // Make the length of source/root vertex equal to 0. 
            // The source/root vertex will  become the first one permanant
            pathLength[start] = 0;

            while (true)
            {
                // Find temporary vertex with minimum path length and make it current vertex
                int c = TempVertexMinPL();
                if (c == NIL)
                {
                    if (edgeInTree == vertex - 1)
                    {
                        Console.WriteLine($"Weight of minimum spanning tree is:{wtTree}");
                        return;
                    }
                    else
                    {
                        throw new InvalidOperationException("Graph is not connected,Spanning tree not possible");
                    }
                }
                // change the Status of current vertex to permanant
                status2[c] = Status2.Permanent;
                // include edge (predecessor[c],c) in the tree
                // excluding start as predecessor is nill for the root vertex
                if (c != start)
                {
                    //increment the edge 
                    edgeInTree++;
                    // display the edge
                    Console.WriteLine($"({predecessor[c]},{c})");
                    // add the weight of the edge to the weight of the minimumn spanning tree
                    wtTree = wtTree + adj[predecessor[c], c];
                }

                for (int v = 0; v < vertex; v++)
                {
                    // Check all the vertices adjacent to c and Status is Temporary
                    if (IsAdjacent(c, v) && status2[v] == Status2.Temporary)
                    {
                        // if weight of the edge from c to v is less than path length 
                        if (adj[c, v] < pathLength[v])
                        {
                            predecessor[v] = c;
                            pathLength[v] = adj[c, v];
                        }
                    }
                }
            }
        }

        private bool IsAdjacent(int u, int v)
        {
            return (adj[u, v] != 0);
        }

        //  This method will return the vertex with minimum path length or 
        // return NIL if no temporary vertex left or all the temporary vertex left 
        // have path length infinity

        private int TempVertexMinPL()
        {
            int min = int.MaxValue;
            int x = NIL;
            for (int i = 0; i < vertex; i++)
            {
                if (status2[i] == Status2.Temporary && pathLength[i] < min)
                {
                    min = pathLength[i];
                    x = i;
                }
            }
            return x;
        }
    }
    public enum Status2
    {
        // Shortest path to the vertex has not been finalized. 
        Temporary,
        // Shortest path to vertex is final
        Permanent
    }
}
