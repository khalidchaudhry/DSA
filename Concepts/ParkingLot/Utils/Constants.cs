using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem.Utils
{
    public static class Constants
    {
        #region commands
        public static string CreateParkingLotCmd = "create_parking_lot";
        public static string ParkVehicleCmd = "park_vehicle";
        public static string UnparkVehicleCmd = "unpark_vehicle";
        public static string DisplayCmd = "display";
        public static string exitCmd = "exit";
        #endregion

        #region delimeter
        public static string SpaceDelimiter = " ";
        public static string CommaDelimiter = ",";
        public static string UnderScoreDelimiter = "_";

        #endregion

        #region Slots
        public static List<int> TruckSlots = new List<int>() { 1 };
        public static List<int> BikeSlots = new List<int>() { 2, 3 };

        #endregion

        #region misc
        public static string ParkingLotName = "PR1234";
        #endregion
    }
}
