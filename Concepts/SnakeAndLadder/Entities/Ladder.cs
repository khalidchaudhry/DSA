using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder.Entities
{
    public class Ladder
    {
        public (int r, int c) StartPosition { get; }
        public (int r, int c) EndPosition { get; }
        public Ladder((int r, int c) startPosition, (int r, int c) endPosition)
        {
            StartPosition = startPosition;
            EndPosition = endPosition;
        }

    }
}
