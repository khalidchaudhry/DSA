using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem.Entities
{
    public class Vehicle
    {
        public string RegistrationNumber { get; private set; }
        public string Color { get; private set; }       

        public SlotType VehicleType { get; private set; }
        public Vehicle(SlotType vehicleType,string registrationNumber,string color)
        {
            VehicleType = vehicleType;
            RegistrationNumber = registrationNumber;
            Color = color;          
        }
    }
}
