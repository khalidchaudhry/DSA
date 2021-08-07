using ParkingLotSystem.Entities;
using ParkingLotSystem.Services.Interfaces;
using ParkingLotSystem.Utils;
using System;

namespace ParkingLotSystem.Services
{
    public class ApplicationRunner
    {
        private IInputProcessor _inputProcessor;
        private IValidator _validator;
        private IPrint _print;
        private IParkingManager _parkingManager;
        public ApplicationRunner(IInputProcessor inputProcessor,
                                 IValidator validator,
                                 IPrint print,
                                 IParkingManager parkingManager)
        {
            _inputProcessor = inputProcessor;
            _validator = validator;
            _print = print;
            _parkingManager = parkingManager;
        }
        //! Should i perform validation from  application runner or inputprocessor ??
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input.StartsWith(Constants.CreateParkingLotCmd))
                {
                    if (_validator.ValidateCreateParkinglotCmd(input))
                    {
                        string[] cmdTokens = _inputProcessor.GetTokens(input, Constants.CreateParkingLotCmd);
                        string[] createParkingLotTokens = _inputProcessor.GetTokens(cmdTokens[1], Constants.SpaceDelimiter);
                        int floors = Convertor.ConvertToInt(createParkingLotTokens[2]);
                        int slotsPerFloor = Convertor.ConvertToInt(createParkingLotTokens[3]);
                        _parkingManager.CreateParkingLot(Constants.ParkingLotName, floors, slotsPerFloor);
                    }
                    else
                    {
                        _print.Print($"Command shouldbe of format : create_parking_lot <parking_lot_id> < no_of_floors > < no_of_slots_per_floor > ");
                    }
                }
                else if (input.StartsWith(Constants.DisplayCmd))
                {
                    if (_validator.ValidateDisplayCommand(input))
                    {
                        string[] cmdTokens = _inputProcessor.GetTokens(input, Constants.DisplayCmd);
                        string[] displayTokens = _inputProcessor.GetTokens(cmdTokens[1], Constants.SpaceDelimiter);

                        string displayType = displayTokens[1].ToLower();
                        string slotType = displayTokens[2].ToUpper();

                        DisplayType displayTypeEnum = (DisplayType)Convertor.ConvertToEnum(displayType, typeof(DisplayType));
                        SlotType slotTypeEnum = (SlotType)Convertor.ConvertToEnum(slotType, typeof(SlotType));
                        _parkingManager.PrintCount(displayTypeEnum, slotTypeEnum);
                    }
                    else
                    {
                        _print.Print($"Command shouldbe of format :display <display_type> <vehicle_type>");
                    }
                }
                else if (input.StartsWith(Constants.ParkVehicleCmd))
                {
                    if (_validator.ValidateParkVehicleCommand(input))
                    {
                        string[] cmdTokens = _inputProcessor.GetTokens(input, Constants.ParkVehicleCmd);
                        string[] parkVehicleTokens = _inputProcessor.GetTokens(cmdTokens[1], Constants.SpaceDelimiter);
                        string slotType = parkVehicleTokens[1];
                        string registrationNumer = parkVehicleTokens[2];
                        string color = parkVehicleTokens[3];
                        SlotType SlotTypeEnum = (SlotType)Convertor.ConvertToEnum(slotType, typeof(SlotType));
                        _parkingManager.Park(SlotTypeEnum, registrationNumer, color);
                    }
                    else
                    {
                        _print.Print($"Command shouldbe of format: park_vehicle <VehicleType> <RegisttrationNumber> <black>  ");
                    }
                }
                else if (input.StartsWith(Constants.UnparkVehicleCmd))
                {

                    if (_validator.ValidateUnParkVehicleCommand(input))
                    {

                        string[] cmdTokens = _inputProcessor.GetTokens(input, Constants.SpaceDelimiter);
                        string[] unparkVehicleTokens = _inputProcessor.GetTokens(cmdTokens[1], Constants.UnderScoreDelimiter);
                        int floorId = Convertor.ConvertToInt(unparkVehicleTokens[1]);
                        int slotId = Convertor.ConvertToInt(unparkVehicleTokens[2]);
                        _parkingManager.UnPark(unparkVehicleTokens[0], floorId, slotId);
                    }
                    else
                    {
                        _print.Print($"Command shouldbe of format : unpark_vehicle <ticketId>");
                    }
                }
                else if (input == Constants.exitCmd)
                {

                    break;
                }
                else
                {
                    _print.Print("Invalid command. Please try again");
                }
            }
        }
    }
}
