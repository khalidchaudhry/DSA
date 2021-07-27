using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElevatorSystem.Services
{
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
            //! Start the elevator 
            _elevatorService.StartElevator();
        }
    }
}
