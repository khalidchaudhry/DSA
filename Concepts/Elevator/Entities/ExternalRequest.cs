using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.Entities
{
    public class ExternalRequest
    {

        public Direction DirectionToGo { get; private set; }
        public int Source { get; private set; }
        
    }
}
