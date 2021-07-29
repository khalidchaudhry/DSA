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
        private ElevatorService _elevatorService;

        public DispatcherService(ElevatorService elevatorService)
        {
            _elevatorService = elevatorService;
            var thread = new Thread(new ThreadStart(Run));
            thread.Start();

        }
        public void Run()
        {
            while (true)
            {
                if (_elevatorService.HasInstructions())
                {
                    int nextFloor=_elevatorService.NextFloor();
                    _elevatorService.Move(nextFloor);

                }
            }
        }

    }
}
