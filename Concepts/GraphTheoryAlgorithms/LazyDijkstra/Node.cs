using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryAlgorithms.LazyDijkstra
{
    public class Node:IComparable<Node>
    {
        public int id;
        public double value;

        public Node(int id, double value)
        {
            this.id = id;
            this.value = value;
        }
        public int CompareTo(Node other)
        {
            //if (this.id < other.id)
            //    return -1;
            //else if (this.id > other.id)
            //    return 1;
            //else
            //    return 0;
            if (Math.Abs(this.value - other.value) < 1e-6)
                return 0;
            return (this.value - other.value) > 0 ? +1 : -1;

        }




    }
}
