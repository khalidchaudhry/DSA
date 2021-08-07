using ElevatorSystem.Entities;
using ElevatorSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            ElevatorService elevatorService = new ElevatorService();

            DispatcherService dispatcherService = new DispatcherService(elevatorService);

            ExternalRequest externalRequest = new ExternalRequest(Direction.Up, 0);
            elevatorService.ProcesExternal(externalRequest);

            InternalRequest internalRequest = new InternalRequest(9);
            elevatorService.ProcessInternal(internalRequest);
                       
            Thread thread = new Thread(new ThreadStart(dispatcherService.Run));

            thread.Start();
        }
    }
}
