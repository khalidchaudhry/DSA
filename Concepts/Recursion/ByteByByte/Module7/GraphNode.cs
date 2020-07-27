using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion.ByteByByte.Module7
{
    public class GraphNode
    {
        public int Value { get; set; }
        public GraphNode[] neighbors { get; set; }

        public GraphNode(int value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return "" + Value;
        }
    }
}
