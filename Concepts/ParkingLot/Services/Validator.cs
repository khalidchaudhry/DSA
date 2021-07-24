using ParkingLotSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem.Services
{
    public class Validator : IValidator
    {
        public bool IsConvertable(string token, Type type)
        {
            if (typeof(Int32) == type)
                return Int32.TryParse(token, out int result);
            if (typeof(DisplayType) == type)
            {
                return DisplayType.TryParse(token, out DisplayType result);
            }
            return true;
        }
        

        public bool IsCountValid(string[] tokens, int count)
        {

            return tokens.Length == count;


        }
    }
}
