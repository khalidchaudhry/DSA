using ParkingLotSystem.Entities;
using System.Collections.Generic;

namespace ParkingLotSystem.Services
{
    public interface IParkingManager
    {
        void CreateParkingLot(string name, int floors, int slotsPerFloor);

        void PrintCount(DisplayType displayType, SlotType slotType);
        void Park(SlotType slotType, string registrationNumber, string color);
        void UnPark(string parkingName, int floorId, int slotId);
    }
}