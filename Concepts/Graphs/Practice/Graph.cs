using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Practice
{
    public class Graph
    {
        // an array of type List<int>
       public List<int>[] Nodes { get; }
        public int NodesCount { get; }
        public Graph(int n)
        {
            
            NodesCount = n;
            // an array of type List<int> containing n(NodesCount) null references 
            Nodes = new List<int>[NodesCount];
            // initializing with empty lists so that it works when we try to add element
            for (int i = 0; i < NodesCount; i++)
            {
                Nodes[i] = new List<int>();
            }
        }
        public void AddEdge(int source, int destination)
        {
            List<int> existingElements = Nodes[source];
            existingElements.Add(destination);
            Nodes[source] = existingElements;

            existingElements = Nodes[destination];
            existingElements.Add(source);
            Nodes[destination] = existingElements;
        }
        public void Print()
        {
            for (int i = 0; i < Nodes.Length; i++)
            {
                Console.Write($"Node:{i} has edge with Node(s): ");
                foreach (int node in Nodes[i])
                {
                    Console.Write($"{node} ");
                }
                Console.WriteLine();

            }


        }
    }
}
