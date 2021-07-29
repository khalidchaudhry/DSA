using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.Entities
{

    public class Elevator
    {

        private int _maxLoad;
        private int _noOfPassengers;
        private int _maxSpeed;       

        public int CurrentFloor { get; private set; }
        public Direction CurrentDirection { get; private set; }

        public State CurrentState { get; set; }

        public Elevator()
        {
            CurrentFloor = 0;
            CurrentDirection = Direction.Up;
            CurrentState = State.IDLE;

        }
        public Elevator(int maxLoad, int noOfPassengers, int maxSpeed):this()
        {
            _maxLoad = maxLoad;
            _noOfPassengers = noOfPassengers;
            _maxSpeed = maxSpeed;
           
        }     


    }
}
