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
        private readonly object _floorLock = new object();
        public DispatcherService(ElevatorService elevatorService)
        {
            _elevatorService = elevatorService;
            _floorLock = new object();
            var thread = new Thread(new ThreadStart(Run));
            thread.Start();

        }
        public void Run()
        {
            while (true)
            {
                lock (_floorLock)
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
}
