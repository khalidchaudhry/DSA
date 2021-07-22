using ParkingLot.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Entities
{
    public class ParkingLot
    {


        private IPrint _print;
        public ParkingLot(int floors,int slotsPerFloor)
        {
            _print.Print($"Created parking lot with {floors} floors and {slotsPerFloor} slots per floor");

        }

    }
}
