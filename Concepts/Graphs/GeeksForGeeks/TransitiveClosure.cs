using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GeeksForGeeks
{
    public class TransitiveClosure
    {
        // Prints transitive closure of graph[,]  
        // using Floyd Warshall algorithm  
        public TransitiveClosure(int[,] graph)
        {
            //Gets first dimension size 
            // As its nxn matrix so safe to consider second dimension size same as 
            // first dimension
            int v = graph.GetLength(0);

            /* reach[,] will be the output matrix that  
            will finally have the shortest distances  
            between every pair of vertices */

            int[,] reach = new int[v, v];
            int i, j, k;

            /* Initialize the solution matrix same as  
            input graph matrix. Or we can say the  
            initial values of shortest distances are  
            based on shortest paths considering no  
            intermediate vertex. */

            for (i = 0; i < v; i++)
            {
                for (j = 0; j < v; j++)
                {
                    reach[i, j] = graph[i, j];
                }
            }

            /* 
               Add all vertices one by one to the set of intermediate vertices.  
               Before start of a iteration, we have  
               reachability values for all pairs of  
               vertices such that the reachability  
               values consider only the vertices in  
               set {0, 1, 2, .. k-1} as intermediate vertices.  
               After the end of a iteration, vertex no.   
               k is added to the set of intermediate  
               vertices and the set becomes {0, 1, 2, .. k}                             
           */
            for (k = 0; k < v; k++)
            {
                for (i = 0; i < v; i++)
                {
                    for (j = 0; j < v; j++)
                    {
                        reach[i, j] = reach[i, j] != 0 ||
                                    ((reach[i, k] != 0) &&
                                    (reach[k, j] != 0)) ? 1 : 0;
                    }
                }
            }
            // Print the shortest distance matrix  
            PrintSolution(reach);
        }
        private void PrintSolution(int[,] reach)
        {
            int v = reach.GetLength(0);
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    Console.Write(reach[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
