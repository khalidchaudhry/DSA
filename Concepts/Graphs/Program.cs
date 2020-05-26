using Graphs.AlgorithmsII.ConnectedComponents;
using Graphs.BFSPaths;
using Graphs.DFSPaths;
using Graphs.GraphRepresentation;
using Graphs.KoderDojo;
using Graphs.Medium;
using Graphs.Traversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            /***********************************************************************************/
            // Hermant Jain book
            /***********************************************************************************/
            // Adjacency Matrix representation
            //GraphAM graphAM = new GraphAM(5);
            //graphAM.AddUnDirectedEdge(0, 1, 1);
            //graphAM.AddUnDirectedEdge(0, 2, 1);
            //graphAM.AddUnDirectedEdge(1, 2, 1);
            //graphAM.AddUnDirectedEdge(3, 2, 1);

            //graphAM.Print();
            /****
           0---------------->1
           |              ↗  |
           |           ↗     |
           |         ↗       |
           |       ↗         |
           ↓   ↗             ↓
           4------>3<------->2



            *********/
            //Adjacency list representation
            /*
            Graph graph = new Graph(5);
            graph.AddDirectedEdge(0, 1, 3);
            graph.AddDirectedEdge(0, 4, 2);
            graph.AddDirectedEdge(1, 2, 1);
            graph.AddDirectedEdge(2, 3, 1);
            graph.AddDirectedEdge(3, 2, 1);
            graph.AddDirectedEdge(4, 1, -2);
            graph.AddDirectedEdge(4, 3, -1);

            DFS.DFSTraversalStack(graph, 0);
            Console.WriteLine("---------------------");
            //DFS.DFSTraversalStack2(graph, 0);

            //Console.WriteLine("---------------------");

            */
            /***********************************************************************************/
            //https://www.koderdojo.com/blog/depth-first-search-algorithm-in-csharp-and-net-core
            /***********************************************************************************/
            /*
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

            var graph = new Graph<int>(vertices, edges);
            var algorithms = new Algorithms();

            Console.WriteLine(string.Join(", ", algorithms.DFS(graph, 1)));
            //# 1, 3, 6, 5, 8, 9, 10, 7, 4, 2
            */
            /*
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

            var graph = new Graph<int>(vertices, edges);
            var algorithms = new Algorithms();

            var path = new List<int>();

            Console.WriteLine(string.Join(", ", algorithms.DFS(graph, 1, v => path.Add(v))));
            //# 1, 3, 6, 5, 8, 9, 10, 7, 4, 2

            Console.WriteLine(string.Join(", ", path));
            //# 1, 3, 6, 5, 8, 9, 10, 7, 4, 2
            */

            /****
           0---------------->1
           |              ↗  |
           |           ↗     |
           |         ↗       |
           |       ↗         |
           ↓   ↗             ↓
           4------>3<------->2
                              
           *********/
            /*
             var vertices = new[] { 0, 1, 2, 3, 4 };
             var edges = new[]{
                 Tuple.Create(0,1), Tuple.Create(0,4),
                 Tuple.Create(1,2),
                 Tuple.Create(2,3),
                 Tuple.Create(3,2),
                 Tuple.Create(4,1), Tuple.Create(4,3)};

             var graph = new Graph<int>(vertices, edges);
             var algorithms = new Algorithms();

             HashSet<int> seen = new HashSet<int>();
             algorithms.DFS2Recursive<int>(graph, 0, seen);
             Console.WriteLine("-------------------------");
             algorithms.DFS2Iterative<int>(graph, 0);
             */

            /****
         0---------------->1
         |              ↗  |
         |           ↗     |
         |         ↗       |
         |       ↗         |
         ↓   ↗             ↓
         4------>3<------->2

         *********/

            /***********************************************************************************/
            //Algorithms Part II by Robert
            /***********************************************************************************/

            //Graph graph = new Graph(5);
            //graph.AddDirectedEdge(0, 1, 3);
            //graph.AddDirectedEdge(0, 4, 2);
            //graph.AddDirectedEdge(1, 2, 1);
            //graph.AddDirectedEdge(2, 3, 1);
            //graph.AddDirectedEdge(3, 2, 1);
            //graph.AddDirectedEdge(4, 1, -2);
            //graph.AddDirectedEdge(4, 3, -1);
            //bool[] visited = new bool[5];
            //Console.WriteLine("Recursive version ");
            //DFS.DFSTraversalRecursive(graph, 0, visited);
            //Console.WriteLine("--------------------------------");
            //Console.WriteLine("Iterative  version ");
            //DFS.DFSTraversalStack(graph, 0);

            //BFS.BFSTraversalQueue(graph, 0);

            //int s = 0;

            //DepthFirstPaths dfs = new DepthFirstPaths(graph, s);

            //for (int v = 0; v < graph.count; v++)
            //{
            //    if (dfs.hasPathTo(v))
            //    {
            //        Console.Write($"{s} to {v}:");
            //        foreach (int x in dfs.PathTo(v))
            //        {
            //            if (x == s)
            //                Console.Write(x);
            //            else
            //                Console.Write("-" + x);
            //        }
            //        Console.WriteLine();
            //    }

            //    else
            //    {
            //        Console.WriteLine($"{s} to {v}:  not connected");
            //    }
            //}

            /*
            int s = 0;
            
            BreadthFirstPaths bfs = new BreadthFirstPaths(graph, s);

            for (int v = 0; v < graph.count; v++)
            {
                if (bfs.hasPathTo(v))
                {
                    Console.Write($"{s} to {v}({bfs.DistTo(v)}) :");
                    foreach (int x in bfs.PathTo(v))
                    {
                        if (x == s)
                            Console.Write(x);
                        else
                            Console.Write("-" + x);
                    }
                    Console.WriteLine();
                }

                else
                {
                    Console.Write($"{s} to {v}:  not connected");
                }
            }
            
           */
            /****
              0---------------->1
              |              ↗  |
              |           ↗     |
              |         ↗       |
              |       ↗         |
              ↓   ↗             ↓
              4------>3<------->2

              5-----6

              7----8


            *********/
            /*
            Graph graph = new Graph(9);
            graph.AddDirectedEdge(0, 1, 3);
            graph.AddDirectedEdge(0, 4, 2);
            graph.AddDirectedEdge(1, 2, 1);
            graph.AddDirectedEdge(2, 3, 1);
            graph.AddDirectedEdge(3, 2, 1);
            graph.AddDirectedEdge(4, 1, -2);
            graph.AddDirectedEdge(4, 3, -1);

            graph.AddDirectedEdge(5, 6, 1);
            graph.AddDirectedEdge(7, 8, 1);

            CC cc = new CC(graph);

            Console.WriteLine(cc.IsConnected(1,6));

            Console.WriteLine(cc.CCSize(4));
            Console.WriteLine(cc.CCCount());
            */
            ///////////////////////////////////////

            //////////////////////////////////////
            //Graph3 g = new Graph3(3);
            //g.AddUnDirectedEdge(0,1);
            //g.AddUnDirectedEdge(1, 2);
            //g.AddUnDirectedEdge(2, 0);
            //g.Print();

            int n = 5;
            int[][] edges = new int[][]
                {
                    new int[]{0,1},
                    new int[]{1,2},
                    new int[]{2,3},
                     new int[]{3,4},
                };
            ConnectedComponents cc = new ConnectedComponents();

            var result=cc.CountComponentsIterative(5,edges);


            Console.Read();
        }
    }
}
