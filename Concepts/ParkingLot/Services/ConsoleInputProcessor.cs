using ParkingLotSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem.Services
{
    
    public class ConsoleInputProcessor : IInputProcessor
    {
        public string[] GetTokens(string input, string delimeter)
        {
            return input.Split(new string[] { delimeter }, StringSplitOptions.None);
        }



    }
}
