using ElevatorSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.Services.Interfaces
{
    public interface IElevatorService
    {
        int NextFloor();
        void ProcessInternal(InternalRequest internalRequest);
        void ProcesExternal(ExternalRequest externalRequest);
        bool HasInstructions();
        void Move(int floorId);
    }
}
