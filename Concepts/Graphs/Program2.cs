using Graphs.Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program2
    {
        static void Main3(string[] args)
        {
            //GraphAM graphAM = new GraphAM(3);
            //graphAM.AddEdge(0,1);
            //graphAM.AddEdge(1,2);
            //graphAM.AddEdge(2,0);
            //graphAM.Print();

            Graph graph = new Graph(3);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
           
            BFS bfs = new BFS(graph,0);
            

            Console.ReadLine();

        


        }
    }
}
