using ParkingLotSystem.Services.Interfaces;
using ParkingLotSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem.Services
{
    public class Validator : IValidator
    {

        IInputProcessor _inputProcessor;
        public Validator(IInputProcessor inputProcessor)
        {
            _inputProcessor = inputProcessor;
        }
        public bool ValidateCreateParkinglotCmd(string input)
        {
            bool isCommandValid = false;

            string[] cmdTokens = _inputProcessor.GetTokens(input, Constants.CreateParkingLotCmd);
            if (!IsCountValid(cmdTokens, 2))
            {
                string[] createParkingLotTokens = _inputProcessor.GetTokens(cmdTokens[1], Constants.SpaceDelimiter);

                if (IsCountValid(createParkingLotTokens, 4))
                {
                    if (Convertor.IsConvertable(createParkingLotTokens[2], typeof(Int32)) &&
                     Convertor.IsConvertable(createParkingLotTokens[3], typeof(Int32))
                    )
                    {
                        isCommandValid = true;
                    }
                }
            }
            return isCommandValid;
        }

        public bool ValidateDisplayCommand(string input)
        {
            bool isCommandValid = false;

            string[] cmdTokens = _inputProcessor.GetTokens(input, Constants.DisplayCmd);
            if (IsCountValid(cmdTokens, 2))
            {
                {
                    string[] displayTokens = _inputProcessor.GetTokens(cmdTokens[1], Constants.SpaceDelimiter);
                    if (IsCountValid(displayTokens, 3))
                    {
                        if (Convertor.IsConvertable(displayTokens[1], typeof(DisplayType)) &&
                         Convertor.IsConvertable(displayTokens[2], typeof(SlotType)))
                        {
                            isCommandValid = true;
                        }
                    }
                }
            }
            return isCommandValid;
        }

        public bool ValidateParkVehicleCommand(string input)
        {
            bool isCommandValid = false;

            string[] cmdTokens = _inputProcessor.GetTokens(input, Constants.ParkVehicleCmd);
            if (IsCountValid(cmdTokens, 2))
            {
                string[] parkVehicleTokens = _inputProcessor.GetTokens(cmdTokens[1], Constants.SpaceDelimiter);
                if (IsCountValid(parkVehicleTokens, 4))
                {
                    if (Convertor.IsConvertable(parkVehicleTokens[1], typeof(SlotType)))
                    {
                        isCommandValid = true;
                    }
                }
            }
            return isCommandValid;
        }

        public bool ValidateUnParkVehicleCommand(string input)
        {
            bool isCommandValid = false;

            string[] cmdTokens = _inputProcessor.GetTokens(input, Constants.SpaceDelimiter);
            if (IsCountValid(cmdTokens, 2))
            {
                string[] unparkVehicleTokens = _inputProcessor.GetTokens(cmdTokens[1], Constants.UnderScoreDelimiter);
                if (IsCountValid(unparkVehicleTokens, 3))
                {
                    if (Convertor.IsConvertable(unparkVehicleTokens[1], typeof(Int32)) &&
                       Convertor.IsConvertable(unparkVehicleTokens[2], typeof(Int32)))
                    {
                        isCommandValid = true;
                    }                  
                }               
            }
            return isCommandValid;
        }


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
