using Graphs.GraphRepresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.GeeksForGeeks
{
    class Program
    {
        static void Main5(string[] args)
        {
            //Graph3 g = new Graph3(5);
            //g.AddDirectedEdge(1, 0);
            //g.AddDirectedEdge(0, 4);
            //g.AddDirectedEdge(4, 3);
            //g.AddDirectedEdge(3, 2);
            ////g.AddDirectedEdge(2, 1);

            //MotherVertex m = new MotherVertex(g);
            //int[] arr = new int[1];
            //for (int i = 0; i < g.count; i++)
            //{
            //    m.Initialize(g);
            //    m.DFS(i, arr);
            //    if (arr[0] == g.count)
            //    {
            //        Console.Write($"Mother Vertex:{i}");
            //        break;
            //    }
            //    arr[0] = 0;
            //}
            /*
             Geeks for geeks -- Mother vertex
            //*/
            //MotherVertex2 m2 = new MotherVertex2(7);

            //m2.AddDirectedEdge(0, 1);
            //m2.AddDirectedEdge(0, 2);
            //m2.AddDirectedEdge(1, 3);
            //m2.AddDirectedEdge(4, 1);
            //m2.AddDirectedEdge(6, 4);
            //m2.AddDirectedEdge(5, 6);
            //m2.AddDirectedEdge(5, 2);
            //m2.AddDirectedEdge(6, 0);          

            //Console.Write($"A mother vertex is:{m2.FindMother()} ");
            /*             
             Transitive closure              
             */
            //int[,] graph = new int[,] {
            //    {1, 1, 0, 1},
            //    {0, 1, 1, 0},
            //    {0, 0, 1, 1},
            //    {0, 0, 0, 1}
            //};

            //TransitiveClosure tc = new TransitiveClosure(graph);
            /*             
             Transitive closure geeks for geeks              
            */

            //TransitiveClosure2 tc2 = new TransitiveClosure2(4);
            //tc2.AddEdge(0, 1);
            //tc2.AddEdge(0, 2);
            //tc2.AddEdge(1, 2);
            //tc2.AddEdge(2, 0);
            //tc2.AddEdge(2, 3);
            //tc2.AddEdge(3, 3);

            //tc2.GetTransitiveClosure();

            //IterativeDepthFirstTraversal g = new IterativeDepthFirstTraversal(5);

            //g.AddEdge(1, 0);
            //g.AddEdge(0, 2);
            //g.AddEdge(2, 1);
            //g.AddEdge(0, 3);
            //g.AddEdge(1, 4);
            //Console.Write("Following is the Depth First Traversal\n");
            //g.DFSIterative(0);

            //int vertices = 5;
            //IterativeDepthFirstTraversal2 g = new IterativeDepthFirstTraversal2(vertices);
            //g.AddEdge(1, 0);
            //g.AddEdge(2, 1);
            //g.AddEdge(3, 4);
            //g.AddEdge(4, 0);

            //g.DFS();

            /***************************************************************/
            //Count the number of nodes at given level in a tree using BFS.
            /***************************************************************/
            //int level = 2;
            //CountNodesAtLevel g = new CountNodesAtLevel(6);
            //g.AddEdge(0, 1);
            //g.AddEdge(0, 2);
            //g.AddEdge(1, 3);
            //g.AddEdge(2, 4);
            //g.AddEdge(2, 5);            
            //Console.WriteLine($"Number of Nodes at level {level}:{g.BFS(level)}");

            /***************************************************************/
            //Graph – Count all paths between source and destination
            /***************************************************************/

            //CountPaths countPaths = new CountPaths(6);
            //countPaths.AddEdge(0, 1);
            //countPaths.AddEdge(0, 2);
            //countPaths.AddEdge(1, 2);
            //countPaths.AddEdge(1, 3);
            //countPaths.AddEdge(3, 4);
            //countPaths.AddEdge(2, 3);
            //countPaths.AddEdge(4, 5);

            //countPaths.CountPathsBetweenNodes(0, 5);

            CountTrees g = new CountTrees(5);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(3, 4);

            Console.WriteLine(g.CountTreesInForest());

            Console.Read();
        }
    }
}
