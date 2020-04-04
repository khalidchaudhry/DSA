using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.ADSAAIC
{

    public class Dijkstra
    {
        private const int NIL = -1;
        int vertex;
        // adj matrix representation 
        private int[,] adj;
        // To get the path 
        // initially all predecessor will be NIL(-1).
        int[] predecessor;
        // To find the length of shortest path
        // initially all paths length will be infinity(Int.MaxValue). 
        int[] pathLength;
        // 0 for temporary and 1 for permanent
        // temporary means shortest path has not been finalized. 
        // permanent means shortest path has been finalized. 
        // initially all the vertices will be of temporary status and each step of the algoirthm 
        //  we will change the state of the vertex from temporary to permanent. 
        Status[] status;

        public Dijkstra(int v)
        {
            vertex = v;
            status = new Status[vertex];
            adj = new int[vertex, vertex];
            predecessor = new int[vertex];
            pathLength = new int[vertex];
            for (int i = 0; i < vertex; i++)
            {
                predecessor[i] = NIL;
                pathLength[i] = int.MaxValue;
                status[i] = Status.Temporary;
            }
        }

        public void AddEdge(int src, int dest, int weight)
        {
            adj[src, dest] = weight;
        }

        // Gives shortest distance from source vertex to all other vertices in the graph.
        // Works for non-negative weights only
        public void DijkstraAlgorithim(int start)
        {
            // Make the length of source vertex equal to 0. 
            // The source vertex will  become the first one  permanant
            pathLength[start] = 0;

            while (true)
            {
                // Find temporary vertex with minimum path length and make it current vertex
                int c = TempVertexMinPL();
                if (c == NIL)
                {
                    return;
                }
                // change the status of current vertex to permanant
                status[c] = Status.Permanent;

                for (int v = 0; v < vertex; v++)
                {
                    // Check all the vertices adjacent to c and status is Temporary
                    if (IsAdjacent(c, v) && status[v] == Status.Temporary)
                    {
                        //relabel them if satisfy the condition that  
                        // if pathLength(current vertex) + edgeweight(currentVertex,temporaryvertex) < pathLength(temporaryvertex)
                        if (pathLength[c] + adj[c, v] < pathLength[v])
                        {
                            predecessor[v] = c;
                            pathLength[v] = pathLength[c] + adj[c, v];
                        }
                    }
                }
            }
        }
        public void FindPaths(int start)
        {
            Console.WriteLine($"source vertex : {start}");

            for (int v = 0; v < vertex; v++)
            {
                Console.WriteLine($"Destination vertex:{v}");
                if (pathLength[v] == int.MaxValue)
                {
                    Console.WriteLine($"There is no path from source:{start} to vertex:{v}");
                }
                else
                {
                    FindPath(start, v);
                }
            }

        }

        private void FindPath(int start, int v)
        {
            int u;
            int[] path = new int[vertex];
            // shortest distance from s to v
            int sd = 0;
            int count = 0;
            while (v != start)
            {
                path[count++] = v;
                u = predecessor[v];
                sd += adj[u, v];
                v = u;
            }
            //count++;
            path[count] = start;

            Console.Write("Shortest path is: ");
            int i;
            for (i = count; i > 0; i--)
            {
                Console.Write($"{path[i]}-->");
            }
            Console.Write($"{path[i]}");

            Console.WriteLine($" Shortest distance is:{sd} ");
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
                if (status[i] == Status.Temporary && pathLength[i] < min)
                {
                    min = pathLength[i];
                    x = i;
                }
            }
            return x;
        }
    }
    public enum Status
    {
        // Shortest path to the vertex has not been finalized. 
        Temporary,
        // Shortest path to vertex is final
        Permanent
    }
}
