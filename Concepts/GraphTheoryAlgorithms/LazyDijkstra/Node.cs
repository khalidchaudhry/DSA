using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryAlgorithms.LazyDijkstra
{
    public class Node : IComparable<Node>
    {
        public int id;
        public double value;

        public Node(int id, double value)
        {
            this.id = id;
            this.value = value;
        }
        //Compares the current instance(this) with another object of the same type and returns an integer that indicates 
        //whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        //! Less than zero = This instance precedes obj in the sort order.
        //! Zero = This instance occurs in the same position in the sort order as obj.
        //!Greater than zero = This instance follows obj in the sort order.
        public int CompareTo(Node other)
        {
            //if (this.value < other.value)
            //    return -1;
            //else if (this.value > other.value)
            //    return 1;
            //else
            //    return 0;

            //if (Math.Abs(this.value - other.value) < 1e-6)
            //    return 0;
            //return (this.value - other.value) > 0 ? +1 : -1;

            return this.value.CompareTo(other);
        }




    }
}
