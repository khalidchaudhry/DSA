﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.Entities
{
    public class InternalRequest
    {
        public int DestinationFloor { get; private set; }

        public InternalRequest(int destinationFloor)
        {
            DestinationFloor = destinationFloor;
        }
    }
}
