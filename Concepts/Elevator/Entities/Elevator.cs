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

        private SortedSet<int> _currentJobs;

        private SortedSet<int> _upToDownJobs;

        private SortedSet<int> _downToUpJobs;

        public int CurrentFloor { get; private set; }
        public Direction CurrentDirection { get; private set; }

        public State CurrentState { get; private set; }

        public Elevator(int maxLoad,int noOfPassengers,int maxSpeed)
        {
            _maxLoad = maxLoad;
            _noOfPassengers = noOfPassengers;
            _maxSpeed = maxSpeed;
            _currentJobs = new SortedSet<int>();
            _upToDownJobs = new SortedSet<int>();
            _downToUpJobs = new SortedSet<int>();
            CurrentFloor = 0;
            CurrentDirection = Direction.Up;
            CurrentState = State.IDLE;
            
        }
        public void AddDownToUp(int floor)
        {
            _downToUpJobs.Add(floor);
        }

        public int GetCurrentJobsCount()
        {
            return _currentJobs.Count;
        }

        public void AddUpToDown(int floor)
        {
            _upToDownJobs.Add(floor);

        }
    }
}
