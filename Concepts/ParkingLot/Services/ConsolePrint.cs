using ParkingLotSystem.Services.Interfaces;
using ParkingLotSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem.Services
{
    public class ConsolePrint : IPrint
    {
        public void Print(string str)
        {
            Console.WriteLine(str);
        }

        public void Print(Dictionary<int, List<int>> floorIdSlotIds, DisplayType displayType,SlotType slotType)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var keyValue in floorIdSlotIds)
            {
                switch (displayType)
                {
                    case DisplayType.free_slots:
                        sb.Append($"Free slots for {slotType} on floor {keyValue.Key}: {string.Join(Constants.CommaDelimiter, keyValue.Value)}");
                        break;
                    case DisplayType.occupied_slots:
                        sb.Append($"Occupied slots for {slotType} on floor {keyValue.Key}: {string.Join(Constants.CommaDelimiter, keyValue.Value)}");
                        break;
                }

                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());

        }

        public void Print(Dictionary<int, int> floorIdSlotCount, SlotType slotType)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var keyValue in floorIdSlotCount)
            {                                  
               sb.Append($"No of free slots  for {slotType} on floor {keyValue.Key}: {keyValue.Value}");
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
