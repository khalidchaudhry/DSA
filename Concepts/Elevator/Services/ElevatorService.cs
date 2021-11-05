using ElevatorSystem.Entities;
using ElevatorSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElevatorSystem.Services
{

    public class ElevatorService: IElevatorService
    {
        private Elevator _elevator;

        private SortedSet<int> _currentJobs;

        private SortedSet<int> _upToDownJobs;

        private SortedSet<int> _downToUpJobs;

        public ElevatorService()
        {
            _elevator = new Elevator();

            _currentJobs = new SortedSet<int>();
            _upToDownJobs = new SortedSet<int>();
            _downToUpJobs = new SortedSet<int>();
        }


        public void Move(int floorId)
        {
            Console.WriteLine($"Elevator state:{State.MOVING}");
            Thread.Sleep(2000);
            _elevator.CurrentState = State.STOPPED;
            Console.WriteLine($"Elevator state:{State.STOPPED}");
            Console.WriteLine($"Reached at floor{floorId}");
        }
        public bool HasInstructions()
        {
            bool hasInstructions = _upToDownJobs.Count > 0 || _downToUpJobs.Count > 0;
            if (!hasInstructions)
            {
                _elevator.CurrentState = State.IDLE;
                Console.WriteLine($"Elevator state:{State.IDLE}");
            }
            return hasInstructions;
        }


        //TODO: Make the code compact and avoid repitation 
        public int NextFloor()
        {
            //! If current jobs count > 0 assign _currentJobs  to _currentJobs
            //! If _downToUpJobs>0  assign _currentJobs  to _downToUpJobs
            //! else  _upToDownJobs>0 assign _currentJobs  to _upToDownJobs
            _currentJobs = _currentJobs.Count > 0 ? _currentJobs :
                                                   _downToUpJobs.Count > 0 ? _downToUpJobs :
                                                                             _upToDownJobs;

            int first = _currentJobs.First();
            _currentJobs.Remove(first);
            return first;
        }
        private void AddDownToUp(int floor)
        {
            _downToUpJobs.Add(floor);
        }

        private int GetCurrentJobsCount()
        {
            return _currentJobs.Count;
        }

        private void AddUpToDown(int floor)
        {
            _upToDownJobs.Add(floor);
        }

        /// <summary>
        //! Person inside the elevator and press button inside the elevator  
        /// </summary>
        public void ProcessInternal(InternalRequest internalRequest)
        {
            if (_elevator.CurrentDirection == Direction.Up)
            {
                //! If user destination  >= than current elevator floor and elevator is also going up  
                if (internalRequest.DestinationFloor >= _elevator.CurrentFloor)
                    AddDownToUp(internalRequest.DestinationFloor);
                else
                    //!if user destinaation is less than current elevator  floor and elevator is going up
                    //! i.e. User want to go in opposite direction where the lift is going
                    AddUpToDown(internalRequest.DestinationFloor);
            }
            else if (_elevator.CurrentDirection == Direction.Down)
            {
                // ! if elevator going down and user also wants to go down 
                if (internalRequest.DestinationFloor <= _elevator.CurrentFloor)
                    AddUpToDown(internalRequest.DestinationFloor);
                else
                    //! if elevator going down and user want to go up . 
                    //! i.e. User want to go in opposite direction where the lift is going
                    AddDownToUp(internalRequest.DestinationFloor);
            }
        }


        /// <summary>
        //! Person standing on the floor issue the request
        //! 
        /// </summary>
        public void ProcesExternal(ExternalRequest externalRequest)
        {
            //! If elevator car is coming from up to down (i.e. higher floor than user is on) and 
            //! person  wants to go in  opposite direction where elevator is heading
            if (externalRequest.DirectionToGo == Direction.Up)
            {
                AddDownToUp(externalRequest.Source);
            }
            //! If elevator car is coming from up to down (i.e. higher floor than user is on) and 
            //! person also wants to go in the same direction where elevator is heading  
            else if (externalRequest.DirectionToGo == Direction.Down)
            {
                AddUpToDown(externalRequest.Source);
            }
        }
    }
}
