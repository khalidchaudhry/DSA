using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem.Services.Interfaces
{
    public interface IValidator
    {
        bool IsCountValid(string[] tokens, int count);

        bool IsConvertable(string token, Type type);        
    }
}
