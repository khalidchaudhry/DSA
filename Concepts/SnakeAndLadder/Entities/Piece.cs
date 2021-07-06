using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder.Entities
{
    public class Piece
    {
        public string Name { get; }
        public (int r, int c) PiecePosition { get; }
        public Piece(string name, (int r, int c) piecePosition)
        {
            Name = name;
            PiecePosition = piecePosition;
        }

    }
}
