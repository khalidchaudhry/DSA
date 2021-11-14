using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem.Services.Interfaces
{
    public interface IValidator
    {

        bool ValidateCreateParkinglotCmd(string input);

        bool ValidateDisplayCommand(string input);

        bool ValidateParkVehicleCommand(string input);

        bool ValidateUnParkVehicleCommand(string input);

        bool IsCountValid(string[] tokens, int count);

        bool IsConvertable(string token, Type type);        
    }
}
