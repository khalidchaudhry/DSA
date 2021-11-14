using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem.Entities
{
    public static class Ticket
    {

        public static string IssueTicket(string ParkingLotSystemId, int floorId, int slotId)
        {
            return $"{ParkingLotSystemId}_{floorId}_{slotId}";
        }

    }
}
