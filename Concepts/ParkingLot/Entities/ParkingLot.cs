using ParkingLotSystem.Services.Interfaces;
using ParkingLotSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem.Entities
{
    public class ParkingLot
    {
        private IPrint _print;
        private ParkingFloor[] _floors;
        public string _name;
        public ParkingLot(IPrint print)
        {
            _print = print;
        }
        public void CreateParkingLot(string name, int floorCount, int slotsPerFloorCount)
        {
            _name = name;
            _floors = new ParkingFloor[floorCount + 1];

            for (int floorId = 1; floorId <= floorCount; ++floorId)
            {
                _floors[floorId] = new ParkingFloor(slotsPerFloorCount);
            }
            _print.Print($"Created parking lot with {floorCount} floors and {slotsPerFloorCount} slots per floor");
        }
        public AcquireFreeSlotResult AcquireFreeSlot(SlotType slotType)
        {
            for (int floorId = 1; floorId < _floors.Length; ++floorId)
            {
                if (_floors[floorId].SlotTypeFreeSlots[slotType].Count > 0)
                {
                    ParkingFloorSlot slot = _floors[floorId].SlotTypeFreeSlots[slotType].ElementAt(0);
                    _floors[floorId].SlotTypeFreeSlots[slotType].Remove(slot);
                    _floors[floorId].SlotTypeOccupiedSlots[slotType].Add(slot);

                    return new AcquireFreeSlotResult(floorId, slot.SlotId);
                }
            }
            return null;
        }
        public void ReleaseSlot(SlotType slotType, int floorId, int slotId)
        {
            ParkingFloorSlot slot = new ParkingFloorSlot(slotId);
            _floors[floorId].SlotTypeOccupiedSlots[slotType].Remove(slot);
            _floors[floorId].SlotTypeFreeSlots[slotType].Add(slot);
        }
        public Dictionary<int, int> GetFreeSlotsCountPerFloor(SlotType slotType)
        {
            Dictionary<int, int> floorIdFreeSlotCount = new Dictionary<int, int>();
            for (int floorId = 1; floorId < _floors.Length; ++floorId)
            {
                if (!floorIdFreeSlotCount.ContainsKey(floorId))
                {
                    floorIdFreeSlotCount.Add(floorId, 0);
                }
                floorIdFreeSlotCount[floorId] += _floors[floorId].SlotTypeFreeSlots[slotType].Count;
            }
            return floorIdFreeSlotCount;
        }
        public Dictionary<int, List<int>> GetSlotsPerFloor(SlotType slotType, DisplayType displayType)
        {
            Dictionary<int, List<int>> floorIdSlotIds = new Dictionary<int, List<int>>();
            for (int floorId = 1; floorId < _floors.Length; ++floorId)
            {
                SortedSet<ParkingFloorSlot> slots = displayType == DisplayType.free_slots ?
                                                                _floors[floorId].SlotTypeFreeSlots[slotType] :
                                                                _floors[floorId].SlotTypeOccupiedSlots[slotType];

                floorIdSlotIds.Add(floorId, new List<int>());
                foreach (ParkingFloorSlot parkingFloorSlot in slots)
                {
                    floorIdSlotIds[floorId].Add(parkingFloorSlot.SlotId);
                }
            }
            return floorIdSlotIds;
        }

        private class ParkingFloor
        {
            public Dictionary<SlotType, SortedSet<ParkingFloorSlot>> SlotTypeFreeSlots;
            public Dictionary<SlotType, SortedSet<ParkingFloorSlot>> SlotTypeOccupiedSlots;
           
            public ParkingFloor(int slotsPerFloor)
            {

                SlotTypeFreeSlots = new Dictionary<SlotType, SortedSet<ParkingFloorSlot>>
                {                    
                    [SlotType.TRUCK] = new SortedSet<ParkingFloorSlot>(),
                    [SlotType.BIKE] = new SortedSet<ParkingFloorSlot>(),
                    [SlotType.CAR] = new SortedSet<ParkingFloorSlot>()
                };

                SlotTypeOccupiedSlots = new Dictionary<SlotType, SortedSet<ParkingFloorSlot>>
                {

                    //! No slots occupied when initializing parking floor
                    [SlotType.TRUCK] = new SortedSet<ParkingFloorSlot>(),
                    [SlotType.BIKE] = new SortedSet<ParkingFloorSlot>(),
                    [SlotType.CAR] = new SortedSet<ParkingFloorSlot>()
                };

                for (int slotId = 1; slotId <= slotsPerFloor; ++slotId)
                {
                    switch (slotId)
                    {
                        case 1:                           
                            SlotTypeFreeSlots[SlotType.TRUCK].Add(new ParkingFloorSlot(slotId));
                            break;
                        case 2:
                        case 3:
                            SlotTypeFreeSlots[SlotType.BIKE].Add(new ParkingFloorSlot(slotId));
                            break;
                        default:
                            SlotTypeFreeSlots[SlotType.CAR].Add(new ParkingFloorSlot(slotId));
                            break;
                    }
                }
            }
        }

        private  class ParkingFloorSlot
        {
            public int SlotId { get; private set; }
            public ParkingFloorSlot(int slotId)
            {
                SlotId = slotId;
            }
            public override bool Equals(object obj)
            {
                ParkingFloorSlot other = obj as ParkingFloorSlot;
                if (other == null) return false;
                return SlotId == other.SlotId;
            }

            public override int GetHashCode()
            {
                return  SlotId.GetHashCode();
            }

        }

        public class AcquireFreeSlotResult
        {
            public int FloorId { get; private set; }
            public int SlotId { get; private set; }
            public AcquireFreeSlotResult(int floorId, int slotId)
            {
                FloorId = floorId;
                SlotId = slotId;
            }
        }
    }
}