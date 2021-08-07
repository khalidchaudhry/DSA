using ElevatorSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElevatorSystem.Services
{
    /// <summary>
    // !Class is responsible for instructing the elevator service to move at certain floor
    /// </summary>
    public class DispatcherService
    {
        private IElevatorService _elevatorService;
        public DispatcherService(IElevatorService elevatorService)
        {
            _elevatorService = elevatorService;

        }
        public void Run()
        {
            while (true)
            {
                if (_elevatorService.HasInstructions())
                {

                    int nextFloor = _elevatorService.NextFloor();
                    _elevatorService.Move(nextFloor);
                }
            }
        }
    }
}
