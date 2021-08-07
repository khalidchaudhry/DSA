using ParkingLotSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                  A parking lot is an area where cars can be parked for a certain amount of time. 
                  A parking lot can have multiple floors with each floor having a different number of slots and 
                  each slot being suitable for different types of vehicles 
                  The functions that the parking lot system can do:
                Create the parking lot.
                Add floors to the parking lot.
                Add a parking lot slot to any of the floors.
                Given a vehicle, it finds the first available slot, books it, creates a ticket, parks the vehicle, and finally returns the ticket.
                Unparks a vehicle given the ticket id.
                Displays the number of free slots per floor for a specific vehicle type.
                Displays all the free slots per floor for a specific vehicle type.
                Displays all the occupied slots per floor for a specific vehicle type.
                
                Details about the Vehicles:
                    Every vehicle will have a type, registration number, and color.
                       How color will help building the system?
                    Different Types of Vehicles:
                        Car
                        Bike
                        Truck
               
                Details about the Parking Slots:
                       Each type of slot can park a specific type of vehicle.
                       No other vehicle should be allowed by the system.
                       Finding the first available slot should be based on:
                           The slot should be of the same type as the vehicle.
                           The slot should be on the lowest possible floor in the parking lot.
                           The slot should have the lowest possible slot number on the floor.
                          Numbered serially from 1 to n for each floor where n is the number of parking slots on that floor.

               Details about the Parking Lot Floors:
                    Numbered serially from 1 to n where n is the number of floors.
                    Might contain one or more parking lot slots of different types.
                    We will assume that the first slot on each floor will be for a truck, the next 2 for bikes, and all the other slots for cars.

               Details about the Tickets:
                   The ticket id would be of the following format:
                        <parking_lot_id>_<floor_no>_<slot_no>
                        Example: PR1234_2_5 (denotes 5th slot of 2nd floor of parking lot PR1234)


             */


            /*
               Entities : 
               ParkingLotSystem                    
                    Consists of floors
                    HashSet<Floor> Floors
                    

               ParkingFloor
                   FloorId   from 1 to n 
                   FreeSlot: HashSet<FloorSlots> 
                   Occupied Slots : HashSet<FloorSlots> 
                   Consists of  slots 
               FloorSlot
                   Type
                   SlotId: numbered from 1 to n 
               Ticket
                  TicketNumber
                  Ticket has Parking Slot and floor number on it           
                  ParingLotId:
                  FloorNumber:
                  SlotNumber
              Vehicle
                   Type 
                   RegistrationNumber
                  Color

               Vehicle Type 
                    Not sure its an entity or enum? 
                    Car, Bike,Truck

               Services:
                   Parking Manager
                           Will Park/UnPark 
                   Ticket Manager
                           Will issue/collect ticket 
                   Payment Manager
                           Will charge user based on time spent  in parking lot

              
             */
            ConsoleInputProcessor consoleInputProcessor = new ConsoleInputProcessor();
            Validator validator = new Validator(consoleInputProcessor);
            ConsolePrint consolePrint = new ConsolePrint();
            ParkingManager parkingManager = new ParkingManager(consolePrint);
            ApplicationRunner applicationRunner = new ApplicationRunner(consoleInputProcessor, validator, consolePrint, parkingManager);
            applicationRunner.Run();
        }
    }
}
