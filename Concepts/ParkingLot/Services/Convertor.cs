using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem.Services
{
    public static class Convertor
    {
        public static int ConvertToInt(string str)
        {
            return Convert.ToInt32(str);
        }

        public static Enum ConvertToEnum(string str, Type type)
        {
            if (typeof(DisplayType) == type)
            {
                Enum.TryParse(str, out DisplayType result);
                return result;
            }
            if (typeof(SlotType) == type)
            {
                Enum.TryParse(str, out SlotType result);
                return result;
            }
            throw new NotSupportedException($"Not supported enum type{type}");
        }

        public static bool IsConvertable(string token, Type type)
        {
            if (typeof(Int32) == type)
                return Int32.TryParse(token, out int result);
            if (typeof(DisplayType) == type)
            {
                return DisplayType.TryParse(token, out DisplayType result);
            }
            if (typeof(SlotType) == type)
            {
                return SlotType.TryParse(token, out SlotType result);
            }

            return false;
        }
    }
}
