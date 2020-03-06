using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Practice
{
    public class Graph2
    {
        // List of list of integers
        private readonly List<List<int>> Nodes;
        private readonly int NodesCount;
        public Graph2(int n)
        {
            NodesCount = n;

            Nodes = new List<List<int>>();
            // initializing every element with empty lists so that it works when we try to add element
            for (int i = 0; i < NodesCount; i++)
            {
                Nodes.Add(new List<int>());
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
            for (int i = 0; i < Nodes.Count; i++)
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
