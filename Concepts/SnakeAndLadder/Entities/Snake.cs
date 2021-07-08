using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder.Entities
{
    public class Snake
    {
        public int HeadPosition { get; }
        public int TailPosition { get; }
        public Snake(int headPosition, int tailPosition)
        {
            HeadPosition = headPosition;
            TailPosition = tailPosition;
        }
    }
}
