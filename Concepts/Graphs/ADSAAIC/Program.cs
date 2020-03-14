using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.ADSAAIC
{
    public class Program
    {
        public static void Main()
        {
            //ShortestPath sp = new ShortestPath(5);

            //sp.AddEdge(0,1);
            //sp.AddEdge(0, 3);
            //sp.AddEdge(1, 2);
            //sp.AddEdge(2, 4);
            //sp.AddEdge(4, 3);

            //sp.FindShortestPath(0);

            //RecursiveDepthFirstSearch graph = new RecursiveDepthFirstSearch(3);

            //graph.AddEdge(0, 1);
            //graph.AddEdge(1, 2);

            //graph.DFSTraversal(0);

            //Dijkstra d = new Dijkstra(3);
            //d.AddEdge(0, 1, 1);
            //d.AddEdge(1, 2, 2);
            //d.AddEdge(0, 2, 5);

            //d.DijkstraAlgorithim(0);
            //d.FindPaths(0);

            //Prims p = new Prims(3);
            //p.AddEdge(0, 1, 1);
            //p.AddEdge(1, 2, 2);
            //p.AddEdge(0, 2, 5);

            //p.PrimsAlgorithim(0);

            Kruskal k = new Kruskal(3);
            k.AddEdge(0, 1, 1);
            k.AddEdge(1, 2, 2);
            k.AddEdge(0, 2, 5);

            k.KruskalAlgorithm();

            Console.ReadLine();
        }

    }
}
