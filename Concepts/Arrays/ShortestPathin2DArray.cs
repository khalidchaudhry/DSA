using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class ShortestPathin2DArray
    {


        public static int PathExists(char[][] matrix)
        {
            Node n = new Node(0, 0, 0);
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(n);

            while (queue.Count != 0)
            {
                Node dequeue = queue.Dequeue();

                if (matrix[dequeue.x][dequeue.y] == 'D')
                {
                    return dequeue.distanceFromSource;
                }
                else
                {
                    //! Mark it as visited. 
                    matrix[dequeue.x][dequeue.y] = '0';
                    //! Find neighbours not visited
                    List<Node> neighbours = FindNeighbours(dequeue, matrix);

                    neighbours.ForEach(x => queue.Enqueue(x));
                }
            }

            return -1;

        }

        private static List<Node> FindNeighbours(Node node, char[][] matrix)
        {
            List<Node> neighbours = new List<Node>();

            if (node.x - 1 > -1 && matrix[node.x - 1][node.y] != '0') //!up
            {
                neighbours.Add(new Node(node.x - 1, node.y, node.distanceFromSource + 1));
            }

            if ( node.x + 1 < matrix.Length && matrix[node.x + 1][node.y] != '0')//!down
            {
                neighbours.Add(new Node(node.x + 1, node.y, node.distanceFromSource + 1));
            }

            if (node.y - 1 > -1  && matrix[node.x][node.y - 1] != '0')//!left
            {
                neighbours.Add(new Node(node.x, node.y - 1, node.distanceFromSource + 1));
            }           

            if (node.y + 1 < matrix.Length && matrix[node.x][node.y + 1] != '0')//!right
            {
                neighbours.Add(new Node(node.x, node.y + 1, node.distanceFromSource + 1));
            } 

            return neighbours;
        }
    }

    public class Node
    {
        public int x;
        public int y;
        public int distanceFromSource;

        public Node(int x, int y, int distanceFromSource)
        {
            this.x = x;
            this.y = y;
            this.distanceFromSource = distanceFromSource;
        }
    }
}
