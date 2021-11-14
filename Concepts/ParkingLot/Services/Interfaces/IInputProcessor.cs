using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem.Services.Interfaces
{
    public interface IInputProcessor
    {
        string[] GetTokens(string input, string delimeter);
        

    }
}
