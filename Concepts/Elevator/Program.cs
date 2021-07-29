using ElevatorSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            

            ElevatorService elevatorService = new ElevatorService();

            DispatcherService service = new DispatcherService(elevatorService);

            elevatorService.AddDownToUp(9);
            //elevatorService.AddDownToUp(2);
            //elevatorService.AddDownToUp(3);
            //elevatorService.AddDownToUp(4);
            //elevatorService.AddDownToUp(5);

            elevatorService.AddUpToDown(0);
            //elevatorService.AddUpToDown(9);
            //elevatorService.AddUpToDown(3);
            //elevatorService.AddUpToDown(4);
            //elevatorService.AddUpToDown(5);

            service.Run();


        }
    }
}
