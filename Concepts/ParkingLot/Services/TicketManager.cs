using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParkingLotSystem.Entities.ParkingLot;

namespace ParkingLotSystem.Services
{
    public static class TicketManager
    {

        public static string IssueTicket(string parkingLotId,AcquiredFloorSlot floorSlot)
        {
            return $"{parkingLotId}_{floorSlot.FloorId}_{floorSlot.SlotId}";
        }
        public static string GetTicket(string parkingName, int floorId, int slotId)
        {
            return $"{parkingName}_{floorId}_{slotId}";
        }

    }
}
