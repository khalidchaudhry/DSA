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
            /*
                  Requirements 
                      1. Elevator states(UP,DOWN,IDLE)
                      2. Elevator transfer passengers from one floor to another 
                      3. Eelvator only open door when idle
                      4. We have 200 elevator floors and 50 elevators cars 
                      5.Elevator attributes 
                        1.  Number of passengers in car. 
                        2. Max load the car can carry
                     6. What we need to minimize?
                         1. Wait time of system 
                        2. Wait time of individual passegers
                     7. Do we need to increasee Throughput of passengers?
                     8. Do we need to minize Powerusage? 
                     9  Do we need to divide elevators into multiple zones?
                    10. Emergency alarms/breaks
                    11. VIP or utility elements 
                    12. Monitoring system


             */
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
