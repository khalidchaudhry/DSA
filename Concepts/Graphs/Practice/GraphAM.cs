using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Practice
{
    public class GraphAM
    {
        private int[,] nodes;
        int nodesCount;
        public GraphAM(int n)
        {           
            nodesCount = n;
            nodes = new int[n,n];                       
        }

        public void AddEdge(int source, int destination, int weight = 1)
        {
            nodes[source,destination] = weight;
            nodes[destination,source] = weight;
        }

        public void Print()
        {
            for (int i = 0; i < nodesCount; i++)
            {
                Console.Write($"Node:{i} has edge with Node(s): ");
                for (int j = 0; j < nodesCount; j++)
                {
                    if (nodes[i,j] != 0)
                    {
                        Console.Write($"{j} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
