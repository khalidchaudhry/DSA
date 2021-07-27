using ElevatorSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.Services
{

    public class ElevatorService
    {
        private Elevator _elevator;


        public void StartElevator()
        {
            while (true)
            {


            }

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
                    _elevator.AddDownToUp(internalRequest.DestinationFloor);
                else
                    //!if user destinaation is less than current elevator  floor and elevator is going up
                    //! i.e. User want to go in opposite direction where the lift is going
                    _elevator.AddUpToDown(internalRequest.DestinationFloor);
            }
            else if (_elevator.CurrentDirection == Direction.Down)
            {
               // ! if elevator going down and user also wants to go down 
                if (internalRequest.DestinationFloor <= _elevator.CurrentFloor)
                    _elevator.AddUpToDown(internalRequest.DestinationFloor);
                else
                    //! if elevator going down and user want to go up . 
                    //! i.e. User want to go in opposite direction where the lift is going
                    _elevator.AddDownToUp(internalRequest.DestinationFloor);
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
                _elevator.AddDownToUp(externalRequest.Source);
            }
            //! If elevator car is coming from up to down (i.e. higher floor than user is on) and 
            //! person also wants to go in the same direction where elevator is heading  
            else if(externalRequest.DirectionToGo==Direction.Down)
            {
                _elevator.AddUpToDown(externalRequest.Source);
            }
        }

        public bool CheckIfJob()
        {
            if (_elevator.GetCurrentJobsCount() == 0)
            {
                return false;
            }

            return true;

        }
    }
}
