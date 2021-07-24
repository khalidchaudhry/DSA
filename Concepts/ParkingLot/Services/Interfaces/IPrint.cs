using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem.Services.Interfaces
{
    public interface IPrint
    {
        void Print(string str);

        void Print(Dictionary<int,List<int>> keyValuePairs, DisplayType displayType,SlotType slotType);

        void Print(Dictionary<int, int> keyValuePairs, SlotType slotType);
    }
}
