using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe.Entities
{
    public class Position
    {
        public int Row { get; }
        public int Col { get; }

        public Position(int row,int col)
        {
            Row = row;
            Col = col;
        }
        //Allows to override method with argument type as Object only  
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var position = (Position)obj;
            return position.Row == Row && position.Col == Col;
        }
        //For hash based comparison  
        public override int GetHashCode()
        {
            return Row + Col;
        }
    }
}
