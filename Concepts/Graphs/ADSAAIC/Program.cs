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
            ShortestPath sp = new ShortestPath(5);

            sp.AddEdge(0,1);
            sp.AddEdge(0, 3);
            sp.AddEdge(1, 2);
            sp.AddEdge(2, 4);
            sp.AddEdge(4, 3);

            sp.FindShortestPath(0);
        }

    }
}
