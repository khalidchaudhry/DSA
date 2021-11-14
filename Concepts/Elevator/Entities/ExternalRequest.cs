using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.Entities
{
    /// <summary>
    //! Request from person outside of the elevator
    /// </summary>
    public class ExternalRequest
    {

        public Direction DirectionToGo { get; private set; }
        public int UserFloor { get; private set; }
        public ExternalRequest(Direction directionToGo,int userFloor)
        {
            DirectionToGo = directionToGo;
            UserFloor = userFloor;
        }
    }
}
