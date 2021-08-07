using ParkingLotSystem.Entities;
using ParkingLotSystem.Services.Interfaces;
using System.Collections.Generic;

namespace ParkingLotSystem.Services
{
    public class ParkingManager : IParkingManager
    {

        private Dictionary<string, Vehicle> _ticketIdVehicle;
        private ParkingLot _parkingLot;
        private IPrint _print;
        public ParkingManager(IPrint print)
        {
            _print = print;
            _ticketIdVehicle = new Dictionary<string, Vehicle>();
            _parkingLot = new ParkingLot(_print);
        }

        //! should it be fine for parking manager to create parking lot ?
        public void CreateParkingLot(string name, int floors, int slotsPerFloor)
        {
            _parkingLot.CreateParkingLot(name, floors, slotsPerFloor);
        }

        public void PrintCount(DisplayType displayType, SlotType slotType)
        {
            switch (displayType)
            {
                case DisplayType.free_count:
                    _print.Print(_parkingLot.GetFreeSlotsCountPerFloor(slotType), slotType);
                    break;
                case DisplayType.free_slots:
                case DisplayType.occupied_slots:
                    _print.Print(_parkingLot.GetSlotsPerFloor(slotType, displayType), displayType, slotType);
                    break;
                default:
                    _print.Print("Invalid  DisplayType");
                    break;
            }
        }

        public void Park(SlotType slotType, string registrationNumber, string color)
        {

            ParkingLot.AcquireFreeSlotResult floorSlot = _parkingLot.AcquireFreeSlot(slotType);
            if (floorSlot == null)
            {
                _print.Print("Parking Lot Full");
                return;
            }
            string ticketId = TicketManager.IssueTicket(_parkingLot._name, floorSlot);
            Vehicle vehicle = new Vehicle(slotType, registrationNumber, color);
            _ticketIdVehicle.Add(ticketId, vehicle);
            _print.Print($"ParkedVehicle. Ticket ID: {ticketId}");

        }
        public void UnPark(string parkingName, int floorId, int slotId)
        {
            string ticketId = TicketManager.GetTicket(parkingName,floorId,slotId);
            if (!_ticketIdVehicle.ContainsKey(ticketId))
            {
                _print.Print("Invalid Ticket");
                return;
            }
            SlotType vehicleType = _ticketIdVehicle[ticketId].VehicleType;
            string registrationNumber = _ticketIdVehicle[ticketId].RegistrationNumber;
            string color = _ticketIdVehicle[ticketId].Color;

            _parkingLot.ReleaseSlot(vehicleType, floorId, slotId);
             _ticketIdVehicle.Remove(ticketId);
            _print.Print($"Unparked vehicle with Registration Number: {registrationNumber} and Color:{color}");

        }


    }
}
