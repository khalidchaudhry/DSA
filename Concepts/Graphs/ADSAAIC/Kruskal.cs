using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.ADSAAIC
{
    public class Kruskal
    {
        private const int NIL = -1;
        int vertex;
        // adj matrix representation 
        private int[,] adj;
        // father of the current node
        int[] father;


        public Kruskal(int v)
        {
            vertex = v;
            adj = new int[vertex, vertex];
            father = new int[vertex];

            for (int i = 0; i < vertex; i++)
            {
                father[i] = -1;
            }
        }

        public void AddEdge(int src, int dest, int weight)
        {
            adj[src, dest] = weight;
        }

        public void KruskalAlgorithm()
        {
            PriorityQueue pq = new PriorityQueue();
            int u, v;
            for (u = 0; u < vertex; u++)
            {
                for (v = 0; v < vertex; v++)
                {
                    if (adj[u, v] != 0)
                    {
                        pq.Insert(new Edge(u, v, adj[u, v]));
                    }
                }
            }
            // v1 and v2 represents the two vertices of the edge
            // r1 represents the root of the tree to which v1 belongs 
            // r2 represents the root of the tree to which v2 belongs 
            int v1, v2, r1 = NIL, r2 = NIL;
            int edgesInTree = 0;
            int wtTree = 0;

            while (!pq.IsEmpty() && edgesInTree < vertex - 1)
            {
                Edge edge = pq.Delete();
                // v1=start vertex of the edge
                v1 = edge.u;
                // v2=endvertex of the edge 
                v2 = edge.v;

                // Finding the root vertex of the tree to which v1 belongs 
                v = v1;
                while (father[v] != NIL)
                {
                    v = father[v];
                }
                // Finding the root vertex of the tree to which v2 belongs 
                v = v2;
                while (father[v] != NIL)
                {
                    v = father[v];
                }
                r2 = v;
                /*Edge(v1,v2) is included*/
                if (r1 != r2)
                {
                    edgesInTree++;
                    Console.WriteLine($"{v1}-->{v2}");
                    wtTree += edge.wt;
                    // join the two trees to which vertices v1 and v2 belongs 
                    father[r2] = r1;
                }
            }
            if (edgesInTree < vertex - 1)
            {
                throw new InvalidOperationException("Graph is not connected . No minimum spanning tree possible");
            }

            Console.WriteLine($"Weight of minimum spanning tree is {wtTree}");
        }
    }

    public class Edge
    {
        public int u;
        public int v;
        public int wt;

        public Edge(int u, int v, int wt)
        {
            this.u = u;
            this.v = v;
            this.wt = wt;
        }
    }

    public class PriorityQueue
    {
        private QueueNode front;
        public PriorityQueue()
        {
            front = null;
        }
        public void Insert(Edge e)
        {
            QueueNode temp, p;
            temp = new QueueNode(e);
            // Queue is empty or element to be added has priority  more than the first element
            if (IsEmpty() || e.wt < front.info.wt)
            {
                temp.next = front;
                front = temp;
            }
            else
            {
                p = front;
                // Traverse the list and find a position to insert new node 
                // if priority of p is less keep moving forward . Else stop 
                while (p.next != null && p.next.info.wt <= e.wt)
                {
                    p = p.next;
                }
                // Either at the ends of the list  
                // or at required position  
                temp.next = p.next;
                p.next = temp;

            }
        }

        public Edge Delete()
        {
            Edge e;
            if (IsEmpty())
            {
                throw new InvalidOperationException(" Queue Underflow");
            }
            else
            {
                e = front.info;
                front = front.next;
            }
            return e;
        }

        public bool IsEmpty()
        {
            return front == null;
        }

    }

    public class QueueNode
    {
        public Edge info;
        public QueueNode next;
        public QueueNode(Edge e)
        {
            info = e;
            next = null;
        }
    }
}
